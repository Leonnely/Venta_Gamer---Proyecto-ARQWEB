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

        public List<BE_Productos> GetProducts()
        {
            return productos.GetAllProducts();
        }

        public void AddProduct(BE_Productos product)
        {
            productos.AddProduct(product);
        }

        public List<BE_Productos> GetProductsByPagination(int pageNumber, int pageSize)
        {
            return productos.GetProductsByPagination(pageNumber,pageSize);

        }

        public int GetTotalProductsCount()
        {
            return productos.GetTotalProductsCount();
        }

        public void DeleteProduct(int productId)
        {
            productos.DeleteProduct(productId);
        }


        public void UpdateProduct(BE_Productos product)
        {
            productos.UpdateProduct(product);  // Llama al DAL para actualizar el producto
        }


    }

}
