using OOP.NewFormOfQuestions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.QuestionFabrics
{
    public class InsertFabric : IQuestionFabric
    {

        public IQuestion Create(QuestionTemplate question)
        {
            InsertQuestion q = new InsertQuestion(question.word, question.Sentence);
            return q;
        }
    }
}
