using OOP.NewFormOfQuestions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.QuestionFabrics
{
    public class VocabluaryFabric : IQuestionFabric
    {
        public IQuestion Create(QuestionTemplate question)
        {
            VocabluaryQuestion q = new VocabluaryQuestion(question.Sentence, question.letters, question.Answer);
            return q;
        }
    }
}
