using Plugin.Questions;
using Plugin.QuestionsFabrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Tasks
{
    public class InsertTask
    {
        List<string> words { get; set; }

        List<IQuestion> questions { get; set; }

        public void addQuestion(string sentence, string word)
        {
            QuestionTemplate ques = new QuestionTemplate();
            ques.InsertQuestion(word, sentence);
            InsertFabric insertFabric = new InsertFabric();
            questions.Add(insertFabric.Create(ques));
            words.Add(word);
        }

    }
}
