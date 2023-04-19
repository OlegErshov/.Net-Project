using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OOP
{
    public class User
    {
        public User(string email, string login, string password) {
            this.Email = email;
            this.Login = login;
            this.Password = password;
        }
        public string Email
        {
            get ;
            set;
        }

        public string Login
        {
            get => default;
            set
            {
            }
        }

        public string Password
        {
            get => default;
            set
            {
            }
        }

        public bool EmailValidation(string email)
        {
            string pattern = @"([a-zA-Z\d]+@[a-z]+\.[a-z]+)";

            if(!Regex.Match(email,pattern).Success)
            {
                return false;
            }
            return true;

        }

        public bool PasswordValidation(string password)
        {
            string pattern = @"([\\da-zA-Z\\./_])";

            if(!Regex.Match(password,pattern).Success) {
                return false;
            }
            return true;
        }
    }
}