
using OOP.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP
{
    public interface IAuthorization 
    {
        void Registration(string email, string loginn, string password);
        User Login(string email, string password);
        bool Exist(string login);
    }
}