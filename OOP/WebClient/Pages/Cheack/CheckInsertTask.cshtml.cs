using Application.Abstractions.QuestionAbstractions;
using Application.Abstractions.TaskAbstractions;
using Application.Abstractions;
using Application.Services.QuestionServices;
using Application.Services.TaskServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using Plugin.Questions;
using Plugin.Tasks;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebClient.Pages.Cheack
{
    public class CheckInsertTaskModel : PageModel
    {

        private IStudentService _studentService;
        

        private ITaskService<InsertTask, InsertQuestion> _insertTaskService;
        private IQuestionService<InsertQuestion> _insertQuestionService;

        public CheckInsertTaskModel(IStudentService studentService, ITaskService<InsertTask, InsertQuestion> insertTaskService, IQuestionService<InsertQuestion> insertQuestionService)
        {
            _studentService = studentService;
            _insertTaskService = insertTaskService;
            _insertQuestionService = insertQuestionService;
        }

        [BindProperty]
        public Student Student { get; set; }

        [BindProperty]
        public InsertTask task { get; set; }

        [BindProperty]
        public List<string> StudentAnswer { get; set; }
        public void OnGet(int id)
        {
            Student = _studentService.GetByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value).Result;
            task = _insertTaskService.GetByIdAsync(id).Result;

            task.questions = _insertQuestionService.ListAsync((x) => x.task.Id == id).Result;
        }

        public async void OnPostCheck(int id)
        {
            Student = _studentService.GetByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value).Result;

            task = _insertTaskService.GetByIdAsync(id).Result;

            task.questions = _insertQuestionService.ListAsync((x) => x.task.Id == id).Result;

            for (int i = 0; i < task.questions.Count(); i++)
            {
                if (task.questions[i].StringAnswer == StudentAnswer[i])
                {
                    task.questions[i].RightOrNot = 1;
                }
                else
                {
                    task.questions[i].RightOrNot = -1;
                }
                await _insertQuestionService.UpdateAsync(task.questions[i]);
            }
            await _insertQuestionService.SaveChangesAsync();
        }
    }
}
