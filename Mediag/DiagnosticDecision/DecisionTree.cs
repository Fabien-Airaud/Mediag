using Mediag.Medical;

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
    }
}
