using Microsoft.SharePoint;
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
        string SelectedCategoryId { get; }

        string NewsTitle { set; }
        string NewsUrl { set; }
        string ShortDescription { set; }
        string NewsDescription { set; }
        string ImageUrl { set; }
        string AuthorName { set; }
        string Date { set; }
        string Categories { set; }
    }
}
