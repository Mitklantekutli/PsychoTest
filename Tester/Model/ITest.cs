using System.Collections.Generic;

namespace Tester
{
    public interface ITest
    {
        List<int> Answers { get; }
        int QuestionsNumber { get; set; }
        string Name { get; }
        string Info { get; }
        string Story { get; }
        void Calculate();
    }
}