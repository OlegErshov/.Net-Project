using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Authorization
{
    public class Student : User
    {
        public Student(string email, string login, string password)
        {
            Email = email;
            Login = login;
            Password = password;
        }

        public Student() { }

        public HomeWork? homeWork = new HomeWork();
        public int id;

    }
}
