using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP.Questions
{
    public class GrammaQuestion : IQuestionFabric
    {
        public GrammaQuestion(string question, string ans)
        {
            Question = question;
            AnswerByString = ans;
        }
        public string Question { get; set; }
        public int AnswerByInt { get; set; }
        public string AnswerByString { get; set; }


        public bool cheakAnswer(string ans)
        {
            if (ans == AnswerByString)
            {
                return true;
            }
            return false;
        }

        public bool cheakAnswer(int ans)
        {
            if (ans == AnswerByInt)
            {
                return true;
            }
            return false;
        }
    }
}