using BE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Bitacora
    {


        //ESCRITURA EN BITACORA
        public void BitacoraRegister(BE_RegistroBitacora registroBitacora)
        {
            using (SqlConnection connection = _connection.GetConnection())
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO BITACORA_REGISTROS (FECHA, MENSAJE, MODULO, ID_AUTOR) VALUES (@Fecha, @Mensaje, @Modulo, @ID)", connection))
                {
                    cmd.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.DateTime) { Value = registroBitacora.Fecha });
                    cmd.Parameters.Add(new SqlParameter("@Mensaje", SqlDbType.NVarChar, 255) { Value = registroBitacora.Mensaje });
                    cmd.Parameters.Add(new SqlParameter("@Modulo", SqlDbType.NVarChar, 100) { Value = registroBitacora.Modulo });
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int) { Value = registroBitacora.Autor });

                    cmd.ExecuteNonQuery();
                }
            }
        }


        //LECTURA DE BITACORA
        public List<BE_RegistroBitacora> getAll()
        {
            List<BE_RegistroBitacora> bitacora = new List<BE_RegistroBitacora>();

            using (SqlConnection conn = _connection.GetConnection())
            {
                conn.Open();
                using (SqlDataAdapter Da = new SqlDataAdapter("SELECT * FROM BITACORA_REGISTROS", conn))
                {
                    DataSet Ds = new DataSet();
                    Da.Fill(Ds);
                    DataTable dt = Ds.Tables[0];

                    foreach (DataRow dr in dt.Rows)
                    {
                        BE_RegistroBitacora registroBitacora = new BE_RegistroBitacora
                        {
                            Mensaje = dr["MENSAJE"].ToString(),
                            Autor = int.Parse(dr["ID_AUTOR"].ToString()),
                            Modulo = dr["MODULO"].ToString(),
                            Fecha = DateTime.Parse(dr["FECHA"].ToString())
                        };

                        registroBitacora.user = GetUserBitacora(registroBitacora.Autor);
                        bitacora.Add(registroBitacora);
                    }
                }
            }

            return bitacora;
        }



        //OBTENCION DE USERNAME POR ID DE BITACORA
        public string GetUserBitacora(int id)
        {
            using (SqlConnection connection = _connection.GetConnection())
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT USERNAME FROM USUARIOS WHERE ID = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt.Rows.Count > 0 ? dt.Rows[0]["USERNAME"].ToString() : string.Empty;
                    }
                }
            }
        }

    }
}
