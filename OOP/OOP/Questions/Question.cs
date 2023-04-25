 using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP.VoiceService;

namespace OOP.Questions
{
    internal class Question : Voice
    {
        public List<string>? question { get; set; }
      //  public List<string>? Answer { get; set; }


        public List<string> Answer { get; set; }

        public Question(List<string> q, List<string> a)
        {
            question = q;
            Answer = a;
           ;
        }

        bool CheakAnswer(List<string> answer)
        {
            var result = Answer.Except(answer);
            if (result == null)
            {
                return false;
            }
            return true;
        }
    }
}
