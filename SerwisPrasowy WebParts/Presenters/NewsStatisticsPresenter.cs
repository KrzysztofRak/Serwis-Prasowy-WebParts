using SerwisPrasowy_WebParts.IPresenters;
using SerwisPrasowy_WebParts.IViews;
using SerwisPrasowy_WebParts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerwisPrasowy_WebParts.Presenters
{
    public class NewsStatisticsPresenter : BasePresenter<INewsStatisticsView>, INewsStatisticsPresenter
    {
        public void LoadStatistics()
        {
            NewsRepository newsRepo = new NewsRepository(MyWebInstance);
            List<NewsNumberInCategoryDTO> categoriesWithNewsNum = newsRepo.GetCategoriesWithNewsNumberOrderedByDesc();
            NewsNumberInCategoryDTO minNews = categoriesWithNewsNum.First();
            NewsNumberInCategoryDTO maxNews = categoriesWithNewsNum.Last();

            View.CategoryWithLeastNews = minNews.CategoryName + " (" + minNews.NumberOfNews + ")";
            View.CategoryWithMostNews = maxNews.CategoryName + " (" + maxNews.NumberOfNews + ")";

            View.NewsNumAddedToday = newsRepo.GetNumberOfTodayAddedNews();
            View.NewsNumAddedInLastWeek = newsRepo.GetNumberOfLastWeekAddedNews();
            View.TotalNewsNum = newsRepo.GetTotalNewsNumber().ToString();
         //   View.TotalNewsNum = newsRepo.GetDateOfFirstAddedNews();
        }
    }
}
