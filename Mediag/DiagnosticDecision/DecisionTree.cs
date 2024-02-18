using Mediag.Medical;
using System;
using System.Collections.Generic;

namespace Mediag.DiagnosticDecision
{
    class DecisionTree
    {
        public IllnessTypes Illness { get; set; }

        public Node Root { get; private set; }


        public DecisionTree(IllnessTypes illness)
        {
            Illness = illness;
        }


        public string BestLabel(List<string[]> values, List<string> labels, out double pivot)
        {
            pivot = double.NaN;
            string bestLabel = "";
            double bestGain = 0;

            for (int i = 0; i < labels.Count - 1; i++) // Last label is the result
            {
                double gain;
                double tempPivot = double.NaN;
                if (Metrics.IsDiscretizable(values, i)) gain = Metrics.GainRatioPivot(values, i, out tempPivot);
                else gain = Metrics.GainRatioDiscrete(values, i);

                if (gain > bestGain)
                {
                    bestGain = gain;
                    bestLabel = labels[i];
                    if (!double.IsNaN(tempPivot)) pivot = tempPivot;
                }
            }
            return bestLabel;
        }

        public List<string[]> RemoveLabel(List<string[]> values, int labelIndex)
        {
            List<string[]> subset = new List<string[]>(values);
            for (int i = 0; i < values.Count; i++)
            {
                string[] value = values[i];
                string[] strings = new string[value.Length - 1];
                for (int j = 0; j < value.Length; j++)
                {
                    if (j < labelIndex) strings[j] = value[j];
                    else if (j > labelIndex) strings[j - 1] = value[j];
                }
                subset.Add(strings);
            }
            return subset;
        }
    }
}
