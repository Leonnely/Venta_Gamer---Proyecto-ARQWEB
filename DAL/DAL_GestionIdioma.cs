using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_GestionIdioma
    {
        public Dictionary<string, string> GetTextsByLanguage(string languageCode)
        {
            var textos = new Dictionary<string, string>();
            using (var connection = new SqlConnection(@"Data Source=Brian;Initial Catalog=VentaGamer;Integrated Security=True;Encrypt=False"))
            {
                connection.Open();
              
                var command = new SqlCommand(
                    "SELECT t.TextKey, t.Value " +
                    "FROM TextoLenguajes t " +
                    "INNER JOIN Lenguajes l ON t.LanguageID = l.LanguageID " +
                    "WHERE l.LanguageCode = @idioma", connection);

               
                command.Parameters.AddWithValue("@idioma", languageCode);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Llena el diccionario con las claves y valores obtenidos de la consulta
                        textos[reader["TextKey"].ToString()] = reader["Value"].ToString();
                    }
                }
            }
            return textos;
        }

        public Dictionary<string, string> GetTextsByLanguageId(int languageId)
        {
            var textos = new Dictionary<string, string>();
            using (var connection = new SqlConnection(@"Data Source=Brian;Initial Catalog=VentaGamer;Integrated Security=True;Encrypt=False"))
            {
                connection.Open();

                var command = new SqlCommand(
                    "SELECT t.TextKey, t.Value " +
                    "FROM TextoLenguajes t " +
                    "INNER JOIN Lenguajes l ON t.LanguageID = l.LanguageID " +
                    "WHERE l.LanguageID = @idiomaID", connection);


                command.Parameters.AddWithValue("@idiomaID", languageId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Llena el diccionario con las claves y valores obtenidos de la consulta
                        textos[reader["TextKey"].ToString()] = reader["Value"].ToString();
                    }
                }
            }
            return textos;
        }

        public int ObtenerIdDesdeIdioma(string idioma)
        {
            int id = -1; // Valor predeterminado en caso de que no se encuentre el idioma.

            using (var connection = new SqlConnection(@"Data Source=Brian;Initial Catalog=VentaGamer;Integrated Security=True;Encrypt=False"))
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT LanguageID FROM Lenguajes WHERE LanguageCode = @idioma;", connection))
                {
                    command.Parameters.AddWithValue("@idioma", idioma);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = reader.GetInt32(0); 
                        }
                    }
                }
            }

            return id;
        }
    }
}
