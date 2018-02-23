using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerwisPrasowy_WebParts.Repositories.IRepositories
{
    public interface ICategoriesRepository
    {
        SPListItemCollection GetCategoriesList();
    }
}
