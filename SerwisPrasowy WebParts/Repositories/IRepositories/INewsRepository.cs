using SerwisPrasowy_WebParts.DTO;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerwisPrasowy_WebParts.Repositories.IRepositories
{
    public interface INewsRepository
    {
        NewsDTO GetLatestNewsFromCategory(string categoryName);
        NewsStatisticsDTO GetNewsStatistics();
    }
}
