using DataTransferObject.DTO;
using Microsoft.SharePoint;
using SerwisPrasowy_WebParts.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerwisPrasowy_WebParts.Repositories
{
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

            SPList newsSPList = web.Lists["News"];
            SPQuery CAML = new SPQuery();

            CAML.Query = "<Where><Geq><FieldRef Name='Created' /><Value Type='DateTime'><Today OffsetDays='-1' /></Value></Geq></Where><OrderBy><FieldRef Name='Created' Ascending='False' /></OrderBy>";
            newsStats.AddedToday = newsSPList.GetItems(CAML).Count.ToString();

            CAML.Query = "<Where><Geq><FieldRef Name='Created' /><Value Type='DateTime'><Today OffsetDays='-7' /></Value></Geq></Where><OrderBy><FieldRef Name='Created' Ascending='False' /></OrderBy>";
            newsStats.AddedInLastWeek = newsSPList.GetItems(CAML).Count.ToString();

            newsStats.TotalNews = newsSPList.ItemCount.ToString();

            int leastInCategory = 0;
            int mostInCategory = 0;
            string leastInCategoryName = "";
            string mostInCategoryName = "";

            bool firstLoop = true;
            foreach(SPListItem cat in categories)
            {
                CAML.Query = "<Where><Contains><FieldRef Name='Category' /><Value Type='Lookup'>" + cat.Title + "</Value></Contains></Where>";
                if(firstLoop)
                {
                    firstLoop = false;
                    leastInCategory = newsSPList.GetItems(CAML).Count;
                    mostInCategory = leastInCategory;
                    leastInCategoryName = cat.Title;
                    mostInCategoryName = cat.Title;
                }
                else
                {
                    if(newsSPList.GetItems(CAML).Count < leastInCategory)
                    {
                        leastInCategory = newsSPList.GetItems(CAML).Count;
                        leastInCategoryName = cat.Title;
                    }
                    else if(newsSPList.GetItems(CAML).Count > mostInCategory)
                    {
                        mostInCategory = leastInCategory;
                        mostInCategoryName = cat.Title;
                    }
                }
            }

            newsStats.LeastNewsInCategory = leastInCategoryName + " (" + leastInCategory + ")";
            newsStats.MostNewsInCategory = mostInCategoryName + " (" + mostInCategoryName + ")";

            CAML.Query = "<Where><Geq><FieldRef Name='Created' /><Value Type='DateTime'><Today OffsetDays='-7' /></Value></Geq></Where><OrderBy><FieldRef Name='Created' Ascending='False' /></OrderBy>";
            newsStats.AddedInLastWeek = newsSPList.GetItems(CAML).Count.ToString();

            return newsStats;
        }

        private SPListItemCollection GetAllNews()
        {
            return web.Lists["News"].Items;
        }
    }
}
