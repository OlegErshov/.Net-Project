﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Questions
{
    public interface IQuestion
    {
        public bool Cheak(AnswerTemplate answer);

    }
}
