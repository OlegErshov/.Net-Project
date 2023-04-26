using OOP.NewFormOfQuestions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.QuestionFabrics
{
    internal interface IQuestionFabric
    {
        public IQuestion Create(QuestionTemplate question);

    }
}
