using Application.Abstractions;
using Application.Abstractions.QuestionAbstractions;
using Application.Abstractions.TaskAbstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using Plugin.Questions;
using Plugin.Tasks;
using Repository;
using SerializerLib;

namespace WebClient.Pages.Questions
{
    public class TestModel : PageModel
    {
        private IStudentService _studentService;

        private ITaskService<GrammaTask, GrammaQuestion> _grammaTaskService;
        private IQuestionService<GrammaQuestion> _questionService;

        Serializer serializer = new Serializer();

        public TestModel(IStudentService service, ITaskService<GrammaTask, GrammaQuestion> taskService,
            IQuestionService<GrammaQuestion> questionService)
        {
            _studentService = service;
            _grammaTaskService = taskService;
            _questionService = questionService;
        }

        [BindProperty]
        public Student Student { get; set; }

        

      
        public async Task<IActionResult> OnGet(int id)
        {
            Student =  _studentService.GetByIdAsync(id).Result;

            Student._GrammaList = _grammaTaskService.ListAsync((x) => x.Student.Id == id).Result;
            foreach (var item in Student._GrammaList)
            {
                item.questions = _questionService.ListAsync((x)=> x.task.Id == item.Id).Result;
            }

            if(Student == null || Student._GrammaList == null) {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

       
    }
}
