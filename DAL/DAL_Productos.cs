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

        public List<BE_Productos> GetAllProducts()
        {
            List<BE_Productos> products = new List<BE_Productos>();


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
                            BE_Productos product = new BE_Productos
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

        public void AddProduct(BE_Productos product)
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

        public List<BE_Productos> GetProductsByPagination(int pageNumber, int pageSize)
        {
            List<BE_Productos> products = new List<BE_Productos>();
            int offset = (pageNumber - 1) * pageSize;
            using (SqlConnection connection = _connection.GetConnection())
            {
                connection.Open();
                string query = @"
                    SELECT Category, Title, Price 
                    FROM Products
                    ORDER BY Title -- Es importante tener un orden definido para la paginación
                    OFFSET @Offset ROWS 
                    FETCH NEXT @PageSize ROWS ONLY";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Offset", offset);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BE_Productos product = new BE_Productos
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

        public int GetTotalProductsCount()
        {
            int count = 0;

            using (SqlConnection connection = _connection.GetConnection())
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Products";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    count = (int)command.ExecuteScalar(); // Obtiene el total de productos
                }
            }

            return count;
        }

    }
}
