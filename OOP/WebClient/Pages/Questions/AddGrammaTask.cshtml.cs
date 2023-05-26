using Application.Abstractions;
using Application.Abstractions.QuestionAbstractions;
using Application.Abstractions.TaskAbstractions;
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

            if (User.FindFirst(ClaimTypes.NameIdentifier)?.Value.Equals(Student.TeacherId)??true)
            {
                if (Student._GrammaList.Count == 0 || Student._GrammaList.Last().questions == null)
                {
                    Student._GrammaList.Add(new GrammaTask());
                    
                }
                
            }
            else
            {
                 RedirectToPage("NotFound");
            }



          
        }

        public List<string> Varients { get; set; }
        public List<string> Answers { get; set; }

        public string Sentence { get; set; }
        public string AnswerVarients { get; set; }
        public string RightAnswer { get; set; }

       

        public async  Task<IActionResult> OnPostAddTask(string id)
        {
            
            Student =  _studentService.GetByIdAsync(id).Result;

            GrammaTask grammaTask = new GrammaTask() { Student = Student };
            await _taskService.AddAsync(grammaTask);
            await _taskService.SaveChangesAsync();

            string url = Url.Page("Test", new { id = Student.Id });
            return Redirect(url);
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
                task = _taskService.FirstOrDefaultAsync((x) =>x.Id == Student._GrammaList.Last().Id).Result };

            await _questionService.AddAsync(question);
            await _questionService.SaveChangesAsync();

            Varients.Add(answerVarients);
            Answers.Add(rightAnswer);
            return Page();
        }
        
       
    }

}
