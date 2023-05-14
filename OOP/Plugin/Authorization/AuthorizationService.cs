using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Authorization
{
    public class AuthorizationService : IAuthorization
    {
        private List<Student> _users = new List<Student>();
        public bool Exist(string email)
        {
            var ex = _users.Any(p => p.Email == email);
            return ex;
        }

        public Student Login(string email, string password)
        {
            Student user = new Student();
            if (Exist(email))
            {
                var us = _users.Find(p => p.Email == email);
                if (us?.Password == password)
                {
                    user = us;
                }
                else
                {
                    // исключение о неправильном вводе пароля
                    Exception exception = new Exception();
                }


            }
            return user;
        }

        public void Registration(string email, string login, string password)
        {
            if (!Exist(email))
            {
                _users.Add(new Student(email, login, password));
            }
            else
            {
                // Исклчение на случай существования пользователя, которое при обработке должно уведомить его об этом
                Exception exception = new Exception();
            }
        }
    }
}
