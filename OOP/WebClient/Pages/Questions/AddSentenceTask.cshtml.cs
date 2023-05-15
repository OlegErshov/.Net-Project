using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using Plugin.Tasks;
using Repository.UserRepository;

namespace WebClient.Pages.Questions
{
    public class AddSentenceTaskModel : PageModel
    {
        private IRepository<Student> _studentRepository;
        public AddSentenceTaskModel(IRepository<Student> repo)
        {
            _studentRepository= repo;
        }

        public Student Student { get; set; }

        public string Words { get; set; }
        public string Answer { get; set; }
        public void OnGet(int id)
        {
            Student = _studentRepository.GetUserById(id);
            if (Student.homeWork._VocabluaryList.Count == 0 || Student.homeWork._VocabluaryList.Last().questions == null)
            {
                Student.homeWork._SentenceList.Add(new SentenceTask());
            }

            _studentRepository.Update(Student);
        }

        public IActionResult OnPost(string Words, string Answer,int id)
        {
            List<string> words = Words.Split(' ').ToList();

            Student = _studentRepository.GetUserById(id);
            Student.homeWork._SentenceList.Last().AddQuestion(words,Answer);
            _studentRepository.Update(Student);

            return Page();
        }

        
    }
}
