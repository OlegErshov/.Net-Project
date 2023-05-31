
﻿using Plugin.Tasks;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Questions
{

    [Serializable]
    public class GrammaQuestion : AnswerTemplate
    {
        // представляет вопрос вида предложение с пропущенным местом/ами для вставки грамматических конструкций
        
        public string Sentence { get; set; }
        public string AnswerVarients { get; set; }

        public GrammaTask task { get; set; } = new();
        

        public GrammaQuestion(string sentence, string varients, string answer)
        {
            Sentence = sentence;
            AnswerVarients = varients;

            StringAnswer = answer;

        }

        public GrammaQuestion() { }
        public bool Cheak(AnswerTemplate ansTemp)
        {
            List<string> answer = new List<string>();
           // List<int> indexes = ansTemp.IntListAnswer;

            //foreach (var item in indexes)
            //{
            //    answer.Add(AnswerVarients[item]);
            //}

            //for (int i = 0; i < answer.Count; i++)
            //{
            //    if (answer[i] != rightAnswer[i])
            //    {
            //        return false;
            //    }
            //}

            return true;
        }
    }
}
