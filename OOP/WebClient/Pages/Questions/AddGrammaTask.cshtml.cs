using Application.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using Plugin.Questions;
using Plugin.Tasks;
using Repository;
using Repository.UserRepository;
using SerializerLib;

namespace WebClient.Pages.Questions
{
    public class AddGrammaTaskModel : PageModel
    {
        private IStudentService _studentService;

        Serializer serializer = new Serializer();
        public AddGrammaTaskModel(IStudentService userRepo)
        {
            _studentService= userRepo;
          
        }

        [BindProperty]
        public Student Student { get; set; }
        public void OnGet(int id)
        {
            
            Student = _studentService.GetByIdAsync(id).Result;
            if(Student._GrammaList.Count == 0 || Student._GrammaList.Last().questions == null)
            {
                Student._GrammaList.Add(new GrammaTask());
            }
        }

        public List<string> Varients { get; set; }
        public List<string> Answers { get; set; }

        public string Sentence { get; set; }
        public string AnswerVarients { get; set; }
        public string RightAnswer { get; set; }

        public  IActionResult OnPostAddTask(int id)
        {
            Student =  _studentService.GetByIdAsync(id).Result;

            deserialization(); 
            
            Student._GrammaList.Add(new GrammaTask());
            Student._GrammaList.Last().questions = new List<GrammaQuestion>();

            serialization();

            return RedirectToPage("Test",Student.Id);
        }
        public void OnPost(string sentence, string answerVarients, string rightAnswer,int id)
        {

            Student = _studentService.GetByIdAsync(id).Result;
            deserialization();

            if (Student._GrammaList.Count == 0)
            {
                Student._GrammaList.Add(new GrammaTask());
            }
            Student._GrammaList.Last().AddQuestion(sentence, answerVarients, rightAnswer);

            serialization();

            _studentService.UpdateAsync(Student);
            _studentService.SaveChangesAsync();

           
        }

        private void serialization()
        {
            // DirectoryInfo directory = new DirectoryInfo($"D:\\BSUIR\\.Net - Project\\OOP\\JsonData\\{Student.Login}");
            // directory.Create();
            string path = "D:\\BSUIR\\.Net-Project\\OOP\\JsonData\\";
            string fullPath = $"{path}{Student.Login}";

            if(!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            else
            {
                serializer.SerializeJson(Student._GrammaList, $"{fullPath}\\GrammaTasks.json");
            }

            
        }

        private void deserialization()
        {
            string path = "D:\\BSUIR\\.Net-Project\\OOP\\JsonData\\";
            string fullPath = $"{path}{Student.Login}";
            
            
            Student._GrammaList = serializer.DeserializeJson<GrammaTask>($"{fullPath}\\GrammaTasks.json").ToList();
        }
    }

}
