using Plugin.Authorization;
using Plugin.Questions;
using Plugin.QuestionsFabrics;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Tasks
{
    public class InsertTask : TaskTemplate<InsertQuestion>
    {
       
        public string? words { get; set; }
        public Student Student { get; set; }

        public InsertTask()
        {
            questions = new List<InsertQuestion>();
        }
        public void addQuestion(string sentence, string word)
        {
            //QuestionTemplate ques = new QuestionTemplate();
            //ques.InsertQuestion(word, sentence);
            //InsertFabric insertFabric = new InsertFabric();
            //questions.Add(insertFabric.Create(ques));
            //words.Add(word);
        }

    }
}
