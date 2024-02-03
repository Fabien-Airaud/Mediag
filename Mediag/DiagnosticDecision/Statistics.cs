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

        private double ProbabilityFactor(List<object[]> set, int factor, object value)
        {
            if (Check(set, factor)) return -1;

            return (double)set.Count(row => row[factor].Equals(value)) / set.Count;
        }

        private double ProbabilityResultKnowingFactor(int result, object valueResult, int factor, object valueFactor)
        {
            if (Check(Set, factor)) return -1;

            List<object[]> setFactor = Set.FindAll(row => row[factor].Equals(valueFactor));
            //if (Check(setFactor, result)) return -1;

            //return (double)setFactor.Count(row => row[result].Equals(valueResult)) / setFactor.Count;
            return ProbabilityFactor(setFactor, result, valueResult);
        }

        private List<object> ExtractFactorValues(List<object[]> set, int factor)
        {
            HashSet<object> factorValues = new HashSet<object>();

            foreach (object[] row in set) factorValues.Add(row[factor]);
            return factorValues.ToList();
        }

        private double Log2(double x) { return Math.Log(x) / Math.Log(2); }

        private double EntropyFactor(List<object[]> set, int factor)
        {
            if (Check(set, factor)) return -1;

            double entropy = 0;
            foreach (object value in ExtractFactorValues(set, factor))
            {
                double prob = ProbabilityFactor(set, factor, value);
                Console.WriteLine(prob);
                entropy -= prob * Log2(prob);
            }
            return entropy;
        }

        private double EntropyResultKnowingFactor(int result, int factor, object valueFactor)
        {
            if (Check(Set, factor)) return -1;

            List<object[]> setFactor = Set.FindAll(row => row[factor].Equals(valueFactor));
            Console.WriteLine(setFactor.Count);

            return EntropyFactor(setFactor, result);
        }
    }
}
