using Microsoft.SharePoint;
using SerwisPrasowy_WebParts.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SerwisPrasowy_WebParts.IViews
{
    public interface ILatestNewsView : IBaseView
    {
        SPListItemCollection CategoriesListSource { set; }
        List<NewsDTO> LatestNewsSource { set; }
    }
}
