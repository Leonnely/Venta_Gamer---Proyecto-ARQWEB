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

        SqlConnection sqlConnection = new SqlConnection("Data Source=localhost;Initial Catalog=VentaGamer;Integrated Security=True");

        public bool CreateDatabase(string myString)
        {
            try
            {
                string cmd = $"BACKUP DATABASE VentaGamer TO DISK = '{myString}'";


                sqlConnection.Open();
                SqlCommand command = new SqlCommand(cmd, sqlConnection);
                command.ExecuteNonQuery();
                sqlConnection.Close();
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
                sqlConnection.Open();
                string Query = string.Format("ALTER DATABASE [VentaGamer] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand command = new SqlCommand(Query, sqlConnection);
                command.ExecuteNonQuery();
                string Query2 = $"USE MASTER RESTORE DATABASE [VentaGamer] FROM  DISK='{location}' WITH REPLACE;";
                SqlCommand command2 = new SqlCommand(Query2, sqlConnection);
                command2.ExecuteNonQuery();

                string Query3 = string.Format("ALTER DATABASE [VentaGamer] SET MULTI_USER");
                SqlCommand command3 = new SqlCommand(Query3, sqlConnection);
                command.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            catch (Exception)
            {
                sqlConnection.Close();
                return false;
            }
        }
    }
}
