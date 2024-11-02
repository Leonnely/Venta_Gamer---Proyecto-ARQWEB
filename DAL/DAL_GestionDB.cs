using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_GestionDB
    {
        public bool CreateDatabase(string myString)
        {
            string cmdText = $"BACKUP DATABASE VentaGamer TO DISK = '{myString}'";

            try
            {
                using (SqlConnection connection = _connection.GetConnection())
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(cmdText, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool RestoreDatabase(string location)
        {
            try
            {
                using (var connection = _connection.GetConnection())
                {
                    connection.Open();

                    using (var command = new SqlCommand("ALTER DATABASE [VentaGamer] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;", connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (var command2 = new SqlCommand($"USE MASTER; RESTORE DATABASE [VentaGamer] FROM DISK='{location}' WITH REPLACE;", connection))
                    {
                        command2.ExecuteNonQuery();
                    }

                    using (var command3 = new SqlCommand("ALTER DATABASE [VentaGamer] SET MULTI_USER;", connection))
                    {
                        command3.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

    }
}
