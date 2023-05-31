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

namespace WebClient.Pages.Cheack
{
    public class CheakVocabluaryTaskModel : PageModel
    {
        private IStudentService _studentService;

        private ITaskService<VocabluaryTask, VocabluaryQuestion> _vocabluaryTaskService;
        private IQuestionService<VocabluaryQuestion> _vocabluaryQuestionService;

        public CheakVocabluaryTaskModel(IStudentService studentService, ITaskService<VocabluaryTask, VocabluaryQuestion> vocabluaryTaskService
            ,IQuestionService<VocabluaryQuestion> vocabluaryQuestionService)
        {
            _studentService= studentService;
            _vocabluaryTaskService= vocabluaryTaskService;
            _vocabluaryQuestionService= vocabluaryQuestionService;

        }

        [BindProperty]
        public Student Student { get; set; }

        [BindProperty]
        public VocabluaryTask task { get; set; }

        [BindProperty]
        public List<string> StudentAnswer { get; set; }
        public void OnGet(int id)
        {
            Student = _studentService.GetByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value).Result;

            task = _vocabluaryTaskService.GetByIdAsync(id).Result;

            task.questions = _vocabluaryQuestionService.ListAsync((x) => x.task.Id == id).Result;
        }


        public async void OnPostCheck(int id)
        {
            Student = _studentService.GetByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value).Result;

            task = _vocabluaryTaskService.GetByIdAsync(id).Result;

            task.questions = _vocabluaryQuestionService.ListAsync((x) => x.task.Id == id).Result;

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
                await _vocabluaryQuestionService.UpdateAsync(task.questions[i]);
            }
            await _vocabluaryQuestionService.SaveChangesAsync();
        }
    }
}
