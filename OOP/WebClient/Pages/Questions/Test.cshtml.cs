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

        private IRepository<Student> _userRepository { get; set; }
        public TestModel(ITaskRepository db, IRepository<Student> userRepo)
        {
            _db = db;
            _userRepository = userRepo;
        }

        public Student Student { get; set; }

      
        public IActionResult OnGet(int id)
        {
            
            Student = _userRepository.GetUserById(id);

            if(Student == null || Student.homeWork._GrammaList == null) {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
    }
}
