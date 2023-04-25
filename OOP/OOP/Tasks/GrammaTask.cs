using OOP.NewFormOfQuestions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Tasks
{
    internal class GrammaTask
    {
        List<GrammaQuestion> questions { get; set; }    

        void  AddQuestion(string sent,List<string> varinets, List<string> answer)
        {
            GrammaQuestion q = new GrammaQuestion(sent, varinets, answer);
            questions.Add(q);
        }

        void AddQuestion(GrammaQuestion question)
        {
            questions.Add(question);
        }

       // проверить сразу все монжо храня лист листов ответов пользователя, но зачем, если можно по одному проверять
    }
}
