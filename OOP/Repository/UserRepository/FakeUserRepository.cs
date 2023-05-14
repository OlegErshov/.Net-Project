using Plugin.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UserRepository
{
    public class FakeUserRepository : IUserRepository
    {
        IEnumerable<Student> _UserList;

        public FakeUserRepository()
        {
            _UserList = new List<Student>()
            {
                new Student()
                {
                   id = 0, Email = "olezhka@gmail.com", Login = "SEKS INSTRUCTOR", Password = "1234324"
                },

                new Student()
                {
                   id = 1, Email = "tima@gmail.com", Login = "SEKS INSTRUCTOR IS NATO", Password = "1111"
                },

                new Student()
                {
                   id = 2, Email = "Sasha@gmail.com", Login = "Oleg's girlfriend", Password = "qwerty"
                }

            };
        }
        public IEnumerable<Student> GetAllUsers()
        {
            return _UserList;
        }

        public Student GetUserById(int id)
        {
            return _UserList.FirstOrDefault(x => x.id == id);
        }

        public Student Update(Student UpdatedUser)
        {
            Student user = _UserList.FirstOrDefault(x => x.id == UpdatedUser.id);
            
            if (user != null)
            {
                user.homeWork._GrammaList = UpdatedUser.homeWork._GrammaList;
                user.homeWork._VocabluaryList = UpdatedUser.homeWork._VocabluaryList;
                user.homeWork._InsertList = UpdatedUser.homeWork._InsertList;
                user.homeWork._SentenceList = UpdatedUser.homeWork._SentenceList;
            }

            return user;
        }
    }
}
