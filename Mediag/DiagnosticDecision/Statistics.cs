using System;
using System.Collections.Generic;
using System.Linq;

namespace Mediag.DiagnosticDecision
{
    class Statistics
    {
        public List<object[]> Set { get; set; } = new List<object[]>();


        public Statistics() { }
        public Statistics(List<object[]> set) { Set = set; }


        private bool Check(List<object[]> set, int factor)
        {
            return set.Count == 0 || factor < 0 || factor >= set[0].Length;
        }

        public double ProbabilityFactor(int factor, object value)
        {
            if (Check(Set, factor)) return 0;

            return (double)Set.Count(row => row[factor].Equals(value)) / Set.Count;
        }
    }
}
