using DataTransferObject.DTO;
using Microsoft.SharePoint;
using SerwisPrasowy_WebParts.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerwisPrasowy_WebParts.Repositories
{
    class NewsNumberInCategoryDTO
    {
        public string CategoryName { get; set; }
        public int NumberOfNews { get; set; }
    }

    class NewsRepository : INewsRepository
    {
        SPWeb web;

        public NewsRepository(SPWeb web)
        {
            this.web = web;
        }

        public SPListItem GetLatestNews(int categoryId)
        {
            SPList newsList = web.Lists["News"];
            SPQuery CAML = new SPQuery();
            CAML.RowLimit = 1;
            CAML.Query = "<OrderBy><FieldRef Name='Created' Ascending='False' /></OrderBy>";

            return newsList.GetItems(CAML)[0];
            //SPListItem news = newsList.GetItems(CAML)[0];
            //NewsDTO newsDTO = new NewsDTO()
            //{
            //    Title = news.Title,
            //    ShortDescription = news["Short Description"].ToString(),
            //    Content = news["Content"].ToString(),
            //    PictureUrl = news["Picture"].ToString(),
            //    CreatedBy = news["CreatedBy"].ToString(),
            //    Created = news["Created"].ToString()
            //};

            //return newsDTO;
        }

        public NewsStatisticsDTO GetNewsStatistics()
        {
            CategoriesRepository categoriesRepo = new CategoriesRepository(web);
            SPListItemCollection categories = categoriesRepo.GetCategoriesList();
            NewsStatisticsDTO newsStats = new NewsStatisticsDTO();
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

        public string GetNumberOfTodayAddedNews()
        {
            SPListItemCollection news = ExecuteQueryOnNewsList("<Query><Where><Geq><FieldRef Name='Created' /><Value Type='DateTime'><Today OffsetDays='-1' /></Value></Geq></Where></Query>", 0);
            return news.Count.ToString();
        }

        public string GetNumberOfLastWeekAddedNews()
        {
            SPListItemCollection news = ExecuteQueryOnNewsList("<Query><Where><Geq><FieldRef Name='Created' /><Value Type='DateTime'><Today OffsetDays='-1' /></Value></Geq></Where></Query>", 0);
            return news.Count.ToString();
        }

        public int GetTotalNewsNumber()
        {
            return web.Lists["News"].ItemCount;
        }

        public string GetDateOfFirstAddedNews()
        {
            SPListItemCollection news = ExecuteQueryOnNewsList("<Query><OrderBy><FieldRef Name='Created' Ascending='True' /></OrderBy></Query>", 1);
            return news[0]["Created"].ToString();
        }

        public List<NewsNumberInCategoryDTO> GetCategoriesWithNewsNumberOrderedByDesc()
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
