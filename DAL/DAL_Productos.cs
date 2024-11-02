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

        public List<Productos> GetAllProducts()
        {
            List<Productos> products = new List<Productos>();


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
                            Productos product = new Productos
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

    }
}
