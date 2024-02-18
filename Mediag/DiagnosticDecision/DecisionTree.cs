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
    }
}
