using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP.Questions;

namespace OOP
{
    internal class Lesson
    {
        List<Question>? questions;
        void AddQuestion(List<string> question, List<string> answer, List<string> words) 
        {
            Question q = new Question(question, answer, words);
            questions?.Add(q);
        }
        
        void RemoveQuestion(List<string> question)
        {
            questions.RemoveAll(x => x.question == question);
        }
    }
}
