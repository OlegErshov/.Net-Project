using Application.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using Plugin.Tasks;
using Repository;
using SerializerLib;

namespace WebClient.Pages.Questions
{
    public class TestModel : PageModel
    {
        private IStudentService _studentService;

        Serializer serializer = new Serializer();
        public TestModel(IStudentService service)
        {
            _studentService = service;
        }

        [BindProperty]
        public Student Student { get; set; }

        public List<string> Varients { get; set; }

      
        public IActionResult OnGet(int id)
        {
            
            Student = _studentService.GetByIdAsync(id).Result;

            deserialization();

            if(Student == null || Student._GrammaList == null) {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

        private void deserialization()
        {
            string path = $"D:\\BSUIR\\.Net-Project\\OOP\\JsonData\\{Student.Login}";
            Student._GrammaList = serializer.DeserializeJson<GrammaTask>($"{path}\\GrammaTasks.json").ToList();
            Student._InsertList = serializer.DeserializeJson<InsertTask>($"{path}\\InsertTasks.json").ToList();
            Student._SentenceList = serializer.DeserializeJson<SentenceTask>($"{path}\\SentenceTasks.json").ToList();
            Student._VocabluaryList = serializer.DeserializeJson<VocabluaryTask>($"{path}\\VocabluaryTasks.json").ToList();
        }
    }
}
