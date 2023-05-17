using Application.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using Plugin.Questions;
using Plugin.Tasks;
using Repository;
using Repository.UserRepository;

namespace WebClient.Pages.Questions
{
    public class AddGrammaTaskModel : PageModel
    {
        private IStudentService _studentService;

        public AddGrammaTaskModel(IStudentService userRepo)
        {
            _studentService= userRepo;
        }

        [BindProperty]
        public Student Student { get; set; }
        public void OnGet(int id)
        {
            
            Student = _studentService.GetByIdAsync(id).Result;
            if(Student.homeWork._GrammaList.Count == 0 || Student.homeWork._GrammaList.Last().questions == null)
            {
                Student.homeWork._GrammaList.Add(new GrammaTask());
            }

            _studentService.UpdateAsync(Student);
        }

        public string Sentence { get; set; }
        public string AnswerVarients { get; set; }
        public string RightAnswer { get; set; }
        public IActionResult OnPost(string sentence, string answerVarients, string rightAnswer, GrammaTask task,int id)
        {
            List<string> varients = answerVarients.Split(' ').ToList();
            List<string> rightAns = rightAnswer.Split(' ').ToList();

            Student = _studentService.GetByIdAsync(id).Result;
            Student.homeWork._GrammaList.Last().AddQuestion(sentence, varients, rightAns);
            _studentService.UpdateAsync(Student);

            return Page();
        }
    }
}
