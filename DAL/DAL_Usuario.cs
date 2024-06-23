using BE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Usuario
    {
        

        public int role;
        public int id;

        SqlConnection sqlConnection = new SqlConnection("Data Source=localhost;Initial Catalog=VentaGamer;Integrated Security=True");


        //INICIO DE SESION
        public bool Login(string username, string password)
        {
            BE_Usuario user = new BE_Usuario(username, password, 0);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios WHERE Username=@username",sqlConnection);
            cmd.Parameters.AddWithValue("@username", username);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            sqlConnection.Close();
            if (dt.Rows.Count > 0)
            {
                user.Role = int.Parse(dt.Rows[0]["ROL"].ToString()); 
                user.id= int.Parse(dt.Rows[0]["ID"].ToString());
                role =user.Role;
                id = user.id;
                return true;
            }
            else
            {
                return false;
            }
            //BE_Usuario user = new BE_Usuario(username, password,0);
            //foreach (var usuario in zDatos.users)
            //{
            //    if (usuario.Username == username && usuario.Password == password)
            //    {
            //        user.Role= usuario.Role;
            //        role=user.Role;
            //        return true;
            //    }
            //}
            //return false;

        }

        
    }
}
