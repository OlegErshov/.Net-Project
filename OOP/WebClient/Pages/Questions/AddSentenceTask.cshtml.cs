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
    [Authorize(Roles = "Teacher")]
    public class AddSentenceTaskModel : PageModel
    {
        
        private IStudentService _studentService;

        private ITaskService<SentenceTask, SentenceQuestion> _sentenceTaskService;
        private IQuestionService<SentenceQuestion> _sentenceQuestionService;
        public AddSentenceTaskModel(IStudentService repo, ITaskService<SentenceTask, SentenceQuestion> sentenceTaskService,
            IQuestionService<SentenceQuestion> sentecneQuestionService)
        {
            _studentService = repo;
            _sentenceTaskService = sentenceTaskService;
            _sentenceQuestionService = sentecneQuestionService;
        }

        public Student Student { get; set; }

        public string Words { get; set; }
        public string Answer { get; set; }
        public void OnGet(string id)
        {
            if (User.FindFirst(ClaimTypes.NameIdentifier)?.Value.Equals(id) ?? true)
            {
                Student = _studentService.GetByIdAsync(id).Result;
                if (Student._VocabluaryList.Count == 0 || Student._VocabluaryList.Last().questions == null)
                {
                    Student._SentenceList.Add(new SentenceTask());
                }
            }
            else
            {
                RedirectToPage("NotFound");
            }
              

            
        }


        public async Task<IActionResult> OnPostAddTask(string id)
        {

            Student = _studentService.GetByIdAsync(id).Result;

            SentenceTask sentenceTask = new SentenceTask() { Student = Student };
            await _sentenceTaskService.AddAsync(sentenceTask);
            await _sentenceTaskService.SaveChangesAsync();

            string url = Url.Page("Test", new { id = Student.Id });
            return Redirect(url);
        }



        public async void OnPost(string Words, string Answer,string id)
        {
            Student = _studentService.GetByIdAsync(id).Result;

            Student._SentenceList = _sentenceTaskService.ListAsync((x) => x.Student.Id == Student.Id).Result;

            SentenceTask sentenceTask;
            if (Student._SentenceList.Count == 0)
            {
                sentenceTask = new SentenceTask() { Student = Student };
                await _sentenceTaskService.AddAsync(sentenceTask);
                await _sentenceTaskService.SaveChangesAsync();
            }


            SentenceQuestion question = new SentenceQuestion(Words,Answer)
            {
                task = _sentenceTaskService.FirstOrDefaultAsync((x) => x.Id == Student._SentenceList.Last().Id).Result
            };

            await _sentenceQuestionService.AddAsync(question);
            await _sentenceQuestionService.SaveChangesAsync();

        }

        
    }
}
