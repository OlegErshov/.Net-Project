using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Questions
{
    public class SentenceQuestion : AnswerTemplate
    {
        // вопрос для граммаики, приведен список слов основных и нужно добавить грам структуры для формирования предложения
        
        public string Words { get; set; }

        

        public SentenceQuestion(string words, string answer)
        {
            Words = words;
            StringAnswer = answer;
        }

        public SentenceQuestion()
        {

        }

        public bool Cheak(AnswerTemplate ans)
        {
            string str = ans.StringAnswer;
            if (str == Answer) return true;
            return false;
        }

    }
}
