using System;
using System.Collections.Generic;
using System.Linq;

namespace Tester.Model
{
    public class PersonalTest : ITest
    {
        public List<int> Answers { get; set; }
        public int QuestionsNumber { get; set; }
        public string Name => "Личностный опросник";
        public string Story => "Варианты ответов 1 - ДА, 2 - НЕТ";

        // Надежность
        public int Reliability { get; set; }
        
        // Адаптивность
        public int Adaptation { get; set; }
        public int AdaptationWall { get; set; }
        // Нервно психическая стабильность
        public int Neurostability { get; set; }
        public int NeurostabilityWall { get; set; }
        // Коммуникативность
        public int Communication { get; set; }
        public int CommunicationWall { get; set; }
        // Моральная устойчивость
        public int Moral { get; set; }
        public int MoralWall { get; set; }
        

        public string Info
        {
            get
            {
                return $"ДОСТ {Reliability} " +
                       $"ЛАП {AdaptationWall}({Adaptation}) " +
                       $"НПУ {NeurostabilityWall}({Neurostability}) " +
                       $"КС {CommunicationWall}({Communication}) " +
                       $"МН {MoralWall}({Moral})";
            }
        }

        public PersonalTest()
        {
            Answers = new List<int>();
            QuestionsNumber = 165;
        }

        public void Calculate()
        {
            if (Answers.Count!=QuestionsNumber)
                return;

            #region Answers
            var fillPositive = new Action<Dictionary<int,int>,List<int>>((x, y) =>
            {
                y.ForEach(a => x.Add(a, 1));
            });
            var fillNegative = new Action<Dictionary<int, int>, List<int>>((x, y) =>
            {
                y.ForEach(a => x.Add(a, 2));
            });
            var counter = new Func<Dictionary<int,int>, List<int>, int>((pattern, answers) =>
            {
                return pattern.Count(x => pattern[x.Key] == answers[x.Key - 1]);
            });
            var getWall = new Func<int[], int, int>((arr, value) =>
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (value >= arr[i])
                        return i + 1;
                }
                return -1;
            });

            var positiveReliabilityAnswers = new List<int>
            {
                1, 10, 19, 31, 51, 69, 78, 92, 101, 116, 128, 138, 148
            };
            var reliabilityAnswers = new Dictionary<int, int>();
            fillNegative(reliabilityAnswers, positiveReliabilityAnswers);

            var positiveAdaptationAnswers = new List<int>
            {
                4, 6, 7, 8, 9, 11, 12, 14, 15, 16, 17, 18, 20, 21, 22, 24, 27, 28, 29, 30, 33, 36,
                37, 39, 40, 41, 42, 43, 46, 47, 50, 56, 57, 59, 60, 61, 63, 64, 65, 67, 68, 70, 71,
                72, 73, 75, 77, 79, 80, 81, 82, 83, 84, 86, 88, 89, 90, 91, 93, 94, 95, 96, 98, 99,
                102, 103, 104, 106, 108, 109, 110, 111, 112, 113, 114, 115, 117, 118, 119, 120, 121,
                122, 123, 124, 125, 126, 129, 131, 133, 135, 136, 137, 139, 141, 142, 143, 145, 146,
                149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 161, 162, 164, 165
            };
            var negativeAdaptationAnswers = new List<int>
            {
                2, 3, 5, 13, 23, 25, 26, 32, 34, 35, 38, 44, 45, 48, 49, 52, 53, 54, 55, 58, 62, 66,
                74, 76, 85, 87, 97, 100, 105, 107, 127, 130, 132, 134, 140, 144, 147, 159, 160, 163
            };
            var adaptationAnswers = new Dictionary<int, int>();
            fillNegative(adaptationAnswers, negativeAdaptationAnswers);
            fillPositive(adaptationAnswers, positiveAdaptationAnswers);

            var positiveNeuroStabilityAnswers = new List<int> { 4, 6, 7, 8, 11, 12, 15, 16, 17, 18, 20, 21, 28, 29, 30, 37, 39, 40, 41, 47, 57, 60, 63, 65, 67, 68, 70, 71, 73, 75, 80, 82, 83, 84, 86, 89, 94, 95, 96, 98, 102, 103, 108, 109, 110, 111, 112, 113, 115, 117, 118, 119, 120, 122, 123, 124, 129, 131, 135, 136, 137, 139, 143, 146, 149, 153, 154, 155, 156, 157, 158, 161, 162};
            var negativeNeuroStabilityAnswers = new List<int> { 2, 3, 5, 23, 25, 32, 38, 44, 45, 49, 52, 53, 54, 55, 58, 62, 66, 87, 105, 127, 132, 134, 140 };
            var neurostabilityAnswers = new Dictionary<int,int>();
            fillPositive(neurostabilityAnswers, positiveNeuroStabilityAnswers);
            fillNegative(neurostabilityAnswers, negativeNeuroStabilityAnswers);

            var positiveCommunicationAnswers = new List<int> { 9, 24, 27, 33, 46, 61, 64, 81, 88, 90, 99, 104, 106, 114, 121, 126, 133, 142, 151, 152};
            var negativeCommunicationAnswers = new List<int> { 26, 34, 35, 48, 74, 85, 107, 130, 144, 147, 159 };
            var communicationAnswers = new Dictionary<int, int>();
            fillPositive(communicationAnswers, positiveCommunicationAnswers);
            fillNegative(communicationAnswers, negativeCommunicationAnswers);

            var positiveMoralAnswers = new List<int> { 14, 22, 36, 42, 50, 56, 59, 72, 77, 79, 91, 93, 125, 141, 145, 150, 164, 165};
            var negativeMoralAnswers = new List<int> { 13, 76, 97, 100, 160, 163};
            var moralAnswers = new Dictionary<int, int>();
            fillPositive(moralAnswers, positiveMoralAnswers);
            fillNegative(moralAnswers, negativeMoralAnswers);

            #endregion

            Reliability = counter(reliabilityAnswers , Answers);
            Adaptation = counter(adaptationAnswers, Answers);
            Neurostability = counter(neurostabilityAnswers, Answers);
            Communication = counter(communicationAnswers, Answers);
            Moral = counter(moralAnswers, Answers);

            var adaptationWalls = new int[] { 62, 51, 40, 33, 28, 22, 16, 11, 6, 1 };
            AdaptationWall = getWall(adaptationWalls, Adaptation);
            var neurostabilityWalls = new int[] { 46, 38, 30, 22, 16, 13, 9, 6, 4, 0 };
            NeurostabilityWall = getWall(neurostabilityWalls, Neurostability);
            var communicationWalls = new int[] { 27, 22, 17, 13, 10, 7, 5, 3, 1, 0 };
            CommunicationWall = getWall(communicationWalls, Communication);
            var moralWalls = new int[] { 18, 15, 12, 10, 7, 5, 3, 2, 1, 0 };
            MoralWall = getWall(moralWalls, Moral);

        }
        public override string ToString()
        {
            return Info;
        }
    }
}
