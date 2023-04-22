using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP.Questions
{
    public interface IQuestionFabric
    {

        string Question { get; set; }
        int AnswerByInt { get; set; }
        string AnswerByString { get; set; }



        bool cheakAnswer(string ans);

        bool cheakAnswer(int ans);
    }
}