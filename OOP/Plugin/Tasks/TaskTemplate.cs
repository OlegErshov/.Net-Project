using Plugin.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Tasks
{
    public class TaskTemplate <T> where T : AnswerTemplate
    {
        public int Id { get; set; }

        public List<T> questions { get; set; }

    }
}
