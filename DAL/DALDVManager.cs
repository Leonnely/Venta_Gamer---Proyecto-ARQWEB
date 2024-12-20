﻿using System;
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

        public List<DataTable> CalcularDV(string tableName)
        {
            try
            {
                List<DataTable> list = new List<DataTable>();
                _connection.GetConnection().Open();

                //CALCULO LA TABLA ORIGINAL 
                SqlCommand command = new SqlCommand("CalcularDVH", _connection.GetConnection());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Tabla", tableName);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                list.Add(dt);

                string query = $"SELECT * FROM [{tableName}_DVH]";
                SqlCommand command2 = new SqlCommand(query, _connection.GetConnection());
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(command2);
                da2.Fill(dt2);
                list.Add(dt2);

                return list;
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
    }
}
