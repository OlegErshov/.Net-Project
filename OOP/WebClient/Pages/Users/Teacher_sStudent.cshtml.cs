using Application.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using System.Security.Claims;

namespace WebClient.Pages.Users
{
    [Authorize(Roles ="TEACHER")]
    public class Teacher_sStudentModel : PageModel
    {

        private ITeacherService _teacherService;
        private IStudentService _studentService;


        public Teacher_sStudentModel(IStudentService studentService, ITeacherService teacherService)
        {
            _studentService = studentService;
            _teacherService = teacherService;

        }

        public IEnumerable<Student> Students { get;  set; }

        
        public void OnGet()
        {
            Students = _studentService.GetAllAsync().Result;
            Teacher teacher = _teacherService.GetByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value).Result;
            Students = teacher.students.ToList();
        }

        public async void OnPostDelete(string id) 
        {
            Students = _studentService.GetAllAsync().Result;
            Teacher teacher = _teacherService.GetByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value).Result;

            Student student = new Student();
            student = _studentService.GetByIdAsync(id).Result;

            teacher.students.Remove(student);
            student.TeacherId = null;

            await _teacherService.UpdateAsync(teacher);
            await _teacherService.SaveChangesAsync();
            await _studentService.UpdateAsync(student);
            await _studentService.SaveChangesAsync();
        }
    }
}
