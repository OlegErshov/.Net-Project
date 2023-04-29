using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.NewFormOfQuestions
{

    internal class SentenceQuestion : IQuestion

    {
        // вопрос для граммаики, приведен список слов основных и нужно добавить грам структуры для формирования предложения
        public List<string>? Words { get; set; }

        public string? Answer { get; set; }  

        public SentenceQuestion(List<string> words, string answer) {

            Words = words;
            Answer = answer;
        }


        public bool Cheak(AnswerTemplate ans)
        {
            string str = ans.StringAnswer;
            if(str == Answer) return true;
            return false;
        }


    }
}
