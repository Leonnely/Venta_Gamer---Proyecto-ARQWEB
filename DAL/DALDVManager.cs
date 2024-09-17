using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALDVManager
    {
        public DALDVManager() { }


        public DataTable ValidarDVH(string nombreTabla)
        {
            try
            {
                
                _connection.GetConnection().Open();

                SqlCommand command = new SqlCommand("ValidarDVH", _connection.GetConnection());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Tabla", nombreTabla);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar DVH: " + ex.Message);
            }
            finally
            {
                if (_connection.GetConnection().State == ConnectionState.Open)
                {
                    _connection.GetConnection().Close();
                }
            }
        }

        public bool ActualizarTablaDVH(string nombreTabla)
        {
            SqlConnection connection = _connection.GetConnection(); // Asegura que obtienes la misma instancia de conexión

            try
            {
                // Abre la conexión solo si está cerrada
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand("DV_ActualizarTabla", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NombreTabla", nombreTabla);

                    // Ejecuta la consulta
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que ocurra
                throw new Exception("Error actualizando DVH: " + ex.Message, ex);
            }
            finally
            {
                // Asegura que la conexión se cierre adecuadamente
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

    }
}
