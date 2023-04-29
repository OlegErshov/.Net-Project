
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Tasks
{
    internal class GrammaTask
    {

        List<IQuestion> questions { get; set; }    

        void  AddQuestion(string sent,List<string> varients, List<string> answer)
        {
            QuestionTemplate ques = new QuestionTemplate();
            ques.GrammaQuestion(sent,varients,answer);
            GrammaFabric grammaFabric= new GrammaFabric();
        
            questions.Add(grammaFabric.Create(ques));
        }



        void AddQuestion(GrammaQuestion question)
        {
            questions.Add(question);
        }

       // проверить сразу все монжо храня лист листов ответов пользователя, но зачем, если можно по одному проверять
    }
}
