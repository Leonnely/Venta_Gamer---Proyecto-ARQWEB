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
        public int language;


        //INICIO DE SESION
        public bool Login(string username, string password)
        {
            BE_Usuario user = new BE_Usuario(username, password, 0, 0);
            _connection.GetConnection().Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM USUARIOS WHERE USERNAME=@username AND PASSWORD=@password", _connection.GetConnection());
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            _connection.GetConnection().Close();
            if (dt.Rows.Count > 0 )
            {
                user.Role = int.Parse(dt.Rows[0]["ROL"].ToString()); 
                user.id= int.Parse(dt.Rows[0]["ID"].ToString());
                user.block = bool.Parse(dt.Rows[0]["IsBlock"].ToString());
                user.LanguageID = int.Parse(dt.Rows[0]["LanguageID"].ToString());
                role =user.Role;
                id = user.id;
                block = user.block;
                language = user.LanguageID;

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
            _connection.GetConnection().Open();
            SqlCommand cmd = new SqlCommand("BlockUser", _connection.GetConnection());
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
            _connection.GetConnection().Open();
            SqlCommand cmd = new SqlCommand("Select ID from USUARIOS where USERNAME=@username", _connection.GetConnection());
            cmd.Parameters.AddWithValue("@username", username);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            _connection.GetConnection().Close();
            return int.Parse(dt.Rows[0]["ID"].ToString());
        }



        public void updatePassword(string Username, string Password)
        {
            using (var connection = _connection.GetConnection())
            {
                connection.Open(); 
                using (SqlCommand cmd = new SqlCommand("UPDATE USUARIOS SET PASSWORD=@Password WHERE USERNAME=@Username", connection))
                {
                    cmd.Parameters.AddWithValue("@Username", Username);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.ExecuteNonQuery(); 
                }
            }

           
        }

        public void updateLanguage(int languageId, int userId)
        {

            int userID = userId;

            using (SqlConnection connection = _connection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand("UPDATE USUARIOS SET LanguageID=@LanguageID WHERE ID=@userID;", connection))
                {
                    command.Parameters.AddWithValue("@LanguageID", languageId);
                    command.Parameters.AddWithValue("@userID", userID);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public bool Register(string username, string password, int role)
        {
            try
            {
                using (SqlConnection connection = _connection.GetConnection())
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO USUARIOS (USERNAME, PASSWORD, ROL, LanguageID, IsBlock) VALUES (@Username, @Password, @Role, @LanguageID, @IsBlock)", connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Role", role);
                        cmd.Parameters.AddWithValue("@LanguageID", 1);
                        cmd.Parameters.AddWithValue("@IsBlock", false);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // Retorna true si la inserción fue exitosa
                    }
                }
            }
            catch (Exception)
            {
                return false; // Retorna false si ocurre algún error
            }
        }

    }
}
