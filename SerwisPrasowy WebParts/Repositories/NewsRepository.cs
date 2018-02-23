using Microsoft.SharePoint;
using SerwisPrasowy_WebParts.DTO;
using SerwisPrasowy_WebParts.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerwisPrasowy_WebParts.Repositories
{
    public class NewsRepository : INewsRepository
    {
        SPWeb web;

        public NewsRepository(SPWeb web)
        {
            this.web = web;
        }

        public NewsDTO GetLatestNewsFromCategory(string categoryName)
        {
            string query = "<Where><Contains><FieldRef Name='Category' /><Value Type='Lookup'>" + categoryName + "</Value></Contains></Where><OrderBy><FieldRef Name='Created' Ascending='False' /></OrderBy>";
            SPListItem newsSPItem = ExecuteQueryOnNewsList(query, 1)[0];

            NewsDTO news = new NewsDTO()
            {
                Title = newsSPItem.Title,
                NavigateUrl = web.Url + "/Lists/News/DispForm.aspx?ID=" + newsSPItem["ID"],
                ShortDescription = newsSPItem["Short Description"].ToString(),
                Content = newsSPItem["Content"].ToString(),
                ImageUrl = newsSPItem["Picture"].ToString(),
                CreatedBy = newsSPItem["Author"].ToString().Substring(3),
                Created = newsSPItem["Created"].ToString(),
                Category = newsSPItem["Category"].ToString()
            };

            news.ImageUrl = news.ImageUrl.Remove(news.ImageUrl.IndexOf(','));
            news.Category = ProcessSPCategoriesString(news.Category);

            return news;
        }

        private string ProcessSPCategoriesString(string spCategories)
        {
            string categories = "";
            int start = 0, end = 0;

            while (true)
            {
                start = spCategories.IndexOf(";#", end);
                end = spCategories.IndexOf(";#", start + 2);
                if (end == -1)
                {
                    categories += spCategories.Substring(start + 2);
                    break;
                }
                else
                    categories += spCategories.Substring(start + 2, end - start -2) + ", ";

                end += 2;
            }

            return categories;
        }

        public NewsStatisticsDTO GetNewsStatistics()
        {
            NewsStatisticsDTO newsStats = new NewsStatisticsDTO();

            newsStats.AddedToday = GetNumberOfTodayAddedNews();
            newsStats.AddedInLastWeek = GetNumberOfLastWeekAddedNews();

            int totalNewsNum = GetTotalNewsNumber();
            newsStats.AveragePerDay = GetAverageNewsNumPerDay(totalNewsNum);
            newsStats.TotalNews = totalNewsNum.ToString();

            List<NewsNumberInCategoryDTO> categoriesWithNewsNum = GetCategoriesWithNewsNumberOrderedByDesc();
            newsStats.LeastNewsInCategory = categoriesWithNewsNum.Last().CategoryName + " (" + categoriesWithNewsNum.Last().NumberOfNews + ")";
            newsStats.MostNewsInCategory = categoriesWithNewsNum.First().CategoryName + " (" + categoriesWithNewsNum.First().NumberOfNews + ")";

            SPListItem latestNews = GetLatestNewsSPItem();
            newsStats.LatestNewsTitle = latestNews["Title"].ToString();
            newsStats.LatestNewsUrl = web.Url + "/Lists/News/DispForm.aspx?ID=" + latestNews["ID"];

            return newsStats;
        }

        private SPListItemCollection ExecuteQueryOnNewsList(string query, uint rowsLimit)
        {
            SPList newsSPList = web.Lists["News"];
            SPQuery CAML = new SPQuery();
            CAML.RowLimit = rowsLimit;
            CAML.Query = query;
            return newsSPList.GetItems(CAML);
        }

        private SPListItem GetLatestNewsSPItem()
        {
            SPListItemCollection news = ExecuteQueryOnNewsList("<OrderBy><FieldRef Name='Created' Ascending='False' /></OrderBy>", 1);
            return news[0];
        }

        private string GetNumberOfTodayAddedNews()
        {
            SPListItemCollection news = ExecuteQueryOnNewsList("<Where><Geq><FieldRef Name='Created' /><Value Type='DateTime'><Today OffsetDays='-1' /></Value></Geq></Where>", 0);
            return news.Count.ToString();
        }

        private string GetNumberOfLastWeekAddedNews()
        {
            SPListItemCollection news = ExecuteQueryOnNewsList("<Where><Geq><FieldRef Name='Created' /><Value Type='DateTime'><Today OffsetDays='-7' /></Value></Geq></Where>", 0);
            return news.Count.ToString();
        }

        private int GetTotalNewsNumber()
        {
            return web.Lists["News"].ItemCount;
        }

        private string GetAverageNewsNumPerDay(int totalNewsNum)
        {
            return ((int)(totalNewsNum / DateTime.Now.Subtract(GetDateOfFirstAddedNews()).TotalDays)).ToString();
        }

        private DateTime GetDateOfFirstAddedNews()
        {
            SPListItemCollection news = ExecuteQueryOnNewsList("<OrderBy><FieldRef Name='Created' Ascending='True' /></OrderBy>", 1);
            return DateTime.Parse(news[0]["Created"].ToString());
        }

        private List<NewsNumberInCategoryDTO> GetCategoriesWithNewsNumberOrderedByDesc()
        {
            CategoriesRepository categoriesRepo = new CategoriesRepository(web);
            SPListItemCollection categories = categoriesRepo.GetCategoriesList();
            SPListItemCollection allNews = web.Lists["News"].Items;

            List<NewsNumberInCategoryDTO> categoriesWithNewsNumber = new List<NewsNumberInCategoryDTO>();

            foreach (SPListItem category in categories)
            {
                int newsNumberInCurrentCategory = allNews.Cast<SPListItem>()
                                                  .Where(n => categories.Cast<SPListItem>()
                                                  .Any(c => n["Category"].ToString()
                                                  .Contains(category["Title"].ToString()))).Count();

                categoriesWithNewsNumber.Add(new NewsNumberInCategoryDTO()
                { CategoryName = category["Title"].ToString(), NumberOfNews = newsNumberInCurrentCategory });
            }

            return categoriesWithNewsNumber.OrderByDescending(c => c.NumberOfNews).ToList();
        }
    }
}
