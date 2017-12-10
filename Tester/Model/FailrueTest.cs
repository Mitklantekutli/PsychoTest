using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.Model
{
    class FailrueTest : ITest
    {
        public List<int> Answers { get; set; }
        public int QuestionsNumber { get; set; }
        public string Name => "Мотивация избегания неудач";
        public string Story => "Варианты ответов 1, 2, 3";
        public string Info
        {
            get
            {
                if (Result == 0)
                    return "Не заполнено";
                var description = "";
                if (Result > 20)
                    description = "Слишком высокий уровень мотивации";
                else if (Result > 16)
                    description = "Выоский уровень мотивации";
                else if (Result > 10)
                    description = "Средний уровень мотивации";
                else
                    description = "Низкая мотивация к защите";
                
                return $"{description} ({Result})";
            }
        }
        public int Result { get; set; }
        public void Calculate()
        {
            if (Answers.Count < QuestionsNumber)
                return;

            #region Data

            var src = @"1-2
            2 - 1
            2 - 2
            3 - 1
            3 - 3
            4 - 3
            5 - 2
            6 - 3
            7 - 2
            7 - 3
            8 - 3
            9 - 1
            9 - 2
            10 - 2
            11 - 1
            11 - 2
            12 - 1
            12 - 3
            13 - 2
            13 - 3
            14 - 1
            15 - 1
            16 - 2
            16 - 3
            17 - 3
            18 - 1
            19 - 1
            19 - 2
            20 - 1
            20 - 2
            21 - 1
            22 - 1
            23 - 1
            23 - 3
            24 - 1
            24 - 2
            25 - 1
            26 - 2
            27 - 3
            28 - 1
            28 - 2
            29 - 1
            29 - 3
            30 - 2";

            #endregion

            var parts = src.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            var pp = parts.Select(x => x.Split('-').Select(y=>int.Parse(y)).ToList()).ToList();
            var ps = pp.Select(x => 3 * (x[0] - 1) + x[1]).ToList();
            var counter = 0;
            Result = 0;
            Answers.ForEach(x =>
            {
                var answer = counter * 3 + x;
                if (ps.Contains(answer))
                    Result++;
                counter++;
            });
        }

        public FailrueTest()
        {
            QuestionsNumber = 30;
            Answers = new List<int>();
        }

        public override string ToString()
        {
            return Info;
        }
    }
}
