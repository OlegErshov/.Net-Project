using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Questions
{
    public class InsertQuestion : AnswerTemplate
    {
        // вопрос предназначенный для вставки подходящего по смыслу из списка, который хрнаится в задании такого типа
        
       
        
        public string? Sentence { get; set; }

        public InsertQuestion(string answer, string? sentence)
        {
            StringAnswer = answer;
            this.Sentence = sentence;
        }

        public bool Cheak(AnswerTemplate ans)
        {
            string answer = ans.StringAnswer;
           // if (answer == word) { return true; }
            return false;
        }
    }
}
