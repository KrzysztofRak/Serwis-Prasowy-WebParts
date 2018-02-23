using SerwisPrasowy_WebParts.DTO;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerwisPrasowy_WebParts.IViews
{
    public interface INewsStatisticsView : IBaseView
    {
        List<NewsStatisticsDTO> NewsStatisticsSource { set; }
    }
}
