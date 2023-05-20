using Application.Abstractions;
using Application.Abstractions.QuestionAbstractions;
using Application.Abstractions.TaskAbstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Plugin.Authorization;
using Plugin.Questions;
using Plugin.Tasks;


namespace WebClient.Pages.Questions
{
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
        public void OnGet(int id)
        {
            Student = _studentService.GetByIdAsync(id).Result;
            if (Student._InsertList.Count == 0 || Student._InsertList.Last().questions == null)
            {
                Student._InsertList.Add(new InsertTask());
            }

            
        }

        [BindProperty]
        public string Sentence { get; set; }
        [BindProperty]
        public string Answer { get; set; }
        [BindProperty]
        public string Varients { get; set; }

        public async Task<IActionResult> OnPostAddTask(int id)
        {

            Student = _studentService.GetByIdAsync(id).Result;

            Student._InsertList = _taskService.ListAsync((x) => x.Student.Id == Student.Id).Result;
            Student._InsertList.Last().words = Varients;

            InsertTask insertTask = new InsertTask() { Student = Student };
            await _taskService.AddAsync(insertTask);
            await _taskService.SaveChangesAsync();
                
            string url = Url.Page("Test", new { id = Student.Id });
            return Redirect(url);
        }


        public async void OnPost(int id)
        {
            Student = _studentService.GetByIdAsync(id).Result;

            Student._InsertList = _taskService.ListAsync((x) => x.Student.Id == Student.Id).Result;

            InsertTask insertTask;
            if (Student._GrammaList.Count == 0)
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
        }
    }
}
