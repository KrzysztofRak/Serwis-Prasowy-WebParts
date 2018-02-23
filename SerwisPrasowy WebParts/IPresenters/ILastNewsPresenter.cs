using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerwisPrasowy_WebParts.IPresenters
{
    public interface ILastNewsPresenter
    {
        void LoadCategoriesList();
        void LoadLatestNews(string categoryName);
    }
}
