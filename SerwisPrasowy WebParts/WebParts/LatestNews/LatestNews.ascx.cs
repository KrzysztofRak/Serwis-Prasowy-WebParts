using SerwisPrasowy_WebParts.DTO;
using Microsoft.SharePoint;
using SerwisPrasowy_WebParts.Base;
using SerwisPrasowy_WebParts.IViews;
using SerwisPrasowy_WebParts.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Web.UI.WebControls.WebParts;
using System.Collections;
using System.Web.UI.WebControls;

namespace SerwisPrasowy_WebParts.WebParts.OstatnieNewsy
{
    [ToolboxItemAttribute(false)]
    public partial class OstatnieNewsy : BaseWebPart<LatestNewsPresenter>, ILatestNewsView
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public OstatnieNewsy()
        {
        }

        public SPListItemCollection CategoriesListSource
        {
            set
            {
                DropDownListCategories.DataSource = value;
                DropDownListCategories.DataBind();
            }
        }

        public List<NewsDTO> LatestNewsSource
        {
            set
            {
                FormViewLatestNews.DataSource = value;
                FormViewLatestNews.DataBind();
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter.LoadCategoriesList();
            Presenter.LoadLatestNews("");
        }

        protected void DropDownListCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            Presenter.LoadLatestNews(DropDownListCategories.SelectedValue);
        }
    }
}
