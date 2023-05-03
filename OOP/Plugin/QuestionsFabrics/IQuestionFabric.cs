using Plugin.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.QuestionsFabrics
{
    public interface IQuestionFabric
    {
        public IQuestion Create(QuestionTemplate question);

    }
}
