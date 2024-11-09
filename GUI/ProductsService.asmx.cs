using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BE;
using BLL;

namespace GUI
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ProductsService : System.Web.Services.WebService
    {
        [WebMethod]
        public List<BEProductos> GetProducts()
        {
            BLL_Productos productService = new BLL_Productos();
            return productService.GetProducts();
        }

        [WebMethod]
        public List<Productos> GetProductsByPagination(int pageNumber, int pageSize)
        {
            BLL_Productos productService = new BLL_Productos();
            return productService.GetProductsByPagination(pageNumber, pageSize);
        }

        [WebMethod]
        public int GetTotalProductsCount()
        {
            BLL_Productos productService = new BLL_Productos();
            return productService.GetTotalProductsCount();
        }

    }

}
