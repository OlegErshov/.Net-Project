
﻿using Plugin.Authorization;
using Plugin.Questions;
using SQLite;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Tasks
{

    public class VocabluaryTask : TaskTemplate<VocabluaryQuestion>
    {
        public Student Student { get; set; }

        public VocabluaryTask()
        {
            questions= new List<VocabluaryQuestion>();
        }

        void AddQuestion(string text, string letters, string answer)
        {
            VocabluaryQuestion q = new VocabluaryQuestion(text, letters, answer);
            questions.Add(q);
        }

        List<bool> CheakAll(List<string> list)
        {
            List<bool> result = new List<bool>();
            for (int i = 0; i < questions.Count; i++)
            {

             //   if (questions[i].answer == list[i])
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
