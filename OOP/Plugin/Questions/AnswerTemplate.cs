using SQLite;
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

        public int RightOrNot { get; set; } = 0; // 0 - no answer 1 - right answer -1  - wrong answer

    }
}
