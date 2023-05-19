using Plugin.Authorization;
using Plugin.Questions;
using Plugin.Tasks;
using Repository.Data;
using Repository.Repositories;
using Repository.Repositories.QuestionsRepositories;
using Repository.Repositories.TasksRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Student>> _studentRepository;
        private readonly Lazy<IRepository<Teacher>> _teacherRepository;

        private readonly Lazy<ITaskRepository<GrammaTask,GrammaQuestion>> _grammaTaskRepository;
        private readonly Lazy<ITaskRepository<InsertTask, InsertQuestion>> _insertTaskRepository;

        private readonly Lazy<ITaskRepository<VocabluaryTask, VocabluaryQuestion>> _vocabluaryTaskRepository;
        private readonly Lazy<ITaskRepository<SentenceTask, SentenceQuestion>> _sentenceTaskRepository;

        private readonly Lazy<IQuestionRepository<GrammaQuestion>> _grammaQuestionRepository;
        private readonly Lazy<IQuestionRepository<InsertQuestion>> _insertQuestionRepository;

        private readonly Lazy<IQuestionRepository<VocabluaryQuestion>> _vocabluaryQuestionRepository;
        private readonly Lazy<IQuestionRepository<SentenceQuestion>> _sentenceQuestionRepository;

        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
            _studentRepository = new Lazy<IRepository<Student>>(() =>
            new EfRepository<Student>(context));
            _teacherRepository = new Lazy<IRepository<Teacher>>(() =>
            new EfRepository<Teacher>(context));


            _grammaTaskRepository = new Lazy<ITaskRepository<GrammaTask, GrammaQuestion>>(() =>
            new EfTaskRepository<GrammaTask, GrammaQuestion>(context));
            _insertTaskRepository = new Lazy<ITaskRepository<InsertTask, InsertQuestion>>(() =>
            new EfTaskRepository<InsertTask, InsertQuestion>(context));

            _vocabluaryTaskRepository = new Lazy<ITaskRepository<VocabluaryTask, VocabluaryQuestion>>(() =>
            new EfTaskRepository<VocabluaryTask, VocabluaryQuestion>(context));
            _sentenceTaskRepository = new Lazy<ITaskRepository<SentenceTask, SentenceQuestion>>(() =>
            new EfTaskRepository<SentenceTask, SentenceQuestion>(context));

            _grammaQuestionRepository = new Lazy<IQuestionRepository<GrammaQuestion>>(() =>
            new EfQuestionRepository<GrammaQuestion>(context));
            _insertQuestionRepository = new Lazy<IQuestionRepository<InsertQuestion>>(() =>
            new EfQuestionRepository<InsertQuestion>(context));

            _vocabluaryQuestionRepository = new Lazy<IQuestionRepository<VocabluaryQuestion>>(() =>
            new EfQuestionRepository<VocabluaryQuestion>(context));
            _sentenceQuestionRepository = new Lazy<IQuestionRepository<SentenceQuestion>>(() =>
            new EfQuestionRepository<SentenceQuestion>(context));


        }

        public IRepository<Student> StudentRepository => _studentRepository.Value;
        public IRepository<Teacher> TeacherRepository => _teacherRepository.Value;



        public ITaskRepository<GrammaTask,GrammaQuestion> GrammaTaskRepository=> _grammaTaskRepository.Value;
        public ITaskRepository<InsertTask, InsertQuestion> InsertTaskRepository => _insertTaskRepository.Value;
        public ITaskRepository<SentenceTask, SentenceQuestion> SentenceTaskRepository => _sentenceTaskRepository.Value;
        public ITaskRepository<VocabluaryTask, VocabluaryQuestion> VocabluaryTaskRepository => _vocabluaryTaskRepository.Value;



        public IQuestionRepository<GrammaQuestion> GrammaQuestionRepository => _grammaQuestionRepository.Value;
        public IQuestionRepository<InsertQuestion> InsertQuestionRepository => _insertQuestionRepository.Value;
        public IQuestionRepository<VocabluaryQuestion> VocabluaryQuestionRepository => _vocabluaryQuestionRepository.Value;
        public IQuestionRepository<SentenceQuestion> SentenceQuestionRepository => _sentenceQuestionRepository.Value;




        public async Task CreateDatabaseAsync()
        {
            await _context.Database.EnsureCreatedAsync();
        }
        public async Task RemoveDatbaseAsync()
        {
            await _context.Database.EnsureDeletedAsync();
        }
        public async Task SaveAllAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
