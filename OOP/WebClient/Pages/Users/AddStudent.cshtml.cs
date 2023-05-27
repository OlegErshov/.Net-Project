using Application.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using Plugin.Questions;
using Plugin.Tasks;
using SerializerLib;
using System.Security.Claims;

namespace WebClient.Pages.Users
{
    [Authorize(Roles ="TEACHER")]
    public class AddStudentModel : PageModel
    {
        private IStudentService _studentService;
        private ITeacherService _teacherService;
        Serializer serializer = new Serializer();

        public AddStudentModel(IStudentService studentService,ITeacherService teacherService)
        {
            _studentService = studentService;
            _teacherService = teacherService;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string Login { get; set; }

        public Teacher Teacher { get; set; }


        public void OnGet(string id)
        {
            if (User.FindFirst(ClaimTypes.NameIdentifier)?.Value.Equals(id) ?? true)
            {
                Teacher = _teacherService.GetByIdAsync(id).Result;
            }
            else
            {
                RedirectToPage("NotFound");
            }
                
        }

        public async void OnPost()
        {
            Student student = new Student(Email,Login,Password, User.FindFirst(ClaimTypes.NameIdentifier)?.Value);


            await _studentService.AddAsync(student);
            await _studentService.SaveChangesAsync();

            
        }
    }
}
