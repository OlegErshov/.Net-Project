using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Question : Voice
    {
        public List<string>? question { get; set; }
        public List<string>? Answer { get; set; }  

        public List<string>? Words { get; set; }

        public Question(List<string> q, List<string> a, List<string> w) {
            this.question = q;
            this.Answer = a;
            this.Words = w;
        }

        bool CheakAnswer(List<string> answer)
        {
            var result = Answer.Except(answer);
            if(result == null)
            {
                return false; 
            }
            return true;
        }
    }
}
