﻿using Plugin.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.QuestionsFabrics
{
    public class SentenceFabric : IQuestionFabric
    {
        public IQuestion Create(QuestionTemplate question)
        {
            SentenceQuestion q = new SentenceQuestion(question.Words, question.Answer);
            return q;
        }
    }
}