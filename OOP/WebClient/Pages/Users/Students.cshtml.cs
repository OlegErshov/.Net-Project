using Application.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using System.Security.Claims;

namespace WebClient.Pages.Users
{
    [Authorize(Roles ="TEACHER")]
    public class StudentsModel : PageModel
    {
        private ITeacherService _teacherService;
        private IStudentService _studentService;


        public StudentsModel( IStudentService studentService, ITeacherService teacherService)
        {
            _studentService = studentService;
            _teacherService = teacherService;
        }

        [BindProperty]
        public string SearhTerm { get; set; }

        [BindProperty]
        public IEnumerable<Student>? Users { get; private set; }
        public void OnGet(string SearhTerm)
        {
            if(string.IsNullOrWhiteSpace(SearhTerm))
            {
                Users = _studentService.GetAllAsync().Result;
            }
            else
            {
                Users = _studentService.ListAsync((x) => x.Email.ToLower().Contains(SearhTerm.ToLower())).Result;
            }
           
        }

        public async void OnPost(string studentId)
        {
            Users = _studentService.GetAllAsync().Result;
            Teacher teacher = _teacherService.GetByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value).Result;
            Student student = _studentService.GetByIdAsync(studentId).Result;

            teacher.students.Add(student);
            student.TeacherId = teacher.Id;

            await _teacherService.UpdateAsync(teacher);
            await _teacherService.SaveChangesAsync();
            await _studentService.UpdateAsync(student);
            await _studentService.SaveChangesAsync();
        }
    }
}
