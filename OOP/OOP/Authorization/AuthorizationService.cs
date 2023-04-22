using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP.Authorization
{
    public class AuthorizationService : IAuthorization
    {
        private List<User> _users = new List<User>();
        public bool Exist(string email)
        {
            var ex = _users.Any(p => p.Email == email);
            return ex;
        }

        public void Login()
        {

        }

        public void Registration(string email, string login, string password)
        {
            if (!Exist(email))
            {
                _users.Add(new User(email, login, password));
            }
            else
            {
                // Исклчение на случай существования пользователя, которое при обработке должно уведомить его об этом
                Exception exception = new Exception();
            }
        }
    }
}