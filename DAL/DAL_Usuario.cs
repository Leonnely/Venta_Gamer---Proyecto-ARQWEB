﻿using BE;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Usuario
    {
        List<BE_Usuario> users = new List<BE_Usuario>
        {
                new BE_Usuario("Admin", "c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f", 0),
                new BE_Usuario("user2", "user2", 1),
                new BE_Usuario("user3", "user3", 1),
                new BE_Usuario("user4", "user4", 1),
                new BE_Usuario("user5", "user5", 1)
        };

        public int role;
        public bool Login(string username, string password)
        {
            BE_Usuario user = new BE_Usuario(username, password,0);
            foreach (var usuario in users)
            {
                if (usuario.Username == username && usuario.Password == password)
                {
                    user.Role= usuario.Role;
                    role=user.Role;
                    return true;
                }
            }
            return false;

        }


    }
}
