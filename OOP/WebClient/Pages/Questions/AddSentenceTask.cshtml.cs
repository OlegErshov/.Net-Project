using Application.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using Plugin.Tasks;

namespace WebClient.Pages.Questions
{
    public class AddSentenceTaskModel : PageModel
    {
        private IStudentService _studentService;
        public AddSentenceTaskModel(IStudentService repo)
        {
            _studentService = repo;
        }

        public Student Student { get; set; }

        public string Words { get; set; }
        public string Answer { get; set; }
        public void OnGet(int id)
        {
            Student = _studentService.GetByIdAsync(id).Result;
            if (Student._VocabluaryList.Count == 0 || Student._VocabluaryList.Last().questions == null)
            {
                Student._SentenceList.Add(new SentenceTask());
            }

            _studentService.UpdateAsync(Student);
        }

        public IActionResult OnPost(string Words, string Answer,int id)
        {
            List<string> words = Words.Split(' ').ToList();

            Student = _studentService.GetByIdAsync(id).Result;
            Student._SentenceList.Last().AddQuestion(words,Answer);
            _studentService.UpdateAsync(Student);

            return Page();
        }

        
    }
}
