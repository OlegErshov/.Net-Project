using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using Repository.UserRepository;

namespace WebClient.Pages.Questions
{
    public class AddTaskModel : PageModel
    {
        private IRepository<Student> _userRepository;

        public AddTaskModel(IRepository<Student> userRepo)
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
