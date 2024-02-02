using System.Collections.Generic;
using System.Linq;

namespace Mediag.DiagnosticDecision
{
    class Statistics
    {
        public List<object[]> Set { get; set; } = new List<object[]>();


        public Statistics() { }
        public Statistics(List<object[]> set) { Set = set; }


        private double Probability(int factor, object value)
        {
            if (Set.Count == 0 || factor < 0 || factor >= Set[0].Length) return 0;

            return (double)Set.Count(row => row[factor].Equals(value)) / Set.Count;
        }
    }
}
