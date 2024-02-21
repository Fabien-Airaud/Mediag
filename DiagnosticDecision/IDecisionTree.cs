using System.Collections.Generic;

namespace DiagnosticDecision
{
    interface IDecisionTree
    {
        string Name { get; set; }
        Node Root { get; }
        List<string> Labels { get; }

        Node BuildTree(List<string[]> values, List<string> labels);

        string Classify(string[] instance);
        string[] ClassifyAll(List<string[]> instances);

        double Accuracy(List<string[]> instances);
        double Accuracy(List<string[]> instances, string[] predictedResults);

        string[,] ConfusionMatrix(List<string[]> instances, string[] predictedResults);
        string ConfusionMatrixString(string[,] confusionMatrix);
        string ConfusionMatrixString(List<string[]> instances, string[] predictedResults);

        string Evaluate(List<string[]> instances, out string[] predictedResults, out double accuracy, out string[,] confusionMatrix);
    }
}
