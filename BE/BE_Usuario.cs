using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Usuario
    {

        public string Username { get; set; }
        public string Password { get; set; }

        public int Role { get; set; }



        public BE_Usuario(string username, string password, int role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

       
    }
}
