using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.NewFormOfQuestions
{
    internal class GrammaQuestion
    {
        // представляет вопрос вида предложение с пропущенным местом/ами для вставки грамматических конструкций
        public string Sentence { get; set; }
        public List<string> AnswerVarients { get; set; }
        public List<string> rightAnswer { get; set; }

        public GrammaQuestion(string sentence, List<string> varients, List<string> answer) {
            Sentence = sentence;
            AnswerVarients = varients;
            rightAnswer= answer;
        }

        public bool Cheak(List<int> indexes)
        {
            List<string> answer = new List<string>();

            foreach (var item in indexes)
            {
                answer.Add(AnswerVarients[item]);
            }

            for (int i = 0; i < answer.Count; i++) {
                if (answer[i] != rightAnswer[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
