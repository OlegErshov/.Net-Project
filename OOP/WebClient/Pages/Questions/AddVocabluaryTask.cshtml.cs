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
        private IRepository<Student> _studentRepository;
        public AddVocabluaryTaskModel(IRepository<Student> repo)
        {
            _studentRepository= repo;
        }

        [BindProperty]
        public Student Student { get; set; }
        public void OnGet(int id)
        {
            Student = _studentRepository.GetUserById(id);
            if (Student.homeWork._VocabluaryList.Count == 0 || Student.homeWork._VocabluaryList.Last().questions == null)
            {
                Student.homeWork._VocabluaryList.Add(new VocabluaryTask());
            }

            _studentRepository.Update(Student);
        }

        public string Sentence { get; set; }
        public string MixedAnswer { get; set; }
        public string Answer { get; set; }
        public IActionResult OnPost(string Sentence, string MixedAnswer, string Answer,int id)
        {
            Student = _studentRepository.GetUserById(id);
            Student.homeWork._VocabluaryList.Last().questions.Add(new VocabluaryQuestion(Sentence, MixedAnswer, Answer));
            _studentRepository.Update(Student);

            return Page();
        }
    }
}
