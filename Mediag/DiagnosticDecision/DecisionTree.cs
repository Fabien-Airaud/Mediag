using Mediag.Medical;
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
            pivot = 0;
            return "";
        }
    }
}
