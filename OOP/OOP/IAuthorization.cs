using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP
{
    public interface IAuthorization 
    {
        void Registration(string email, string loginn, string password);
        void Login();
        bool Exist(string login);
    }
}