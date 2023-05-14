using Plugin.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UserRepository
{
    public interface IUserRepository
    {
        IEnumerable<Student> GetAllUsers();

        Student GetUserById(int id);

        Student Update(Student user);
    }
}
