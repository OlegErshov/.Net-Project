using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Authorization
{
    public class User
    {
        public User(string email, string login, string password)
        {
            Email = email;
            Login = login;
            Password = password;
        }

        public User() { }
        public string Email
        {
            get;
            set;
        }

        public string Login
        {
            get;
            set;

        }

        public string Password
        {
            get;
            set;
        }


    }
}
