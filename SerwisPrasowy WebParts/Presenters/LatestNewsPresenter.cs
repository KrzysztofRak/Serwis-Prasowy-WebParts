using Microsoft.SharePoint;
using SerwisPrasowy_WebParts.DTO;
using SerwisPrasowy_WebParts.IPresenters;
using SerwisPrasowy_WebParts.IViews;
using SerwisPrasowy_WebParts.Presenters;
using SerwisPrasowy_WebParts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerwisPrasowy_WebParts.Presenters
{
    public class LatestNewsPresenter : BasePresenter<ILatestNewsView>, ILastNewsPresenter
    {
        public LatestNewsPresenter()
        {
        }

        public void LoadCategoriesList()
        {
            View.CategoriesListSource = CategoriesRepo.GetCategoriesList();
        }

        public void LoadLatestNews(string categoryName)
        {
            View.LatestNewsSource = new List<NewsDTO> { NewsRepo.GetLatestNewsFromCategory(categoryName) };
        }
    }
}