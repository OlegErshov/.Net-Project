﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Questions
{
    public class AnswerTemplate
    {
        public string StringAnswer { get; set; }
        [AutoIncrement]
        public int Id { get; set; }

    }
}
