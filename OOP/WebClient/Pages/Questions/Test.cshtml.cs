using Application.Abstractions;
using Application.Abstractions.QuestionAbstractions;
using Application.Abstractions.TaskAbstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plugin.Authorization;
using Plugin.Questions;
using Plugin.Tasks;
using Repository;
using SerializerLib;

namespace WebClient.Pages.Questions
{
    public class TestModel : PageModel
    {
        private IStudentService _studentService;

        private ITaskService<GrammaTask, GrammaQuestion> _grammaTaskService;
        private IQuestionService<GrammaQuestion> _questionService;

        private ITaskService<InsertTask, InsertQuestion> _insertTaskService;
        private IQuestionService<InsertQuestion> _insertQuestionService;

        private ITaskService<SentenceTask, SentenceQuestion> _sentenceTaskService;
        private IQuestionService<SentenceQuestion> _sentenceQuestionService;

        private ITaskService<VocabluaryTask, VocabluaryQuestion> _vocabluaryTaskService;
        private IQuestionService<VocabluaryQuestion> _vocabluaryQuestionService;


        Serializer serializer = new Serializer();

        public TestModel(IStudentService service, ITaskService<GrammaTask, GrammaQuestion> taskService,
            IQuestionService<GrammaQuestion> questionService, ITaskService<InsertTask, InsertQuestion> insertTaskService,
            IQuestionService<InsertQuestion> insertQuestionService, ITaskService<SentenceTask, SentenceQuestion> sentenceTaskService,
            IQuestionService<SentenceQuestion> sentenceQuestionService, ITaskService<VocabluaryTask, VocabluaryQuestion> vocabluaryTaskService,
            IQuestionService<VocabluaryQuestion> vocabluaryQuestionService)
        {
            _studentService = service;
            _grammaTaskService = taskService;
            _questionService = questionService;

            _insertTaskService = insertTaskService;
            _insertQuestionService = insertQuestionService;

            _sentenceTaskService = sentenceTaskService;
            _sentenceQuestionService = sentenceQuestionService;

            _vocabluaryTaskService = vocabluaryTaskService;
            _vocabluaryQuestionService = vocabluaryQuestionService;

        }

        [BindProperty]
        public Student Student { get; set; }

        

      
        public async Task<IActionResult> OnGet(int id)
        {
            Student =  _studentService.GetByIdAsync(id).Result;

            Student._GrammaList = _grammaTaskService.ListAsync((x) => x.Student.Id == id).Result;
            foreach (var item in Student._GrammaList)
            {
                item.questions = _questionService.ListAsync((x)=> x.task.Id == item.Id).Result;
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

            if (Student == null || Student._GrammaList == null) {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

       
    }
}
