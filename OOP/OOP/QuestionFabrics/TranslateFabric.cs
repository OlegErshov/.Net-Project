using OOP.NewFormOfQuestions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.QuestionFabrics
{
    public class TranslateFabric : IQuestionFabric
    {
        public IQuestion Create(QuestionTemplate ques)
        {
            TranslateQuestion q = new TranslateQuestion(ques._questions, ques.rightAnswer, ques.AnswerVarients);
            return q;
        }
    }
}
