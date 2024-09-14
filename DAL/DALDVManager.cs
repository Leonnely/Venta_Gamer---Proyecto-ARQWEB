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


        SqlConnection Conection = new SqlConnection("Data Source=localhost;Initial Catalog=VentaGamer;Integrated Security=True");

        public DataTable ObtenerDatatable(string nombreTable)
        {
            DataTable dataTable = new DataTable();


            Conection.Open();

            try
            {
                string selectQuery = $"SELECT * FROM {nombreTable}";

                using (SqlCommand selectCommand = new SqlCommand(selectQuery, Conection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(selectCommand))
                    {
                        adapter.Fill(dataTable);
                    }
                }
                Conection.Close();
            }
            catch (Exception ex)
            {
                // Maneja la excepción adecuadamente, como registrarla o lanzarla nuevamente
                Console.WriteLine("Error al obtener el DataTable: " + ex.Message);
            }


            return dataTable;
        }
        public DataTable ObtenerDatatableConcatenada(string nombreTable)
        {
            DataTable dataTable = new DataTable();



            try
            {
                Conection.Open();
                using (SqlCommand command = new SqlCommand("InsertarDatosEnTablaReboteA", Conection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TableName", nombreTable);

                    // Ejecutar el procedimiento almacenado para copiar datos en TablaRebote
                    command.ExecuteNonQuery();

                    // Luego, ejecutar un SELECT para obtener los datos de TablaRebote
                    string selectQuery = "SELECT * FROM TablaRebote";

                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, Conection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(selectCommand))
                        {
                            adapter.Fill(dataTable);


                        }
                    }
                }
                Conection.Close();
            }
            catch (Exception ex)
            {
                Conection.Close();

                // Maneja la excepción adecuadamente, como registrarla o lanzarla nuevamente
                Console.WriteLine("Error al obtener el DataTable: " + ex.Message);
            }


            return dataTable;
        }

        public void GuardarTable(DataTable DtToSave, string tablaSobreescribir)
        {

            Conection.Open();
            SqlCommand cmd2 = new SqlCommand($"TRUNCATE TABLE {tablaSobreescribir} ", Conection);
            cmd2.ExecuteNonQuery();
            foreach (DataRow row in DtToSave.Rows)
            {

                SqlCommand cmd = new SqlCommand($"SET IDENTITY_INSERT {tablaSobreescribir} ON", Conection);
                cmd.ExecuteNonQuery();

                string insertQuery = $"INSERT INTO {tablaSobreescribir} (HashValue, id) VALUES (@HashValue,@Id)";

                using (SqlCommand command = new SqlCommand(insertQuery, Conection))
                {
                    command.Parameters.AddWithValue("@HashValue", row["HashValue"]);
                    command.Parameters.AddWithValue("@Id", row["id"]);

                    command.ExecuteNonQuery();
                }
            }
            Conection.Close();

        }

    }
}
