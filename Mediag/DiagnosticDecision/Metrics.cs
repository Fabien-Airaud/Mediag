using System;
using System.Collections.Generic;

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

        public static List<string[]> SubsetDiscrete(List<string[]> values, int labelIndex, string value)
        {
            return values.FindAll(row => row[labelIndex].Equals(value));
        }

        public static List<string[]> SubsetPivot(List<string[]> values, int labelIndex, double pivot, bool higher = true)
        {
            return values.FindAll(row => (double.Parse(row[labelIndex]) > pivot) == higher);
        }

        public static int SizeSubsetDiscrete(List<string[]> values, int labelIndex, string value)
        {
            return SubsetDiscrete(values, labelIndex, value).Count;
        }

        public static int SizeSubsetPivot(List<string[]> values, int labelIndex, double pivot, bool higher = true)
        {
            return SubsetPivot(values, labelIndex, pivot, higher).Count;
        }

        private static double Log2(double x) { return Math.Log(x) / Math.Log(2); }

        public static double Entropy(List<string[]> values)
        {
            double entropy = 0;
            int resultIndex = values[0].Length - 1;
            List<string> differentValues = DifferentValues(values, resultIndex);

            foreach (string value in differentValues)
            {
                double prob = (double)SizeSubsetDiscrete(values, resultIndex, value) / values.Count;
                entropy -= prob * Log2(prob);
            }

            return entropy;
        }
    }
}
