using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.Model
{
    class MotivationTest : ITest
    {
        public List<int> Answers { get; set; }
        public List<int> ValidAnswers { get; }
        public int QuestionsNumber { get; set; }
        public int Motivation { get; set; }
        public string Description { get; set; }
        public string Name => "Мотивация к успеху";
        public string Story => "Варианты ответов 1 - ДА, 2 - НЕТ";
        public string Info
        {
            get
            {
                return $"{Description} ({Motivation})";
            }
        }

        public MotivationTest()
        {
            QuestionsNumber = 41;
            Answers = new List<int>();
        }

        public void Calculate()
        {

            if (Answers.Count!=QuestionsNumber)
                return;

            var fillPositive = new Action<Dictionary<int, int>, List<int>>((x, y) =>
            {
                y.ForEach(a => x.Add(a, 1));
            });
            var fillNegative = new Action<Dictionary<int, int>, List<int>>((x, y) =>
            {
                y.ForEach(a => x.Add(a, 2));
            });
            var counter = new Func<Dictionary<int, int>, List<int>, int>((pattern, answers) =>
            {
                return pattern.Count(x => pattern[x.Key] == answers[x.Key - 1]);
            });

            var positiveAnswers = new List<int>{2, 3, 4, 5, 7, 8, 9, 10, 14, 15, 16, 17, 21, 22, 25, 26, 27, 28, 29, 30, 32, 37, 41};
            var negativeAnswers = new List<int> {6, 13, 18, 20, 24, 31, 36, 38, 39};
            var template = new Dictionary<int, int>();
            fillPositive(template, positiveAnswers);
            fillNegative(template, negativeAnswers);
            Motivation = counter(template, Answers);



            //1-10 Низкая мотивация
            //11-16 Средняя мотивация
            //17-20 Умеренно высокий мотивация
            //21 Слишком высокий мотивация
            if (Motivation > 20)
            {
                Description = "Слишком высокий мотивация";
            }
            else if (Motivation > 16)
            {
                Description = "Умеренно высокий мотивация";
            }
            else if (Motivation > 10)
            {
                Description = "Средняя мотивация";
            }
            else
            {
                Description = "Низкая мотивация";
            }

        }

        public bool Validate()
        {
            return Answers.All(ValidAnswers.Contains);
        }

        public override string ToString()
        {
            return Info;
        }
    }
}
