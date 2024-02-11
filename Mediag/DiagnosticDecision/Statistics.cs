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

        private double ProbabilityFactor(List<object[]> set, int factor, object value)
        {
            if (Check(set, factor)) return -1;

            return (double)set.Count(row => row[factor].Equals(value)) / set.Count;
        }

        private double ProbabilityResultKnowingFactor(int result, object valueResult, int factor, object valueFactor)
        {
            if (Check(Set, factor)) return -1;

            List<object[]> setFactor = Set.FindAll(row => row[factor].Equals(valueFactor));
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
                entropy -= prob * Log2(prob);
            }
            return entropy;
        }

        private double EntropyResultKnowingFactor(int result, int factor, object valueFactor)
        {
            if (Check(Set, factor)) return -1;

            List<object[]> setFactor = Set.FindAll(row => row[factor].Equals(valueFactor));

            return EntropyFactor(setFactor, result);
        }

        private double Gain(int result, int factor)
        {
            if (Check(Set, result)) return -1;
            if (Check(Set, factor)) return -1;

            double gain = EntropyFactor(Set, result);
            foreach (object value in ExtractFactorValues(Set, factor))
            {
                gain -= ProbabilityFactor(Set, factor, value) * EntropyResultKnowingFactor(result, factor, value);
            }
            return gain;
        }

        public double SplitInfo(int factor)
        {
            if (Check(Set, factor)) return -1;

            double splitInfo = 0;
            foreach (object value in ExtractFactorValues(Set, factor))
            {
                double prob = ProbabilityFactor(Set, factor, value);
                splitInfo -= prob * Log2(prob);
            }
            return splitInfo;
        }

        public double GainRatio(int result, int factor)
        {
            double gain = Gain(result, factor);
            double splitInfo = SplitInfo(factor);

            if (gain == -1 || splitInfo == -1) return -1;
            return splitInfo == 0 ? 0 : gain / splitInfo;
        }
    }
}
