using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using Plugin.Tasks;
using Repository.UserRepository;

namespace WebClient.Pages.Users
{
    public class UserModel : PageModel
    {
        private Student User { get; set; }

        private IRepository<Student> _userRepository { get; set; }

        public UserModel(IRepository<Student> userRepository)
        {
            _userRepository = userRepository;
        }

        public void OnGet(int id)
        {
            User = _userRepository.GetUserById(id);
        }
    }
}
