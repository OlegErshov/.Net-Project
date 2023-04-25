using OOP.NewFormOfQuestions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Tasks
{
    internal class VocabluaryTask
    {
        public List<VocabluaryQuestion> questions { get; set; }

        void AddQuestion(string text, string letters, string answer)
        {
            VocabluaryQuestion q = new VocabluaryQuestion(text, letters, answer);
            questions.Add(q);
        }

        List<bool> CheakAll(List<string> list)
        {
            List<bool> result = new List<bool>();
            for(int i = 0; i < questions.Count; i++)
            {
                if (questions[i].answer == list[i])
                {
                    result.Add(true);
                }
                else
                {
                    result.Add(false);
                }
            }
            return result;
        }
    }
}
