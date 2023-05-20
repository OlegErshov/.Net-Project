using Plugin.Authorization;
using Plugin.Questions;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Tasks
{
    public class SentenceTask : TaskTemplate<SentenceQuestion>
    {
        public Student Student { get; set; }
        
        public void AddQuestion(List<string>? Words, string ans)
        {
            questions.Add(new SentenceQuestion());
        }

        List<bool> CheakAll(List<string> answers)
        {
            List<bool> result = new List<bool>();
            for (int i = 0; i < questions.Count; i++)
            {
                //if (questions[i].Answer == answers[i])
                //{
                //    result.Add(true);
                //}
                //else
                //{
                //    result.Add(false);
                //}
            }
            return result;
        }

    }
}
