using Application.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using Plugin.Questions;
using Plugin.Tasks;
using Repository.UserRepository;

namespace WebClient.Pages.Questions
{
    public class AddInsertTaskModel : PageModel
    {
        private IStudentService _studentService;
        public AddInsertTaskModel(IStudentService repo)
        {
                _studentService = repo;

        }

        public Student Student { get; set; }
        public void OnGet(int id)
        {
            Student = _studentService.GetByIdAsync(id).Result;
            if (Student.homeWork._InsertList.Count == 0 || Student.homeWork._InsertList.Last().questions == null)
            {
                Student.homeWork._InsertList.Add(new InsertTask());
            }

            _studentService.UpdateAsync(Student);
        }

        public string Sentence { get; set; }
        public string Word { get; set; }
        public IActionResult OnPostTest(int id)
        {
            Student = _studentService.GetByIdAsync(id).Result;
            Student.homeWork._InsertList.Last().addQuestion(Sentence,Word);
            _studentService.UpdateAsync(Student);

            return Page();
        }
    }
}
