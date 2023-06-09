using Application.Abstractions;
using Application.Abstractions.QuestionAbstractions;
using Application.Abstractions.TaskAbstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using Plugin.Questions;
using Plugin.Tasks;
using System.Security.Claims;

namespace WebClient.Pages.Questions
{
    [Authorize]
    public class TestModel : PageModel
    {
        private IStudentService _studentService;

        private ITaskService<GrammaTask, GrammaQuestion> _grammaTaskService;
        private IQuestionService<GrammaQuestion> _grammaQuestionService;

        private ITaskService<InsertTask, InsertQuestion> _insertTaskService;
        private IQuestionService<InsertQuestion> _insertQuestionService;

        private ITaskService<SentenceTask, SentenceQuestion> _sentenceTaskService;
        private IQuestionService<SentenceQuestion> _sentenceQuestionService;

        private ITaskService<VocabluaryTask, VocabluaryQuestion> _vocabluaryTaskService;
        private IQuestionService<VocabluaryQuestion> _vocabluaryQuestionService;



        public TestModel(IStudentService service, ITaskService<GrammaTask, GrammaQuestion> taskService,
            IQuestionService<GrammaQuestion> questionService, ITaskService<InsertTask, InsertQuestion> insertTaskService,
            IQuestionService<InsertQuestion> insertQuestionService, ITaskService<SentenceTask, SentenceQuestion> sentenceTaskService,
            IQuestionService<SentenceQuestion> sentenceQuestionService, ITaskService<VocabluaryTask, VocabluaryQuestion> vocabluaryTaskService,
            IQuestionService<VocabluaryQuestion> vocabluaryQuestionService)
        {
            _studentService = service;
            _grammaTaskService = taskService;
            _grammaQuestionService = questionService;

            _insertTaskService = insertTaskService;
            _insertQuestionService = insertQuestionService;

            _sentenceTaskService = sentenceTaskService;
            _sentenceQuestionService = sentenceQuestionService;

            _vocabluaryTaskService = vocabluaryTaskService;
            _vocabluaryQuestionService = vocabluaryQuestionService;

        }

        [BindProperty]
        public Student Student { get; set; }

        private void Update(string id)
        {
            Student = _studentService.GetByIdAsync(id).Result;

            Student._GrammaList = _grammaTaskService.ListAsync((x) => x.Student.Id == id).Result;
            foreach (var item in Student._GrammaList)
            {
                item.questions = _grammaQuestionService.ListAsync((x) => x.task.Id == item.Id).Result;
            }

            Student._InsertList = _insertTaskService.ListAsync((x) => x.Student.Id == id).Result;
            foreach (var item in Student._InsertList)
            {
                item.questions = _insertQuestionService.ListAsync((x) => x.task.Id == item.Id).Result;
            }

            Student._SentenceList = _sentenceTaskService.ListAsync((x) => x.Student.Id == id).Result;
            foreach (var item in Student._SentenceList)
            {
                item.questions = _sentenceQuestionService.ListAsync((x) => x.task.Id == item.Id).Result;
            }

            Student._VocabluaryList = _vocabluaryTaskService.ListAsync((x) => x.Student.Id == id).Result;
            foreach (var item in Student._VocabluaryList)
            {
                item.questions = _vocabluaryQuestionService.ListAsync((x) => x.task.Id == item.Id).Result;
            }
        }

        

      
        public async Task<IActionResult> OnGet(string id)
        {
            Update(id);

            return Page();
             
            
        }

        public async Task<IActionResult> OnPostDeleteGramma(int id, int taskId,string studentId)
        {
            List<int> deletedId = new List<int>();

            
            GrammaTask task = _grammaTaskService.GetByIdAsync(taskId).Result;


            var deletedQuestion = _grammaQuestionService.ListAsync((x) => x.task.Id == task.Id);

            foreach (var item in deletedQuestion.Result)
            {
                await _grammaQuestionService.DeleteAsync(item);
            }

            await _grammaTaskService.DeleteAsync(task);
            await _grammaQuestionService.SaveChangesAsync();
            await _grammaTaskService.SaveChangesAsync();

            Update(studentId);

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteVocabluary(int id, int taskId, string studentId)
        {
            List<int> deletedId = new List<int>();


            VocabluaryTask task = _vocabluaryTaskService.GetByIdAsync(taskId).Result;


            var deletedQuestion = _vocabluaryQuestionService.ListAsync((x) => x.task.Id == task.Id);

            foreach (var item in deletedQuestion.Result)
            {
                await _vocabluaryQuestionService.DeleteAsync(item);
            }

            await _vocabluaryTaskService.DeleteAsync(task);
            await _vocabluaryQuestionService.SaveChangesAsync();
            await _vocabluaryTaskService.SaveChangesAsync();

            Update(studentId);

            return Page();
        }


        public async Task<IActionResult> OnPostDeleteSentence(int id, int taskId, string studentId)
        {
            List<int> deletedId = new List<int>();


            SentenceTask task = _sentenceTaskService.GetByIdAsync(taskId).Result;


            var deletedQuestion = _sentenceQuestionService.ListAsync((x) => x.task.Id == task.Id);

            foreach (var item in deletedQuestion.Result)
            {
                await _sentenceQuestionService.DeleteAsync(item);
            }

            await _sentenceTaskService.DeleteAsync(task);
            await _sentenceQuestionService.SaveChangesAsync();
            await _sentenceTaskService.SaveChangesAsync();

            Update(studentId);

            return Page();
        }


        public async Task<IActionResult> OnPostDeleteInsert(int id, int taskId, string studentId)
        {
            List<int> deletedId = new List<int>();


            InsertTask task = _insertTaskService.GetByIdAsync(taskId).Result;


            var deletedQuestion = _insertQuestionService.ListAsync((x) => x.task.Id == task.Id);

            foreach (var item in deletedQuestion.Result)
            {
                await _insertQuestionService.DeleteAsync(item);
            }

            await _insertTaskService.DeleteAsync(task);
            await _insertQuestionService.SaveChangesAsync();
            await _insertTaskService.SaveChangesAsync();

            Update(studentId);

            return Page();
        }
    }
}
