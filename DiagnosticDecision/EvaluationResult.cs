namespace DiagnosticDecision
{
    public record EvaluationResult(string[] PredictedResults, double Accuracy, string[,] ConfusionMatrix)
    {
        public override string ToString()
        {
            string result = $"Accuracy: {Accuracy}\n";
            result += "Confusion Matrix:\n";
            result += IDecisionTree.ConfusionMatrixString(ConfusionMatrix);
            return result;
        }
    }
}
