using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.NewFormOfQuestions
{
    public class TranslateQuestion
    {
         public List<string> _questions { get; set; }  // состоит из слов, в угоду времени взят лист,

        public List<string>? _answer { get; set; }    // чтоб потом просто проходить по листу, чем делить строку на слова

        List<string>? wordsVarients { get; set; }

        public void AddWordsVarients(List<string> words)
        {
            wordsVarients = words;
        }

        public void AddAnswer(List<string> answer) {
            _answer = answer;
        }

        public void AddQuestion(List<string> question) {
            _questions = question;
        }

        public bool Cheak(List<string> answer) {
            for(int i = 0; i < answer.Count(); i++)
            {
                if (answer[i] != _answer[i])
                {
                    return false;
                }
            }
            return true;
        }

        public List<string> stringDivisionOnwords(string s)
        {
            List<string> a;
            a = s.Split(' ').ToList<string>();
            return a;
        }
    }
}
