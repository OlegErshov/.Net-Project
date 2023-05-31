
﻿using Plugin.Tasks;

namespace Plugin.Questions
{
    public class VocabluaryQuestion : AnswerTemplate
    {
        
        public string? Text { get; set; } // смысловое предложение
        public string? letters { get; set; } // набор символов из которых состоит нужное слово

        public VocabluaryTask task { get; set; }
       

        public VocabluaryQuestion(string text, string letters, string stringAnswer)
        {
            Text = text;
            this.letters = letters;
            StringAnswer = stringAnswer;



        }
        public bool Cheak(AnswerTemplate answ)
        {
            string ans = answ.StringAnswer;

           // if (ans == answer) return true;
            if (ans == answer) return true;

            return false;
        }
    }
}
