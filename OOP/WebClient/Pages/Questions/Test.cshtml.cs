using Application.Abstractions;
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
        private IStudentService _studentService;
        public TestModel(IStudentService service)
        {
            _studentService = service;
        }

        public Student Student { get; set; }

      
        public IActionResult OnGet(int id)
        {
            
            Student = _studentService.GetByIdAsync(id).Result;

            if(Student == null || Student.homeWork._GrammaList == null) {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
    }
}
