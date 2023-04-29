using OOP.NewFormOfQuestions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.QuestionFabrics
{
    public class GrammaFabric : IQuestionFabric
    {
        public IQuestion Create(QuestionTemplate question)
        {
            GrammaQuestion q = new GrammaQuestion(question.Sentence, question.AnswerVarients, question.rightAnswer);
            return q;
        }
    }
}
