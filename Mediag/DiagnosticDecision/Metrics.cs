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
            List<string[]> subset = new List<string[]>();

            foreach (string[] row in values)
            {
                if (row[labelIndex].Equals(value))
                {
                    subset.Add(row);
                }
            }

            return subset;
        }

        public static List<string[]> SubsetPivot(List<string[]> values, int labelIndex, double pivot, bool higher = true)
        {
            List<string[]> subset = new List<string[]>();

            foreach (string[] row in values)
            {
                if ((double.Parse(row[labelIndex]) > pivot) == higher) // if higher is true, then we want the values higher than the pivot
                {
                    subset.Add(row);
                }
            }

            return subset;
        }
    }
}
