using Application.Abstractions;
using Application.Abstractions.QuestionAbstractions;
using Application.Abstractions.TaskAbstractions;
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
    public class AddInsertTaskModel : PageModel
    {
        private IStudentService _studentService;
        private ITaskService<InsertTask, InsertQuestion> _taskService;
        private IQuestionService<InsertQuestion> _questionService;
        public AddInsertTaskModel(IStudentService repo, ITaskService<InsertTask, InsertQuestion> taskService,
            IQuestionService<InsertQuestion> questionService)
        {
            _studentService = repo;
            _taskService = taskService;
            _questionService = questionService;
        }

        public Student Student { get; set; }

        [BindProperty]
        public string Message { get; set; }


        public void OnGet(string id)
        {

            Student = _studentService.GetByIdAsync(id).Result;
            Student._InsertList = _taskService.ListAsync((x) => x.Student.Id == Student.Id).Result;

               
            if (Student._InsertList.Count == 0 || Student._InsertList.Last().questions == null)
            {
                    Student._InsertList.Add(new InsertTask());
            }
            Student._InsertList.Last().questions = _questionService.ListAsync((x) => x.task.Id == Student._InsertList.Last().Id).Result;

        }

        [BindProperty]
        public string Sentence { get; set; }
        [BindProperty]
        public string Answer { get; set; }
        [BindProperty]
        public string Varients { get; set; }

        public async Task<IActionResult> OnPostAddTask(string id)
        {
            Student = _studentService.GetByIdAsync(id).Result;

            InsertTask insertTask = new InsertTask() { Student = Student };
            await _taskService.AddAsync(insertTask);
            await _taskService.SaveChangesAsync();

            Message = "Задание успешно добавлено";


            return Page();
        }


        public async void OnPost(string id)
        {
            Student = _studentService.GetByIdAsync(id).Result;

            Student._InsertList = _taskService.ListAsync((x) => x.Student.Id == Student.Id).Result;

            InsertTask insertTask;
            if (Student._InsertList.Count == 0)
            {
                insertTask = new InsertTask() { Student = Student };
                await _taskService.AddAsync(insertTask);
                await _taskService.SaveChangesAsync();
            }


            InsertQuestion question = new InsertQuestion(Answer, Sentence)
            {
                task = _taskService.FirstOrDefaultAsync((x) => x.Id == Student._InsertList.Last().Id).Result
            };



            await _questionService.AddAsync(question);
            await _questionService.SaveChangesAsync();

            Student._InsertList.Last().questions = _questionService.ListAsync((x) => x.task.Id == Student._InsertList.Last().Id).Result;
        }


        public async void OnPostAddVarients(string id)
        {
            Student = _studentService.GetByIdAsync(id).Result;

            Student._InsertList = _taskService.ListAsync((x) => x.Student.Id == Student.Id).Result;

            Student._InsertList.Last().questions = _questionService.ListAsync((x) => x.task.Id == Student._InsertList.Last().Id).Result;

            Student._InsertList.Last().words += " " + Varients;

            await _taskService.UpdateAsync(Student._InsertList.Last());
            await _taskService.SaveChangesAsync();

            Student._InsertList = _taskService.ListAsync((x) => x.Student.Id == Student.Id).Result;
        }
    }
}
