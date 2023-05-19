using Application.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;


namespace WebClient.Pages.Users
{
    public class StudentsModel : PageModel
    {

        private IStudentService _studentService;

        public StudentsModel( IStudentService studentService)
        {
            _studentService = studentService;
            
        }
    
        public IEnumerable<Student> Users { get; private set; }
        public void OnGet()
        {
            Users = _studentService.GetAllAsync().Result;
        }
    }
}
