using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using Repository.UserRepository;

namespace WebClient.Pages.Registration
{
    public class StudentsSignInModel : PageModel
    {
        IRepository<Student> _studentsRepository;
        AuthorizationService authorizationService;
        public StudentsSignInModel(IRepository<Student> studentList)
        {
            _studentsRepository= studentList;
            authorizationService = new AuthorizationService(studentList);
        }

        public string Login { get; set; }
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost(string Login,string Password) {
            if (!authorizationService.Exist(Login))
            {
                return RedirectToPage("/Registration/Registration");
            }
            else
            {
                Student st = authorizationService.Login(Login, Password);
                if (st != null)
                {
                    return RedirectToPage("/Users/UserPage",st);
                }
                return RedirectToPage("/Registration/Registration");
            }
        }
    }
}
