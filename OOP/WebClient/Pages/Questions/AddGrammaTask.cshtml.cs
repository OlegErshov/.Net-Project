using Application.Abstractions;
using Application.Abstractions.QuestionAbstractions;
using Application.Abstractions.TaskAbstractions;
using Application.Services.QuestionServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using Plugin.Questions;
using Plugin.Tasks;
using Repository;

using SerializerLib;
using System.Security.Claims;

namespace WebClient.Pages.Questions
{
    [Authorize(Roles = "TEACHER")]
    public class AddGrammaTaskModel : PageModel
    {
        private IStudentService _studentService;
        private ITaskService<GrammaTask,GrammaQuestion> _taskService;
        private IQuestionService<GrammaQuestion> _questionService;

        Serializer serializer = new Serializer();
        public AddGrammaTaskModel(IStudentService userRepo,ITaskService<GrammaTask,GrammaQuestion> taskService, IQuestionService<GrammaQuestion> questionService)
        {
            _studentService = userRepo;
            _taskService = taskService;
            _questionService = questionService;
        }

        [BindProperty]
        public Student Student { get; set; }
        public void OnGet(string id)
        {
           

                Student = _studentService.GetByIdAsync(id).Result;
                Student._GrammaList = _taskService.ListAsync((x) => x.Student.Id == Student.Id).Result;


                if (Student._GrammaList.Count == 0 || Student._GrammaList.Last().questions == null)
                {
                    Student._GrammaList.Add(new GrammaTask());
                    
                }
            Student._GrammaList.Last().questions = _questionService.ListAsync((x) => x.task.Id == Student._GrammaList.Last().Id).Result;
        }

        public List<string> Varients { get; set; }
        public List<string> Answers { get; set; }

        public string Sentence { get; set; }
        public string AnswerVarients { get; set; }
        public string RightAnswer { get; set; }

        [BindProperty]
        public string Message { get; set; }

        public async  Task<IActionResult> OnPostAddTask(string id)
        {
            
            Student =  _studentService.GetByIdAsync(id).Result;

            GrammaTask grammaTask = new GrammaTask() { Student = Student };
            await _taskService.AddAsync(grammaTask);
            await _taskService.SaveChangesAsync();

            Message = "Задание успешно добавлено";

       
            return Page();
            
        }


        public async Task<IActionResult> OnPost(string sentence, string answerVarients, string rightAnswer,string id)
        {

            Student = _studentService.GetByIdAsync(id).Result;

            Student._GrammaList = _taskService.ListAsync((x) => x.Student.Id == Student.Id).Result;


            GrammaTask grammaTask;
            if (Student._GrammaList.Count == 0)
            {
                grammaTask = new GrammaTask() { Student = Student };
                await _taskService.AddAsync(grammaTask);
                await _taskService.SaveChangesAsync();
            }
           

            GrammaQuestion question = new GrammaQuestion(sentence, answerVarients, rightAnswer) { 
                task = _taskService.FirstOrDefaultAsync((x) =>x.Id == Student._GrammaList.Last().Id).Result 
            
            };

            await _questionService.AddAsync(question);
            await _questionService.SaveChangesAsync();


            Student._GrammaList.Last().questions = _questionService.ListAsync((x) => x.task.Id == Student._GrammaList.Last().Id).Result;


            return Page();
        }
        
       
    }

}
