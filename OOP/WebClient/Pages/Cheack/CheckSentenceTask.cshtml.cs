using Application.Abstractions;
using Application.Abstractions.QuestionAbstractions;
using Application.Abstractions.TaskAbstractions;
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
    public class CheckSentenceTaskModel : PageModel
    {
        private IStudentService _studentService;
        private ITaskService<SentenceTask, SentenceQuestion> _sentenceTaskService;
        private IQuestionService<SentenceQuestion> _sentenceQuestionService;

        public CheckSentenceTaskModel(IStudentService studentService, ITaskService<SentenceTask, SentenceQuestion> sentenceTaskService, 
            IQuestionService<SentenceQuestion> sentenceQuestionService)
        {
            _studentService = studentService;
            _sentenceTaskService = sentenceTaskService;
            _sentenceQuestionService = sentenceQuestionService;
        }

        [BindProperty]
        public Student Student { get;  set; }

        [BindProperty]
        public SentenceTask task { get; set; }

        [BindProperty]
        public List<string> StudentAnswer { get; set; }
        public void OnGet(int id)
        {
            Student = _studentService.GetByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value).Result;

            task = _sentenceTaskService.GetByIdAsync(id).Result;

            task.questions = _sentenceQuestionService.ListAsync((x) => x.task.Id == id).Result;
        }

        public async void OnPostCheck(int id)
        {
            Student = _studentService.GetByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value).Result;

            task = _sentenceTaskService.GetByIdAsync(id).Result;

            task.questions = _sentenceQuestionService.ListAsync((x) => x.task.Id == id).Result;

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
                await _sentenceQuestionService.UpdateAsync(task.questions[i]);
            }
            await _sentenceQuestionService.SaveChangesAsync();
        }
    }
}
