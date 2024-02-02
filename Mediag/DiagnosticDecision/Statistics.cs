using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        private double ProbabilityFactor(int factor, object value)
        {
            if (Check(Set, factor)) return -1;

            return (double)Set.Count(row => row[factor].Equals(value)) / Set.Count;
        }

        private double ProbabilityResultKnowingFactor(int result, object valueResult, int factor, object valueFactor)
        {
            if (Check(Set, factor)) return -1;

            List<object[]> setFactor = Set.FindAll(row => row[factor].Equals(valueFactor));
            if (Check(setFactor, result)) return -1;

            return (double)setFactor.Count(row => row[result].Equals(valueResult)) / setFactor.Count;
        }

        private List<object> ExtractFactorValues(List<object[]> set, int factor)
        {
            HashSet<object> factorValues = new HashSet<object>();

            foreach (object[] row in set) factorValues.Add(row[factor]);
            return factorValues.ToList();
        }

        private double Log2(double x) { return Math.Log(x) / Math.Log(2); }

        private double EntropyFactor(int factor)
        {
            if (Check(Set, factor)) return -1;

            double entropy = 0;
            foreach (object value in ExtractFactorValues(Set, factor))
            {
                double prob = ProbabilityFactor(factor, value);
                entropy -= prob * Log2(prob);
            }
            return entropy;
        }
    }
}
