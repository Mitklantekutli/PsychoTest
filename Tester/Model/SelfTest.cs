using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.Model
{
    class SelfTest : ITest
    {
        public List<int> Answers { get; set; }
        public int QuestionsNumber { get; set; }
        public string Name => "Оценка страха";
        public string Info => $"Оценка страха: {SelfMark}";
        public string Story => "Введите оценку страха";
        public int SelfMark { get; set; }
        public void Calculate()
        {
            if (Answers.Count!=QuestionsNumber)
                return;
            SelfMark = Answers[0];
        }

        public SelfTest()
        {
            QuestionsNumber = 1;
        }
        public override string ToString()
        {
            return Info;
        }
    }
}
