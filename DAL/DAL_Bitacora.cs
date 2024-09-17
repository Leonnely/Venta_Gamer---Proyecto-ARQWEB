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

            _connection.GetConnection().Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO BITACORA_REGISTROS (FECHA, MENSAJE, MODULO, ID_AUTOR) values (@Fecha, @mensaje, @Modulo, @ID)", sqlConnection);
            cmd.Parameters.AddWithValue("@Fecha", registroBitacora.Fecha);
            cmd.Parameters.AddWithValue("@mensaje", registroBitacora.Mensaje);
            cmd.Parameters.AddWithValue("@Modulo", registroBitacora.Modulo);
            cmd.Parameters.AddWithValue("@ID", registroBitacora.Autor);
            cmd.ExecuteNonQuery();
            _connection.GetConnection().Close();
        }

        //LECTURA DE BITACORA
        public List<BE_RegistroBitacora> getAll()
        {
            _connection.GetConnection().Open();
            DataSet Ds = new DataSet();
            SqlDataAdapter Da = new SqlDataAdapter("Select * from BITACORA_REGISTROS", _connection.GetConnection());
            Da.Fill(Ds);
            _connection.GetConnection().Close();
            DataTable dt = Ds.Tables[0];
            BE_RegistroBitacora registroBitacora = new BE_RegistroBitacora();
            List<BE_RegistroBitacora> bitacora = new List<BE_RegistroBitacora>();
            foreach (DataRow dr in dt.Rows)
            {

                registroBitacora.Mensaje= dr["MENSAJE"].ToString();
                registroBitacora.Autor = int.Parse(dr["ID_AUTOR"].ToString());
                registroBitacora.Modulo = dr["MODULO"].ToString();
                registroBitacora.Fecha = DateTime.Parse(dr["FECHA"].ToString());

                registroBitacora.user = GetUserBitacora(registroBitacora.Autor);

                bitacora.Add(registroBitacora);
            }
            
            return bitacora;
            //return zDatos.Bitacora;
        }


        //OBTENCION DE USERNAME POR ID DE BITACORA
        public string GetUserBitacora(int id)
        {
            _connection.GetConnection().Open();
            SqlCommand cmd = new SqlCommand("Select USERNAME from USUARIOS where ID=@id", _connection.GetConnection());
            cmd.Parameters.AddWithValue("@id", id);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            _connection.GetConnection().Close();
            return dt.Rows[0]["USERNAME"].ToString();
        }
    }
}
