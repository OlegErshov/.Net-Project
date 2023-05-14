using Plugin.Questions;
using Plugin.QuestionsFabrics;
using Plugin.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public  class FakeTaskRepository : ITaskRepository
    {
        private List<GrammaTask>? _GrammaList;
        private List<InsertTask>? _InsertList;
        private List<SentenceTask>? _SentenceList;
        private List<VocabluaryTask>? _VocabluaryList;

        public FakeTaskRepository()
        {
            _GrammaList = new List<GrammaTask>();
            GrammaTask task = new GrammaTask();
            //List<IQu> questionList = new List<IQuestion>();

            List<string> varients = new List<string>() { "the", "a", "an", "-" };
            List<string> answer = new List<string>() { "the" };
            task.AddQuestion("enter the right article", varients, answer);

            varients = new List<string>() { "do", "does", "was", "were" };
            answer = new List<string>() { "does" };
            task.AddQuestion("enter the right verb", varients, answer);

            varients = new List<string>() { "in", "on", "at", "between" };
            answer = new List<string>() { "at" };
            task.AddQuestion("enter the right preposition", varients, answer);
            _GrammaList.Add(task);
        }

        public IEnumerable<GrammaTask> getAllGrammaTasks()
        {
            return _GrammaList;
        }
    }

    
}

