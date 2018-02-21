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
         //   CategoriesRepository categoriesRepo = new CategoriesRepository(MyWebInstance);
    //        View.CategoriesListSource = categoriesRepo.GetCategoriesList();
        }

        public void LoadNews()
        {

        }
    }
}