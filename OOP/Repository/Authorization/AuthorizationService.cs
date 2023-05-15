using Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Authorization
{
    public class AuthorizationService : IAuthorization<Student>
    {
        IRepository<Student> _repository;

        public AuthorizationService(IRepository<Student> repo)
        {
            _repository= repo;
        }
       
        public  bool Exist(string login)
        {
            return _repository.GetAllUsers().Any(x => x.Login == login);
        }

        public Student Login(string login, string password)
        {
            Student user = _repository.GetAllUsers().FirstOrDefault(x => x.Login == login);
            if(user.Password == password) {
                return user;
            }
            else
            {
                return null;
            }
        }

        public Student Registration(string email, string loginn, string password)
        {
            throw new NotImplementedException();
        }

    }
}
