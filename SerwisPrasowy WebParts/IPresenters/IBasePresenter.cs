using SerwisPrasowy_WebParts.IViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerwisPrasowy_WebParts.IPresenters
{
    public interface IBasePresenter
    {
        IBaseView View { get; set; }
    }
}
