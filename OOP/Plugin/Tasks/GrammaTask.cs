
﻿using Plugin.Authorization;
using Plugin.Questions;
using Plugin.QuestionsFabrics;
using SQLite;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Tasks
{

    public class GrammaTask : TaskTemplate<GrammaQuestion>
    {
        
        public Student Student { get; set; }
        
        public GrammaTask() {
            questions = new List<GrammaQuestion>();
        }

        public void AddQuestion(string sent, string varients, string answer)
        {
           //QuestionTemplate ques = new QuestionTemplate();
            //ques.GrammaQuestion(sent, varients, answer);
          //  GrammaFabric grammaFabric = new GrammaFabric();

            GrammaQuestion gr = new GrammaQuestion(sent, varients, answer);
            if(questions == null) { 
                questions = new List<GrammaQuestion>();
            }
            questions?.Add(gr);

        }



        void AddQuestion(GrammaQuestion question)
        {
            questions.Add(question);
        }

        // проверить сразу все монжо храня лист листов ответов пользователя, но зачем, если можно по одному проверять
    }
}
