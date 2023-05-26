using Application.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;


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
        public void OnGet(string id)
        {
            User = _studentService.GetByIdAsync(id).Result;
        }
    }
}
