using System.Collections.Generic;
using System.Linq;

namespace Tester
{
    public class AnxietyTest : ITest
    {
        public List<int> Answers { get; set; }
        public int SituationalAnxiety { get; set; }
        public int PersonalAnxiety { get; set; }
        public int QuestionsNumber { get; set; }
        public AnxietyTest()
        {
            QuestionsNumber = 40;
            Answers = new List<int>();
        }

        public string Story => "Варианты ответов 1, 2, 3";

        public void Calculate()
        {
            if (Answers.Count < QuestionsNumber)
                return;

            #region Situational

            var s1Indexes = new[] {3, 4, 6, 7, 9, 12, 13, 14, 17, 18};
            var S1 = s1Indexes.Select(x => Answers[x - 1]).Sum();

            var s2Indexes = new[] {1, 2, 5, 8, 10, 11, 15, 16, 19, 20};
            var S2 = s2Indexes.Select(x => Answers[x - 1]).Sum();

            SituationalAnxiety = S1 - S2 + 35;

            #endregion

            #region Personal
            
            var p1Indexes = new[] {2, 3, 4, 5, 8, 9, 11, 12, 14, 15, 17, 18, 20};
            var P1 = p1Indexes.Select(x => Answers[x - 1 + 20]).Sum();

            var p2Indexes = new[] {1, 6, 7, 10, 13, 16, 19};
            var P2 = p2Indexes.Select(x => Answers[x - 1 + 20] ).Sum();

            PersonalAnxiety = P1 - P2 + 35;
            
            #endregion
        }

        public string Name => "Шкала тревожности";
        public string Info
        {
            get
            {
                if (SituationalAnxiety + PersonalAnxiety == 0)
                    return "Не заполнен";

                var sLevel = GetLevel(SituationalAnxiety);
                var pLevel = GetLevel(PersonalAnxiety);

                return $"Ситуационная: {sLevel}({SituationalAnxiety}) Личностная: {pLevel}({PersonalAnxiety})";
            }
        }

        private string GetLevel(int value)
        {
            return (value > 45
                ? "Высокий"
                : value > 30
                    ? "Средний"
                    : "Низкий");
        }
        public override string ToString()
        {
            return Info;
        }
    }
}