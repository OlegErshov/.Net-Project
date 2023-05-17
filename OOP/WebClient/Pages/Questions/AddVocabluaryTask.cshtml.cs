using Application.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using Plugin.Questions;
using Plugin.Tasks;
using Repository.UserRepository;

namespace WebClient.Pages.Questions
{
    public class AddVocabluaryTaskModel : PageModel
    {
        private IStudentService _studentService;
        public AddVocabluaryTaskModel(IStudentService repo)
        {
            _studentService = repo;
        }

        [BindProperty]
        public Student Student { get; set; }
        public void OnGet(int id)
        {
            Student = _studentService.GetByIdAsync(id).Result;
            if (Student.homeWork._VocabluaryList.Count == 0 || Student.homeWork._VocabluaryList.Last().questions == null)
            {
                Student.homeWork._VocabluaryList.Add(new VocabluaryTask());
            }

            _studentService.UpdateAsync(Student);
        }

        public string Sentence { get; set; }
        public string MixedAnswer { get; set; }
        public string Answer { get; set; }
        public IActionResult OnPost(string Sentence, string MixedAnswer, string Answer,int id)
        {
            Student = _studentService.GetByIdAsync(id).Result;
            Student.homeWork._VocabluaryList.Last().questions.Add(new VocabluaryQuestion(Sentence, MixedAnswer, Answer));
            _studentService.UpdateAsync(Student);

            return Page();
        }
    }
}
