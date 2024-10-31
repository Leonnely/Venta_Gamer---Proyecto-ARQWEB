using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class DAL_Productos
    {

        public List<BEProductos> GetAllProducts()
        {
            List<BEProductos> products = new List<BEProductos>();


            // Abre la conexión utilizando la instrucción using para asegurar que se cierra automáticamente
            using (SqlConnection connection = _connection.GetConnection())
            {
                connection.Open();
                string query = "SELECT Category, Title, Price FROM Products";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BEProductos product = new BEProductos
                            {
                                Category = reader["Category"].ToString(),
                                Title = reader["Title"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"])
                            };
                            products.Add(product);
                        }
                    }
                }
            }
            return products;

        }

        public void AddProduct(BEProductos product)
        {
            using (SqlConnection connection = _connection.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Products (Category, Title, Price) VALUES (@Category, @Title, @Price)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Category", product.Category);
                    command.Parameters.AddWithValue("@Title", product.Title);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
