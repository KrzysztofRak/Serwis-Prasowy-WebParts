using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerwisPrasowy_WebParts.IViews
{
    public interface INewsStatisticsView : IBaseView
    {
        string NewsNumAddedToday { set; }
        string AveragePerDay { set; }
        string NewsNumAddedInLastWeek { set; }
        string TotalNewsNum { set; }
        string CategoryWithLeastNews { set; }
        string CategoryWithMostNews { set; }
        string MostPopularNewsTitle { set; }
        string MostPopularNewsUrl { set; }
    }
}
