using Application.Abstractions;
using Application.Abstractions.QuestionAbstractions;
using Application.Abstractions.TaskAbstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using Plugin.Authorization;
using Plugin.Questions;
using Plugin.Tasks;
using System.Security.Claims;

namespace WebClient.Pages.Cheack
{
    public class CheackGrammaTaskModel : PageModel
    {


        private IStudentService _studentService;

        private ITaskService<GrammaTask, GrammaQuestion> _grammaTaskService;
        private IQuestionService<GrammaQuestion> _grammaQuestionService;
        private static int capacity;

        public CheackGrammaTaskModel(IStudentService studentService, ITaskService<GrammaTask, GrammaQuestion> grammaTaskService,
            IQuestionService<GrammaQuestion> grammaQuestionService)
        {
            _studentService = studentService;
            _grammaTaskService = grammaTaskService;
            _grammaQuestionService = grammaQuestionService;

            
        }

        [BindProperty]
        public Student Student { get; set; }

        [BindProperty]
        public GrammaTask task { get; set; }

        public void OnGet(int id)
        {
            Student = _studentService.GetByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value).Result;

            task = _grammaTaskService.GetByIdAsync(id).Result;

            task.questions = _grammaQuestionService.ListAsync((x) => x.task.Id == id).Result;

            varients = new List<string>(task.questions.Count());
            capacity = task.questions.Count();
        }

        [BindProperty]
        public List<string> varients { get; set; } = new List<string>(capacity);
        public async void OnPostCheak(int id)
        {
            Student = _studentService.GetByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value).Result;

            task = _grammaTaskService.GetByIdAsync(id).Result;

            task.questions = _grammaQuestionService.ListAsync((x) => x.task.Id == id).Result;

           for(int i = 0; i < task.questions.Count(); i++) 
           {
                if (task.questions[i].StringAnswer == varients[i])
                {
                    task.questions[i].RightOrNot = 1;
                }
                else
                {
                    task.questions[i].RightOrNot = -1;
                }
                await _grammaQuestionService.UpdateAsync(task.questions[i]);
            }
            await _grammaQuestionService.SaveChangesAsync();
           
        }
    }
}
