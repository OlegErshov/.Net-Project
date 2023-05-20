using Application.Abstractions;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using Plugin.Tasks;


namespace WebClient.Pages.Users
{
    public class UserModel : PageModel
    {
        private Student User { get; set; }

        private IStudentService _studentService;

        public UserModel( IStudentService studentService)
        {
            _studentService = studentService;
        }

        public void OnGet(int id)
        {
            User = _studentService.GetByIdAsync(id).Result;
        }
    }
}
