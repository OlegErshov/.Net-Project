using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.NewFormOfQuestions
{
    internal class InsertQuestion : IQuestion
    {
        // вопрос предназначенный для вставки подходящего по смыслу из списка, который хрнаится в задании такого типа
        public string? word { get; set; }
        public string? sentence { get; set; }

        public InsertQuestion(string? word, string? sentence)
        {
            this.word = word;
            this.sentence = sentence;
        }

        public bool Cheak(AnswerTemplate ans)
        {
            string answer = ans.StringAnswer;
            if(answer == word) { return true; }
            return false;
        }
    }
}
