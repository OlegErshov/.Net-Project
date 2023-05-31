using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Authorization
{
    public interface IAuthorization
    {
        void Registration(string email, string loginn, string password);
        User Login(string email, string password);
        bool Exist(string login);
    }
}
