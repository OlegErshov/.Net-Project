using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.NewFormOfQuestions
{
    internal class VocabluaryQuestion : IQuestion
    {
        public string? Text { get; set; } // смысловое предложение
        public string? letters { get; set; } // набор символов из которых состоит нужное слово
        public string? answer { get; set; } // само слово

        public VocabluaryQuestion(string t, string l, string a) { 
            Text = t;
            letters = l;
            answer = a;
        }
        public bool Cheak(AnswerTemplate answ)
        {
            string ans = answ.StringAnswer;
            if(ans == answer) return true;
            return false;
        }
    }
}
