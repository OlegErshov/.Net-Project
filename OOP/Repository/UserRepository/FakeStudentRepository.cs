using Plugin.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UserRepository
{
    public class FakeStudentRepository : IRepository<Student> 
    {
        List<Student> _UserList;

        public FakeStudentRepository()
        {
            _UserList = new List<Student>()
            {
                new Student()
                {
                   Id = 0, Email = "olezhka@gmail.com", Login = "SEKS INSTRUCTOR", Password = "1234324"
                },

                new Student()
                {
                   Id = 1, Email = "tima@gmail.com", Login = "SEKS INSTRUCTOR IS NATO", Password = "1111"
                },

                new Student()
                {
                   Id = 2, Email = "Sasha@gmail.com", Login = "Oleg's girlfriend", Password = "qwerty"
                }

            };
        }
        public IEnumerable<Student> GetAllUsers()
        {
            return _UserList;
        }

        public Student GetUserById(int id)
        {
            return _UserList.FirstOrDefault(x => x.Id == id);
        }

        public Student Update(Student UpdatedUser)
        {
            Student user = _UserList.FirstOrDefault(x => x.Id == UpdatedUser.Id);
            
            if (user != null)
            {
                user.homeWork._GrammaList = UpdatedUser.homeWork._GrammaList;
                user.homeWork._VocabluaryList = UpdatedUser.homeWork._VocabluaryList;
                user.homeWork._InsertList = UpdatedUser.homeWork._InsertList;
                user.homeWork._SentenceList = UpdatedUser.homeWork._SentenceList;
            }

            return user;
        }

        public void Add(Student student)
        {
            _UserList.Add(student);
        }
    }
}
