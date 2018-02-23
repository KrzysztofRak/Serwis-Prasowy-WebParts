using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerwisPrasowy_WebParts.DTO
{
    public class NewsStatisticsDTO
    {
        public string AddedToday { get; set; }
        public string AveragePerDay { get; set; }
        public string AddedInLastWeek { get; set; }
        public string TotalNews { get; set; }
        public string LeastNewsInCategory { get; set; }
        public string MostNewsInCategory { get; set; }
        public string LatestNewsTitle { get; set; }
        public string LatestNewsUrl { get; set; }
    }
}
