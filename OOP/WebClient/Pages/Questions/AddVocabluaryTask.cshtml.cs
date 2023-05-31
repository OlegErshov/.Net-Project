using Application.Abstractions;
using Application.Abstractions.QuestionAbstractions;
using Application.Abstractions.TaskAbstractions;
using Application.Services.QuestionServices;
using Application.Services.TaskServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Plugin.Authorization;
using Plugin.Questions;
using Plugin.Tasks;
using System.Security.Claims;

namespace WebClient.Pages.Questions
{
    [Authorize(Roles = "TEACHER")]
    public class AddVocabluaryTaskModel : PageModel
    {
        private IStudentService _studentService;

        private ITaskService<VocabluaryTask, VocabluaryQuestion> _taskService;
        private IQuestionService<VocabluaryQuestion> _questionService;

        public AddVocabluaryTaskModel(IStudentService repo, ITaskService<VocabluaryTask, VocabluaryQuestion> taskService,
            IQuestionService<VocabluaryQuestion> questionService)
        {
            _studentService = repo;
            _taskService = taskService;
            _questionService = questionService;
        }

        [BindProperty]
        public Student Student { get; set; }

        [BindProperty]
        public string Message { get; set; }

        public void OnGet(string id)
        {
            
            Student = _studentService.GetByIdAsync(id).Result;
            Student._VocabluaryList = _taskService.ListAsync((x) => x.Student.Id == Student.Id).Result;

            if (Student._VocabluaryList.Count == 0 || Student._VocabluaryList.Last().questions == null)
            {
                    Student._VocabluaryList.Add(new VocabluaryTask());
            }

            Student._VocabluaryList.Last().questions = _questionService.ListAsync((x) => x.task.Id == Student._VocabluaryList.Last().Id).Result;

        }

        public string Sentence { get; set; }
        public string MixedAnswer { get; set; }
        public string Answer { get; set; }


        public async Task<IActionResult> OnPostAddTask(string id)
        {

            Student = _studentService.GetByIdAsync(id).Result;

            VocabluaryTask vocabluaryTask = new VocabluaryTask() { Student = Student };
            await _taskService.AddAsync(vocabluaryTask);
            await _taskService.SaveChangesAsync();

            Message = "Задание успешно добавлено";

            return Page();
        }



        public async void OnPost(string Sentence, string MixedAnswer, string Answer,string id)
        {
            Student = _studentService.GetByIdAsync(id).Result;

            Student._VocabluaryList = _taskService.ListAsync((x) => x.Student.Id == Student.Id).Result;

            VocabluaryTask vocabluaryTask;
            if (Student._VocabluaryList.Count == 0)
            {
                vocabluaryTask = new VocabluaryTask() { Student = Student };
                await _taskService.AddAsync(vocabluaryTask);
                await _taskService.SaveChangesAsync();
            }


            VocabluaryQuestion question = new VocabluaryQuestion(Sentence,MixedAnswer,Answer)
            {
                task = _taskService.FirstOrDefaultAsync((x) => x.Id == Student._VocabluaryList.Last().Id).Result
            };

            await _questionService.AddAsync(question);
            await _questionService.SaveChangesAsync();

            Student._VocabluaryList.Last().questions = _questionService.ListAsync((x) => x.task.Id == Student._VocabluaryList.Last().Id).Result;
        }
    }
}
