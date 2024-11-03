using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BLL
{
    public class BLL_Productos
    {

        private DAL_Productos productos;


        public BLL_Productos()
        {
            productos = new DAL_Productos(); 
        }

        public List<Productos> GetProducts()
        {
            return productos.GetAllProducts();
        }

        public List<Productos> GetProductsByPagination(int pageNumber, int pageSize)
        {
            return productos.GetProductsByPagination(pageNumber,pageSize);

        }

        public int GetTotalProductsCount()
        {
            return productos.GetTotalProductsCount();
        }
    }
}
