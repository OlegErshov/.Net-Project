using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Questions
{
    internal class Lesson
    {
        List<Question>? questions;
        void AddQuestion(List<string> question, List<string> answer)
        {
            Question q = new Question(question, answer);
            questions?.Add(q);
        }

        void addQuestion(Question question)
        {
            questions?.Add(question);
        }

        void RemoveQuestion(List<string> question)
        {
            questions.RemoveAll(x => x.question == question);
        }
    }
}
