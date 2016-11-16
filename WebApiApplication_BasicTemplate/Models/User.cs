using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiApplication1.Models
{
    class User
    {
        public string Username { get; set; }

        public string HashPass { get; set; }
        public string Salt { get; private set; }
        public User(string user, string hashpass, string salt)
        {
            this.Username = user;
            this.HashPass = new Helper().Hasher(hashpass,salt);
            this.Salt = salt;
        }
        
    }
}
