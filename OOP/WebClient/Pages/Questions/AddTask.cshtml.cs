using Application.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using Repository.UserRepository;

namespace WebClient.Pages.Questions
{
    public class AddTaskModel : PageModel
    {
        private IStudentService _studentService;

        public AddTaskModel(IStudentService userRepo)
        {
            _studentService = userRepo;
        }

        [BindProperty]
        public Student User { get; set; }
        public void OnGet(int id)
        {
            User = _studentService.GetByIdAsync(id).Result;
        }
    }
}
