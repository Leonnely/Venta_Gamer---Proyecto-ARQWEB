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
        public bool block;

        SqlConnection sqlConnection = new SqlConnection("Data Source=localhost;Initial Catalog=VentaGamer;Integrated Security=True");


        //INICIO DE SESION
        public bool Login(string username, string password)
        {
            BE_Usuario user = new BE_Usuario(username, password, 0);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM USUARIOS WHERE USERNAME=@username AND PASSWORD=@password",sqlConnection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            sqlConnection.Close();
            if (dt.Rows.Count > 0 )
            {
                user.Role = int.Parse(dt.Rows[0]["ROL"].ToString()); 
                user.id= int.Parse(dt.Rows[0]["ID"].ToString());
                user.block = bool.Parse(dt.Rows[0]["IsBlock"].ToString());
                role =user.Role;
                id = user.id;
                block = user.block;

                return true;
            }
            else
            {
                return false;
            }
           
        }

        public bool userBlock(string Username)
        {
            int userid=GetUserID(Username);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("BlockUser", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", userid);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false ;
            }
            
            
        }

        public int GetUserID(string username)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("Select ID from USUARIOS where USERNAME=@username", sqlConnection);
            cmd.Parameters.AddWithValue("@username", username);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            sqlConnection.Close();
            return int.Parse(dt.Rows[0]["ID"].ToString());
        }



        public void updatePassword(string Username, string Password)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE USUARIOS SET PASSWORD=@Password WHERE USERNAME=@Username", sqlConnection);
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

    }
}
