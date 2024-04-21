using System.Collections.Generic;

namespace DiagnosticDecision
{
    public interface IDecisionTree
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
        static string ConfusionMatrixString(string[,] confusionMatrix)
        {
            int[] maxLength = new int[confusionMatrix.GetLength(0)];
            for (int i = 0; i < confusionMatrix.GetLength(0); i++)
            {
                int length = confusionMatrix[0, i].Length;
                if (length > maxLength[i]) maxLength[i] = length;
            }

            string str = "";
            for (int i = 0; i < confusionMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < confusionMatrix.GetLength(1); j++)
                {
                    str += confusionMatrix[i, j].PadLeft(maxLength[j] + 1);
                }
                str += "\n";
            }
            return str;
        }
        string ConfusionMatrixString(List<string[]> instances, string[] predictedResults);

        string Evaluate(List<string[]> instances, out string[] predictedResults, out double accuracy, out string[,] confusionMatrix);
        EvaluationResult Evaluate(List<string[]> instances);
    }
}
