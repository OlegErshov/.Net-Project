using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Questions
{
    public class VocabluaryQuestion : AnswerTemplate
    {
        
        public string? Text { get; set; } // смысловое предложение
        public string? letters { get; set; } // набор символов из которых состоит нужное слово
       

        public VocabluaryQuestion(string text, string letters, string answer)
        {
            Text = text;
            this.letters = letters;
            StringAnswer = answer;


        }
        public bool Cheak(AnswerTemplate answ)
        {
            string ans = answ.StringAnswer;
            if (ans == answer) return true;
            return false;
        }
    }
}
