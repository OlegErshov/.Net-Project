using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using Plugin.Tasks;
using Repository;
using Repository.UserRepository;

namespace WebClient.Pages.Questions
{
    public class TestModel : PageModel
    {
        private ITaskRepository _db { get; set; }

        private IUserRepository _userRepository { get; set; }
        public TestModel(ITaskRepository db, IUserRepository userRepo)
        {
            _db = db;
            _userRepository = userRepo;
        }

        public Student user { get; set; }

      
        public IActionResult OnGet(int id)
        {
            
            user = _userRepository.GetUserById(id);

            if(user == null || user.homeWork._GrammaList == null) {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
    }
}
