using OOP.NewFormOfQuestions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Tasks
{
    internal class SentenceTask
    {
        List<SentenceQuestion> Questions { get; set; }



        public void AddQuestion(List<string>? Words,string ans)
        {

        }

        List<bool> CheakAll(List<string> answers)
        {
            List<bool> result = new List<bool>();
            for(int i = 0; i < Questions.Count; i++)
            {
                if (Questions[i].Answer == answers[i])
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
