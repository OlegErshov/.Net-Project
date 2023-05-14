using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using Repository.UserRepository;

namespace WebClient.Pages.Users
{
    public class StudentsModel : PageModel
    {

        private IUserRepository _userRepository;

        public StudentsModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    
        public IEnumerable<Student> Users { get; private set; }
        public void OnGet()
        {
            Users = _userRepository.GetAllUsers();
        }
    }
}
