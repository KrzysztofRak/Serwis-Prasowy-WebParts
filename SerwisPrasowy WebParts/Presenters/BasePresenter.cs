using Microsoft.SharePoint;
using SerwisPrasowy_WebParts.IPresenters;
using SerwisPrasowy_WebParts.IViews;
using SerwisPrasowy_WebParts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerwisPrasowy_WebParts.Presenters
{
    public abstract class BasePresenter<TView> : BasePresenter where TView : IBaseView
    {
        public new TView View
        {
            get
            {
                return (TView)base.View;
            }
            set
            {
                base.View = value;
            }
        }
    }

    public class BasePresenter : IBasePresenter
    {
        public IBaseView View { get; set; }

        public BasePresenter()
        {
        }

        private SPWeb myWebInstance;
        private CategoriesRepository categoriesRepo;
        private NewsRepository newsRepo;

        protected SPWeb MyWebInstance
        {
            set { myWebInstance = value; }
            get
            {
                if (myWebInstance == null)
                    myWebInstance = GetMyWebInstance();
                return myWebInstance;
            }
        }

        protected CategoriesRepository CategoriesRepo
        {
            set { categoriesRepo = value; }
            get
            {
                if (categoriesRepo == null)
                    categoriesRepo = new CategoriesRepository(MyWebInstance);
                return categoriesRepo;
            }
        }

        protected NewsRepository NewsRepo
        {
            set { newsRepo = value; }
            get
            {
                if (newsRepo == null)
                    newsRepo = new NewsRepository(MyWebInstance);
                return newsRepo;
            }
        }

        private SPWeb GetMyWebInstance()
        {
            using (SPSite site = new SPSite("http://devlab.billennium.pl/sites/serwis-prasowy"))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    return web;
                }
            }
        }
    }
}
