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
        //    NewsRepository newsRepo = new NewsRepository(MyWebInstance);

          //  View.NewsNumAddedToday = newsRepo.MostNewsInCat();
        }
    }
}
