using OOP.NewFormOfQuestions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Tasks
{
    internal class InsertTask
    {
        List<string> words { get;set; }
        List<InsertQuestion> questions { get;set; }

        public void addQuestion(string sentence,string word)
        {
            InsertQuestion q = new InsertQuestion(sentence,word);
            words.Add(word);
        }

        public bool CheakOneSentence(int questionIndex,int wordIndex)
        {
            if (questions[questionIndex].word == words[wordIndex])
            {
                return true;
            }
            return false;
        }
    }
}
