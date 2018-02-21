using SerwisPrasowy_WebParts.IViews;
using SerwisPrasowy_WebParts.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls.WebParts;

namespace SerwisPrasowy_WebParts.Base
{
    public class BaseWebPart<TPresenter> : WebPart, IBaseView where TPresenter : BasePresenter, new()
    {
        protected TPresenter Presenter;

        public BaseWebPart()
        {
            AttachPresenter();
        }

        public void AttachPresenter()
        {
            Presenter = new TPresenter { View = this };
        }
    }
}
