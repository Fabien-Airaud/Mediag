using System.Collections.Generic;

namespace Mediag.DiagnosticDecision
{
    class Metrics
    {
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
    }
}
