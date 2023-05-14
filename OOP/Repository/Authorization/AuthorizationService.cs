using Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Authorization
{
    public class AuthorizationService : IAuthorization
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

        public User Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public User Registration(string email, string loginn, string password)
        {
            throw new NotImplementedException();
        }

    }
}
