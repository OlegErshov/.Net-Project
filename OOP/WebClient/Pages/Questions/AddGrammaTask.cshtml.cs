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
        private ITaskRepository _db;
        private IRepository<Student> _userRepository;

        public AddGrammaTaskModel(ITaskRepository db,IRepository<Student> userRepo)
        {
            _db = db;
            _userRepository = userRepo;
        }

        [BindProperty]
        public Student Student { get; set; }
        public void OnGet(int id)
        {
            
            Student = _userRepository.GetUserById(id);
            if(Student.homeWork._GrammaList.Count == 0 || Student.homeWork._GrammaList.Last().questions == null)
            {
                Student.homeWork._GrammaList.Add(new GrammaTask());
            }
          
            _userRepository.Update(Student);
        }

        public string Sentence { get; set; }
        public string AnswerVarients { get; set; }
        public string RightAnswer { get; set; }
        public IActionResult OnPost(string sentence, string answerVarients, string rightAnswer, GrammaTask task,int id)
        {
            List<string> varients = answerVarients.Split(' ').ToList();
            List<string> rightAns = rightAnswer.Split(' ').ToList();
            
            Student = _userRepository.GetUserById(id);
            Student.homeWork._GrammaList.Last().AddQuestion(sentence, varients, rightAns);
            _userRepository.Update(Student);

            return Page();
        }
    }
}
