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
            try
            {
                string cmd = $"BACKUP DATABASE VentaGamer TO DISK = '{myString}'";


                _connection.GetConnection().Open();
                SqlCommand command = new SqlCommand(cmd, _connection.GetConnection());
                command.ExecuteNonQuery();
                _connection.GetConnection().Close();
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
                _connection.GetConnection().Open();
                string Query = string.Format("ALTER DATABASE [VentaGamer] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand command = new SqlCommand(Query, _connection.GetConnection());
                command.ExecuteNonQuery();
                string Query2 = $"USE MASTER RESTORE DATABASE [VentaGamer] FROM  DISK='{location}' WITH REPLACE;";
                SqlCommand command2 = new SqlCommand(Query2, _connection.GetConnection());
                command2.ExecuteNonQuery();

                string Query3 = string.Format("ALTER DATABASE [VentaGamer] SET MULTI_USER ");
                SqlCommand command3 = new SqlCommand(Query3, _connection.GetConnection());
                command3.ExecuteNonQuery();
                _connection.GetConnection().Close();
                return true;
            }
            catch (Exception)
            {
                _connection.GetConnection().Close();
                return false;
            }
        }
    }
}
