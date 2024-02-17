using System;
using System.Collections.Generic;
using System.Linq;

namespace Mediag.DiagnosticDecision
{
    class Metrics
    {
        public static bool IsDiscretizable(List<string[]> values, int labelIndex)
        {
            foreach (string[] value in values)
            {
                try { double.Parse(value[labelIndex]); }
                catch { return false; }
            }
            return true;
        }

        public static List<double> PossibleSplitValues(List<string[]> values, int labelIndex)
        {
            List<double> splitValues = new List<double>();

            SortedList<double, bool> valueLabelPairs = new SortedList<double, bool>();
            foreach (string[] value in values)
            {
                valueLabelPairs.Add(double.Parse(value[labelIndex]), bool.Parse(value[value.Length - 1]));
            }

            // Split value if the result changes (mean value)
            for (int i = 0; i < valueLabelPairs.Count - 1; i++)
            {
                if (valueLabelPairs.Values[i] != valueLabelPairs.Values[i + 1])
                {
                    splitValues.Add((valueLabelPairs.Keys[i] + valueLabelPairs.Keys[i + 1]) / 2);
                }
            }

            return splitValues;
        }

        public static List<string> DifferentValues(List<string[]> values, int labelIndex)
        {
            List<string> differentValues = new List<string>();

            foreach (string[] value in values)
            {
                if (!differentValues.Contains(value[labelIndex]))
                {
                    differentValues.Add(value[labelIndex]);
                }
            }

            return differentValues;
        }

        public static string MostCommonResult(List<string[]> values)
        {
            int resultIndex = values[0].Length - 1;
            return values.GroupBy(row => row[resultIndex]).OrderByDescending(group => group.Count()).First().Key.ToString();
        }

        public static List<string[]> SubsetDiscrete(List<string[]> values, int labelIndex, string value)
        {
            return values.FindAll(row => row[labelIndex].Equals(value));
        }

        public static List<string[]> SubsetPivot(List<string[]> values, int labelIndex, double pivot, bool higher = true)
        {
            return values.FindAll(row => (double.Parse(row[labelIndex]) > pivot) == higher);
        }

        private static double Log2(double x) { return Math.Log(x) / Math.Log(2); }

        public static double Entropy(List<string[]> values)
        {
            double entropy = 0;
            int resultIndex = values[0].Length - 1;
            List<string> differentValues = DifferentValues(values, resultIndex);

            foreach (string value in differentValues)
            {
                double prob = (double)SubsetDiscrete(values, resultIndex, value).Count / values.Count;
                entropy -= prob * Log2(prob);
            }

            return entropy;
        }

        public static double GainDiscrete(List<string[]> values, int labelIndex)
        {
            double gain = Entropy(values);
            List<string> differentValues = DifferentValues(values, labelIndex);

            foreach (string value in differentValues)
            {
                List<string[]> subset = SubsetDiscrete(values, labelIndex, value);
                gain -= (double)subset.Count / values.Count * Entropy(subset);
            }

            return gain;
        }

        public static double GainPivot(List<string[]> values, int labelIndex, out double pivot)
        {
            List<double> splitValues = PossibleSplitValues(values, labelIndex);

            Dictionary<double, double> gainsPivots = new Dictionary<double, double>(splitValues.Count);
            foreach (double splitValue in splitValues)
            {
                double gain = Entropy(values);

                List<string[]> subsetHigher = SubsetPivot(values, labelIndex, splitValue, true);
                gain -= (double)subsetHigher.Count / values.Count * Entropy(subsetHigher);

                List<string[]> subsetLower = SubsetPivot(values, labelIndex, splitValue, false);
                gain -= (double)subsetLower.Count / values.Count * Entropy(subsetLower);

                gainsPivots.Add(splitValue, gain);
            }
            pivot = gainsPivots.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

            return gainsPivots[pivot];
        }
    }
}
