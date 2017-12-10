using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.Model
{
    public class KettelTest : ITest
    {
        public List<int> Answers { get; }
        public int QuestionsNumber { get; set; }
        public string Name => "Тест Кеттела";
        public string Info
        {
            get
            {
                return $"{Md}(MD) {A}(А) {B}(B) {C}(C) " +
                       $"{E}(E) {F}(F) {G}(G) {H}(H) " +
                       $"{I}(I) {L}(L) {M}(M) " +
                       $"{N}(N) {O}(O) {Q1}(Q1) {Q2}(Q2) {Q3}(Q3) {Q4}(Q4)";
            }
            //get { return $"Достовреность:{Md}(MD) Замкнутость:{A}(А) Интеллект:{B}(B) Эмоц.Неустойчивость:{C}(C) " +
            //             $"Подчиненность:{E}(E) Сдержанность:{F}(F) Подверженность чувствам:{G}(G) Робость:{H}(H) " +
            //             $"Жесткость:{I}(I) Доверчивость:{L}(L) Практичность:{M}(M) " +
            //             $"Прямолинейность:{N}(N) Уверенность в себе:{O}(O) Консерватизм:{Q1}(Q1) Конформизм:{Q2}(Q2) Низкий самоконтроль:{Q3}(Q3) Расслабленность:{Q4}(Q4)"; }
    }

    public string Story => "Доступные ответы 1,2,3";

        #region KettelParams
        //MD  - достоверность(адекватност самооценки, как написано в книге)
        public int Md { get; set; }
        //A - замкнутость - общительность
        public int A { get; set; }
        //В - интеллект
        public int B { get; set; }
        //С - эмоциональная неустойчивость - эмоциональная устойчивость
        public int C { get; set; }
        //Е - подчиненность - доминантность
        public int E { get; set; }
        //F - сдержанность - экспрессивность
        public int F { get; set; }
        //G - подверженность чувствам - высокая нормативность поведения
        public int G { get; set; }
        //H - робость - смелость
        public int H { get; set; }
        //I - жесткость - чувствительность
        public int I { get; set; }
        //L - доверчивость - подозрительность
        public int L { get; set; }
        //М - практичность - развитое воображение
        public int M { get; set; }
        //N - прямолинейность - дипломатичность
        public int N { get; set; }
        //О - уверенность в себе - тревожность
        public int O { get; set; }
        //Q1 - консерватизм - радикализм
        public int Q1 { get; set; }
        //Q2 - конформизм - нонкомформизм
        public int Q2 { get; set; }
        //Q3 - низкий самоконтроль - высокий самоконтроль
        public int Q3 { get; set; }
        //Q4 -  расслабленность - напряженность
        public int Q4 { get; set; }

        #endregion

        public void Calculate()
        {
            if (Answers.Count != QuestionsNumber)
                return;
            if (!Answers.All(x => x == 1 || x == 2 | x == 3))
                return;

            #region Template

            var template =
                @"001 - 2 1 0 
002 - 0 1 2 
003 - 0 1 0 
004 - 2 1 0 
005 - 0 1 2 
006 - 0 1 2 
007 - 2 1 0 
008 - 2 1 0 
009 - 2 1 0 
010 - 2 1 0 
011 - 0 1 2 
012 - 0 1 2 
013 - 0 1 2 
014 - 2 1 0 
015 - 2 1 0 
016 - 2 1 0 
017 - 2 1 0 
018 - 0 1 2 
019 - 2 1 0 
020 - 0 0 2 
021 - 2 1 0 
022 - 0 1 2 
023 - 2 1 0
024 - 0 1 2 
025 - 0 1 2 
026 - 2 1 0 
027 - 0 1 2 
028 - 0 1 2 
029 - 2 1 0 
030 - 2 1 0 
031 - 2 1 0 
032 - 0 1 2 
033 - 2 1 0 
034 - 0 1 2 
035 - 0 1 2 
036 - 0 1 2 
037 - 0 1 0 
038 - 0 1 2 
039 - 2 1 0
040 - 0 1 2 
041 - 2 1 0 
042 - 0 1 2 
043 - 0 1 2 
044 - 0 1 2 
045 - 2 1 0 
046 - 2 1 0 
047 - 0 1 2 
048 - 0 1 2 
049 - 2 1 0 
050 - 2 1 0 
051 - 0 1 2 
052 - 2 1 0 
053 - 2 1 0 
054 - 0 0 2 
055 - 2 1 0 
056 - 2 1 0 
057 - 2 1 0 
058 - 0 1 2 
059 - 2 1 0 
060 - 2 1 0 
061 - 0 1 2 
062 - 2 1 0 
063 - 2 1 0 
064 - 2 1 0 
065 - 0 1 2 
066 - 2 1 0
067 - 0 1 2 
068 - 2 1 0 
069 - 0 1 2 
070 - 2 1 0 
071 - 2 0 0 
072 - 0 1 2 
073 - 0 1 2 
074 - 2 1 0 
075 - 2 1 0 
076 - 2 1 0 
077 - 0 1 2 
078 - 2 1 0 
079 - 2 1 0 
080 - 0 1 2 
081 - 0 1 2 
082 - 0 1 2 
083 - 0 1 2 
084 - 0 1 2 
085 - 0 1 2 
086 - 0 1 2 
087 - 0 1 2 
088 - 0 0 2 
089 - 0 1 2 
090 - 2 1 0 
091 - 0 1 2 
092 - 0 1 2 
093 - 0 1 2 
094 - 0 1 2 
095 - 2 1 0 
096 - 0 1 2 
097 - 0 1 2 
098 - 2 1 0 
099 - 2 1 0 
100 - 0 1 2 
101 - 0 1 2 
102 - 2 1 0 
103 - 0 1 2 
104 - 2 0 0 
105 - 0 1 0";
            var arrays = template.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split(new[] {"-"}, StringSplitOptions.RemoveEmptyEntries))
                .Select(x => x[1].Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToList())
                .ToList();

            #endregion

            var getResult = new Func<List<List<int>>, int, int, int>((key, number, answer) => key[number - 1][answer - 1]);
            var sumResult = new Func<List<List<int>>, List<int>, List<int>, int>((key, numbers, answers) =>
            {
                return numbers.Select(x => getResult(key, x, answers[x-1])).Sum();
            });

            var md = new List<int> {1, 18, 35, 52, 69, 86, 103};
            var a = new List<int> {2, 19, 36, 53, 70, 87};
            var b = new List<int> {3, 20, 37, 54, 71, 88, 105, 104};
            var c = new List<int> {4, 21, 38, 55, 72, 89};
            var e = new List<int> {5, 22, 39, 56, 73, 90};
            var f = new List<int> {6, 23, 40, 57, 74, 91};
            var g = new List<int> {7, 24, 41, 58, 75, 92};
            var h = new List<int> {8, 25, 42, 59, 76, 93};
            var i = new List<int> {9, 26, 43, 60, 77, 94};
            var l = new List<int> {10, 27, 44, 61, 78, 95};
            var m = new List<int> {11, 28, 45, 62, 79, 96};
            var n = new List<int> {12, 29, 46, 63, 80, 97};
            var o = new List<int> {13, 30, 47, 64, 81, 98};
            var q1 = new List<int> {14, 31, 48, 65, 82, 99};
            var q2 = new List<int> {15, 32, 49, 66, 83, 100};
            var q3 = new List<int> {16, 33, 50, 67, 84, 101};
            var q4 = new List<int> {17, 34, 51, 68, 85, 102};

            Md = sumResult(arrays, md, Answers);
            A = sumResult(arrays, a, Answers);
            B = sumResult(arrays, b, Answers);
            C = sumResult(arrays, c, Answers);
            E = sumResult(arrays, e, Answers);
            F = sumResult(arrays, f, Answers);
            G = sumResult(arrays, g, Answers);
            H = sumResult(arrays, h, Answers);
            I = sumResult(arrays, i, Answers);
            L = sumResult(arrays, l, Answers);
            M = sumResult(arrays, m, Answers);
            N = sumResult(arrays, n, Answers);
            O = sumResult(arrays, o, Answers);
            Q1 = sumResult(arrays, q1, Answers);
            Q2 = sumResult(arrays, q2, Answers);
            Q3 = sumResult(arrays, q3, Answers);
            Q4 = sumResult(arrays, q4, Answers);
        }


        public KettelTest()
        {
            QuestionsNumber = 105;
            Answers = new List<int>();
        }

        public override string ToString()
        {
            return Info;
        }
    }
}
