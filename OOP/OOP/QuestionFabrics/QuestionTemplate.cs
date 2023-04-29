using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.QuestionFabrics
{
    public class QuestionTemplate
    {
        public string Sentence { get; set; }
        public List<string> AnswerVarients { get; set; }
        public List<string> rightAnswer { get; set; }

        public string? word { get; set; }

        public List<string>? Words { get; set; }

        public string? Answer { get; set; }

        public string? letters { get; set; }

        public List<string> _questions { get; set; }


    }
}
