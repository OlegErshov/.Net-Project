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
        private IRepository<Student> _studentRepository;
        public AddInsertTaskModel(IRepository<Student> repo)
        {
                _studentRepository = repo;

        }

        public Student Student { get; set; }
        public void OnGet(int id)
        {
            Student = _studentRepository.GetUserById(id);
            if (Student.homeWork._InsertList.Count == 0 || Student.homeWork._InsertList.Last().questions == null)
            {
                Student.homeWork._InsertList.Add(new InsertTask());
            }

            _studentRepository.Update(Student);
        }

        public string Sentence { get; set; }
        public string Word { get; set; }
        public IActionResult OnPostTest(int id)
        {
            Student = _studentRepository.GetUserById(id);
            Student.homeWork._InsertList.Last().addQuestion(Sentence,Word);
            _studentRepository.Update(Student);

            return Page();
        }
    }
}
