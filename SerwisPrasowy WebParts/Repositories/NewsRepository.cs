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

        public string GetMostPopularCategory()
        {
            CategoriesRepository categoriesRepo = new CategoriesRepository(web);
            SPListItemCollection categories = categoriesRepo.GetCategoriesList();
            SPListItemCollection news = GetAllNews();

            List<NewsNumberInCategoryDTO> newsNumberInSpecifiedCategories = new List<NewsNumberInCategoryDTO>();

            foreach (SPListItem category in categories)
            {
                int newsNumberInCurrentCategory = news.Cast<SPListItem>()
                                                  .Where(n => categories.Cast<SPListItem>()
                                                  .Any(c => n["Category"].ToString()
                                                  .Contains(category["Title"].ToString()))).Count();

                newsNumberInSpecifiedCategories.Add(new NewsNumberInCategoryDTO()
                { CategoryName = category["Title"].ToString(), NumberOfNews = newsNumberInCurrentCategory });
            }


            string mostPopularCategory = newsNumberInSpecifiedCategories.OrderByDescending(c => c.NumberOfNews)
                                                                        .First().CategoryName;
            return mostPopularCategory;
        }

        private SPListItemCollection GetAllNews()
        {
            return web.Lists["News"].Items;
        }
    }
}
