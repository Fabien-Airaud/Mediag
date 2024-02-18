using Mediag.Medical;
using System.Collections.Generic;

namespace Mediag.DiagnosticDecision
{
    interface IDecisionTree
    {
        Node Root { get; }
        List<string> Labels { get; }

        Node BuildTree(List<string[]> values, List<string> labels);
        string Classify(string[] instance);
    }
}
