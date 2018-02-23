using Microsoft.SharePoint;
using SerwisPrasowy_WebParts.Base;
using SerwisPrasowy_WebParts.DTO;
using SerwisPrasowy_WebParts.IViews;
using SerwisPrasowy_WebParts.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;

namespace SerwisPrasowy_WebParts.WebParts.StatystykiNewsow
{
    [ToolboxItemAttribute(false)]
    public partial class StatystykiNewsow : BaseWebPart<NewsStatisticsPresenter>, INewsStatisticsView
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public StatystykiNewsow()
        {
        }

        public List<NewsStatisticsDTO> NewsStatisticsSource
        {
            set
            {
                FormViewNewsStatistics.DataSource = value;
                FormViewNewsStatistics.DataBind();
            }
        }
            
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter.LoadStatistics();
        }
    }
}
