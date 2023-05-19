using Plugin.Authorization;
using Plugin.Questions;
using Plugin.QuestionsFabrics;
using Plugin.Tasks;
using Repository.Repositories;
using Repository.Repositories.QuestionsRepositories;
using Repository.Repositories.TasksRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Student> StudentRepository { get; }
        IRepository<Teacher> TeacherRepository { get; }



        ITaskRepository<GrammaTask,GrammaQuestion> GrammaTaskRepository { get; }

        ITaskRepository<InsertTask, InsertQuestion> InsertTaskRepository { get;  }

        ITaskRepository<VocabluaryTask, VocabluaryQuestion> VocabluaryTaskRepository { get;  }

        ITaskRepository<SentenceTask, SentenceQuestion> SentenceTaskRepository { get;}


        IQuestionRepository<GrammaQuestion> GrammaQuestionRepository { get; }
        IQuestionRepository<InsertQuestion> InsertQuestionRepository { get; }
        IQuestionRepository<VocabluaryQuestion> VocabluaryQuestionRepository { get; }
        IQuestionRepository<SentenceQuestion> SentenceQuestionRepository { get; }




        public Task RemoveDatbaseAsync();
        public Task CreateDatabaseAsync();
        public Task SaveAllAsync();
    }
}
