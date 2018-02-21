using SerwisPrasowy_WebParts.Repositories.IRepositories;
using Microsoft.SharePoint;
using System.Data;

namespace SerwisPrasowy_WebParts.Repositories
{
    class CategoriesRepository : ICategoriesRepository
    {
        private SPWeb web;

        public CategoriesRepository(SPWeb web)
        {
            this.web = web;
        }

        public SPListItemCollection GetCategoriesList()
        {
            SPList categoriesList = web.Lists["News Categories"];
            SPQuery CAML = new SPQuery();
            CAML.Query = "<OrderBy><FieldRef Name='Title' Ascending='True' /></OrderBy>";

            return categoriesList.GetItems(CAML);
        }
    }
}
