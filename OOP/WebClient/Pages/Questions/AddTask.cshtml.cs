using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using Repository.UserRepository;

namespace WebClient.Pages.Questions
{
    public class AddTaskModel : PageModel
    {
        private IUserRepository _userRepository;

        public AddTaskModel(IUserRepository userRepo)
        {
            _userRepository= userRepo;
        }

        [BindProperty]
        public Student User { get; set; }
        public void OnGet(int id)
        {
            User = _userRepository.GetUserById(id);
        }
    }
}
