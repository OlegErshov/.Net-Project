using Application.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using System.Security.Claims;

namespace WebClient.Pages.Questions
{
    [Authorize(Roles ="TEACHER")]
    public class AddTaskModel : PageModel
    {
        private IStudentService _studentService;

        public AddTaskModel(IStudentService userRepo)
        {
            _studentService = userRepo;
        }

        [BindProperty]
        public Student Student { get; set; }
        public void OnGet(string id)
        {
            Student = _studentService.GetByIdAsync(id).Result;
               
        }
    }
}
