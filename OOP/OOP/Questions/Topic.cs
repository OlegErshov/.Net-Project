using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OOP.Enums;

namespace OOP.Questions
{
    public class Topic
    {
        public TopicTypes Type
        {
            get => default;
            set
            {
            }
        }

        public List<object> Questions
        {
            get => default;
            set
            {
            }
        }

        public void AddQuestion(string question, string ans)
        {
            if (Type == TopicTypes.Gramma)
            {
                GrammaQuestion gr = new GrammaQuestion(question, ans);
                Questions.Add(gr);
            }

        }

        public void RemoveQuestion(string question, string ans)
        {
            if (Type == TopicTypes.Gramma)
            {
                // Questions.RemoveAll(x => x.);
            }
        }
    }
}