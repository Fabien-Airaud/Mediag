using System;
using System.Collections.Generic;
using System.Linq;

namespace DiagnosticDecision
{
    static class Metrics
    {
        public static string MostCommonResult(List<string[]> values)
        {
            int resultIndex = values[0].Length - 1;
            return values.GroupBy(row => row[resultIndex]).OrderByDescending(group => group.Count()).First().Key.ToString();
        }

        public static bool IsDiscretizable(List<string[]> values, int labelIndex)
        {
            foreach (string[] value in values)
            {
                try { double.Parse(value[labelIndex]); }
                catch { return false; }
            }
            return true;
        }

        private static List<double> PossiblePivotValues(List<string[]> values, int labelIndex)
        {
            List<double> pivotValues = new List<double>();

            SortedList<double, string> valueLabelPairs = new SortedList<double, string>();
            foreach (string[] value in values)
            {
                double key = double.Parse(value[labelIndex]);
                if (valueLabelPairs.ContainsKey(key)) valueLabelPairs[key] += value[value.Length - 1];
                else valueLabelPairs.Add(key, value[value.Length - 1]);
            }

            // Split value if the result changes (mean value)
            for (int i = 0; i < valueLabelPairs.Count - 1; i++)
            {
                if (!valueLabelPairs.Values[i].Equals(valueLabelPairs.Values[i + 1]))
                {
                    pivotValues.Add((valueLabelPairs.Keys[i] + valueLabelPairs.Keys[i + 1]) / 2);
                }
            }

            return pivotValues;
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

        private static double GainDiscrete(List<string[]> values, int labelIndex)
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

        private static double GainPivot(List<string[]> values, int labelIndex, double pivot)
        {
            double gain = Entropy(values);

            List<string[]> subsetHigher = SubsetPivot(values, labelIndex, pivot, true);
            gain -= (double)subsetHigher.Count / values.Count * Entropy(subsetHigher);

            List<string[]> subsetLower = SubsetPivot(values, labelIndex, pivot, false);
            gain -= (double)subsetLower.Count / values.Count * Entropy(subsetLower);

            return gain;
        }

        private static double SplitInfoDiscrete(List<string[]> values, int labelIndex)
        {
            double splitInfo = 0;
            List<string> differentValues = DifferentValues(values, labelIndex);

            foreach (string value in differentValues)
            {
                double ratio = (double)SubsetDiscrete(values, labelIndex, value).Count / values.Count;
                splitInfo -= ratio * Log2(ratio);
            }

            return splitInfo;
        }

        private static double SplitInfoPivot(List<string[]> values, int labelIndex, double pivot)
        {
            double splitInfo = 0;

            double ratio = (double)SubsetPivot(values, labelIndex, pivot, true).Count / values.Count;
            splitInfo -= ratio * Log2(ratio);

            ratio = (double)SubsetPivot(values, labelIndex, pivot, false).Count / values.Count;
            splitInfo -= ratio * Log2(ratio);

            return splitInfo;
        }

        public static double GainRatioDiscrete(List<string[]> values, int labelIndex)
        {
            double gain = GainDiscrete(values, labelIndex);
            double splitInfo = SplitInfoDiscrete(values, labelIndex);

            return splitInfo != 0 ? gain / splitInfo : 1;
        }

        public static double GainRatioPivot(List<string[]> values, int labelIndex, out double pivot)
        {
            List<double> pivotValues = PossiblePivotValues(values, labelIndex);
            double maxGainRatio = 0;
            pivot = pivotValues[0];

            foreach (double pivotValue in pivotValues)
            {
                double gain = GainPivot(values, labelIndex, pivotValue);
                double splitInfo = SplitInfoPivot(values, labelIndex, pivotValue);
                double gainRatio = splitInfo != 0 ? gain / splitInfo : 1;

                if (gainRatio > maxGainRatio)
                {
                    maxGainRatio = gainRatio;
                    pivot = pivotValue;
                }
            }

            return maxGainRatio;
        }
    }
}
