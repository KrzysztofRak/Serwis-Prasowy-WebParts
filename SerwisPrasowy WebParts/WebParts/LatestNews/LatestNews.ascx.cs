using DataTransferObject.DTO;
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
                DropDownListCategories.DataValueField = "ID";
                DropDownListCategories.DataTextField = "Title";
                DropDownListCategories.DataBind();
                ListItem allCategories = new ListItem("Wszystkie kategorie", "-1");
                allCategories.Selected = true;
                DropDownListCategories.Items.Add(allCategories);
            }
        }

        public string SelectedCategoryId
        {
            get { return DropDownListCategories.SelectedValue; }
        }

        public string NewsTitle
        {
            set { LinkBtnNewsTitle.Text = value; }
        }

        public string NewsUrl
        {
            set { LinkBtnNewsTitle.PostBackUrl = value; }
        }

        public string ShortDescription
        {
            set { LabelShortDescription.Text = value; }
        }

        public string NewsDescription
        {
            set { LabelDescription.Text = value; }
        }

        public string ImageUrl
        {
            set { ImageNews.ImageUrl = value; }
        }

        public string AuthorName
        {
            set { LabelAuthor.Text = value; }
        }

        public string Date
        {
            set { LabelCreated.Text = value; }
        }

        public string Categories
        {
            set { LabelCategories.Text = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter.LoadCategoriesList();
        }

        protected void DropDownListCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            Presenter.LoadNews();
        }
    }
}
