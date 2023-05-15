using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using Repository.UserRepository;

namespace WebClient.Pages.Registration
{
    public class RegistrationModel : PageModel
    {
        IRepository<Student> _studentsRepository;
        IRepository<Teacher> _teachersRepository;

        AuthorizationService authorizationService;
        public RegistrationModel(IRepository<Student> studentList, IRepository<Teacher> teachersList)
        {
            _studentsRepository= studentList;
            _teachersRepository = teachersList;

            authorizationService = new AuthorizationService(studentList);
        }
        public void OnGet()
        {

        }

        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        

        public IActionResult OnPost(string Email, string Login, string Password)
        {
            if (authorizationService.Exist(Login)){
                return RedirectToPage("Registration/Login");
            }
            else
            {
                int id = _studentsRepository.GetAllUsers().Max(x => x.Id) + 1;
                Student st = new Student(Email,Login,Password,id);
                _studentsRepository.Add(st);
                return RedirectToPage("/Users/UserPage", id);
            }

        }

        
    }
}
