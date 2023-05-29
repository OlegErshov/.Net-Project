using Application.Abstractions.QuestionAbstractions;
using Application.Abstractions.TaskAbstractions;
using Application.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Questions;
using Plugin.Tasks;
using Plugin.Authorization;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace WebClient.Pages.Questions
{
    [Authorize(Roles ="Student")]
    public class StudentHomeWorkModel : PageModel
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

        public StudentHomeWorkModel(IStudentService service, ITaskService<GrammaTask, GrammaQuestion> taskService,
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

            if(User.FindFirst(ClaimTypes.NameIdentifier)?.Value.Equals(id) ?? true)
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
            
        }
        public void OnGet()
        {
            string id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Update(id);
        }

        public void OnPostCheakGramma(int taskId, string studentId)
        {
            // научиться считывать с чек бокса данные 
            // при правельном ответе менять цвет предложения на зелёный, при неверном на красный
            
        }

        public void OnPostCheakVocabluary(int taskId, string studentId)
        {

        }

        public void OnPostCheakSentence(int taskId, string studentId)
        {

        }

        public void OnPostCheakInsert(int taskId, string studentId)
        {

        }
    }
}
