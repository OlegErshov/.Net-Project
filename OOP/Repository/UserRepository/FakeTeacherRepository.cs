using Plugin.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UserRepository
{
    public class FakeTeacherRepository : IRepository<Teacher>
    {
        IEnumerable<Teacher> _TeachersList;
        public FakeTeacherRepository()
        {
            _TeachersList = new List<Teacher>()
            {
                new Teacher()
                {
                    students = new List<int>(){0,2},
                    Id = 0,
                   
                    Login = "Sasha",
                    Email = "sasha@gmail.com",
                    Password = "1111"
                }
            };
        }
        public IEnumerable<Teacher> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Teacher GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Teacher Update(Teacher user)
        {
            throw new NotImplementedException();
        }

        public void Add(Teacher teacher) {
            throw new NotImplementedException();
        }
    }
}
