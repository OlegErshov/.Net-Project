using Plugin.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.QuestionsFabrics
{
    public class GrammaFabric : IQuestionFabric
    {
        public IQuestion Create(QuestionTemplate question)
        {
            GrammaQuestion q = new GrammaQuestion();
            return q;
        }
    }
}
