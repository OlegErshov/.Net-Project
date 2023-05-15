using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Authorization
{
    public interface IAuthorization<T>
    {
       T Registration(string email, string loginn, string password);
       T Login(string email, string password);
       bool Exist(string login);

      
    }
}
