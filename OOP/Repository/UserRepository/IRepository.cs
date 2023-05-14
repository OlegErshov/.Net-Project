using Plugin.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UserRepository
{
    public interface IRepository<T> where T : User
    {
        IEnumerable<T> GetAllUsers();

        T GetUserById(int id);

        T Update(T user);

        void Add(T user);
    }
}
