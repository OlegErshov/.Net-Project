using Application.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using Plugin.Questions;
using Plugin.Tasks;
using SerializerLib;

namespace WebClient.Pages.Users
{
    public class AddStudentModel : PageModel
    {
        private IStudentService _studentService;
        Serializer serializer = new Serializer();

        public AddStudentModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string Login { get; set; }


        public void OnGet()
        {

        }

        public async void OnPost()
        {
            Student student = new Student(Email,Login,Password);
            await _studentService.AddAsync(student);
            await _studentService.SaveChangesAsync();

            Directory.CreateDirectory($"D:\\BSUIR\\.Net-Project\\OOP\\JsonData\\{student.Login}");

            serializer.SerializeJson<GrammaTask>(student._GrammaList, $"D:\\BSUIR\\.Net-Project\\OOP\\JsonData\\{student.Login}\\GrammaTasks.json");
            serializer.SerializeJson<InsertTask>(student._InsertList, $"D:\\BSUIR\\.Net-Project\\OOP\\JsonData\\{student.Login}\\InsertTasks.json");
            serializer.SerializeJson<SentenceTask>(student._SentenceList, $"D:\\BSUIR\\.Net-Project\\OOP\\JsonData\\{student.Login}\\SentenceTasks.json");
            serializer.SerializeJson<VocabluaryTask>(student._VocabluaryList, $"D:\\BSUIR\\.Net-Project\\OOP\\JsonData\\{student.Login}\\VocabluaryTasks.json");
        }
    }
}
