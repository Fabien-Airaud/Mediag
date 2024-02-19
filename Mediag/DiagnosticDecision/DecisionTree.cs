using Mediag.Medical;
using System;
using System.Collections.Generic;

namespace Mediag.DiagnosticDecision
{
    class DecisionTree : IDecisionTree
    {
        public IllnessTypes Illness { get; set; }

        public Node Root { get; private set; }

        public List<string> Labels { get; private set; }


        public DecisionTree(IllnessTypes illness)
        {
            Illness = illness;
        }


        private string BestLabel(List<string[]> values, List<string> labels, out double pivot)
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

        private List<string[]> RemoveLabel(List<string[]> values, int labelIndex)
        {
            List<string[]> subset = new List<string[]>(values.Count);
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

        private Node BuildDiscreteNode(List<string[]> values, List<string> labels, string bestLabel)
        {
            Node node = new Node(bestLabel);
            int indexBestLabel = labels.IndexOf(bestLabel);
            Console.WriteLine("Best label (" + indexBestLabel + "): " + bestLabel);

            List<string> differentValues = Metrics.DifferentValues(values, indexBestLabel);
            foreach (string value in differentValues)
            {
                // Create a subset of values and labels without the best label
                List<string[]> subValues = Metrics.SubsetDiscrete(values, indexBestLabel, value);
                List<string> subLabels = new List<string>(labels);

                // Remove the best label from the subsets
                subLabels.RemoveAt(indexBestLabel);
                subValues = RemoveLabel(subValues, indexBestLabel);

                // Create a child node and add it to the parent node
                Node child = BuildTreeRec(subValues, subLabels);
                node.AddChild(value, child);
            }
            return node;
        }

        private Node BuildPivotNode(List<string[]> values, List<string> labels, string bestLabel, double pivot)
        {
            Node node = new Node(bestLabel, pivot);
            int indexBestLabel = labels.IndexOf(bestLabel);
            Console.WriteLine("Best label (" + indexBestLabel + "): " + bestLabel + ", Pivot: " + pivot);

            // Create a subset of labels without the best label
            List<string> subLabels = new List<string>(labels);
            subLabels.RemoveAt(indexBestLabel);

            // Create a subset of values without the best label for higher values
            List<string[]> subValues = Metrics.SubsetPivot(values, indexBestLabel, pivot);
            subValues = RemoveLabel(subValues, indexBestLabel);

            // Create a child node for higher values and add it to the parent node
            Node childHigher = BuildTreeRec(subValues, subLabels);
            node.AddChild(">", childHigher);

            // Create a subset of values without the best label for lower values
            subValues = Metrics.SubsetPivot(values, indexBestLabel, pivot, false);
            subValues = RemoveLabel(subValues, indexBestLabel);

            // Create a child node for lower values and add it to the parent node
            Node childLower = BuildTreeRec(subValues, subLabels);
            node.AddChild("<=", childLower);

            return node;
        }

        private Node BuildTreeRec(List<string[]> values, List<string> labels)
        {
            if (values.Count == 0 || labels.Count == 0 || values[0].Length != labels.Count) return null;

            if (Metrics.Entropy(values) == 0 || labels.Count == 1) // All values have the same result or no more labels (only result label)
            {
                Console.WriteLine("Leaf: " + labels[labels.Count - 1] + " = " + Metrics.MostCommonResult(values));
                return new Node(labels[labels.Count - 1], Metrics.MostCommonResult(values));
            }

            string bestLabel = BestLabel(values, labels, out double pivot);
            if (pivot == double.NaN) return BuildDiscreteNode(values, labels, bestLabel); // Discrete label
            else return BuildPivotNode(values, labels, bestLabel, pivot); // Pivot label
        }

        public Node BuildTree(List<string[]> values, List<string> labels)
        {
            Root = BuildTreeRec(values, labels);
            if (Root != null) Labels = new List<string>(labels);
            else Labels = null;
            return Root;
        }

        private string Classify(string[] instance, Node node)
        {
            if (node.IsLeaf()) return node.Value;

            int indexLabel = Labels.IndexOf(node.Label);
            if (node.HasPivot())
            {
                double pivot = node.Pivot.Value;
                double value = double.Parse(instance[indexLabel]);

                if (value > pivot) return Classify(instance, node.Children[">"]);
                else return Classify(instance, node.Children["<="]);
            }
            else return Classify(instance, node.Children[instance[indexLabel]]);
        }

        public string Classify(string[] instance)
        {
            if (Root == null || Labels == null || instance.Length != Labels.Count) return null;

            return Classify(instance, Root);
        }

        public string[] ClassifyAll(List<string[]> instances)
        {
            if (instances.Count == 0) return null;

            string[] results = new string[instances.Count];
            for (int i = 0; i < instances.Count; i++) results[i] = Classify(instances[i]);
            return results;
        }

        public double Accuracy(List<string[]> instances)
        {
            if (instances.Count == 0) return double.NaN;

            int correct = 0;
            foreach (string[] instance in instances)
            {
                string result = Classify(instance);
                if (result == instance[Labels.Count - 1]) correct++;
            }
            return (double)correct / instances.Count;
        }

        public double Accuracy(List<string[]> instances, string[] predictedResults)
        {
            if (instances.Count == 0 || predictedResults.Length != instances.Count) return double.NaN;

            int correct = 0;
            for (int i = 0; i < instances.Count; i++) if (instances[i][Labels.Count - 1] == predictedResults[i]) correct++;
            return (double)correct / instances.Count;
        }

        public override string ToString()
        {
            string str = "Decision Tree for " + Illness;
            if (Labels != null)
            {
                str += "\nLabels: ";
                foreach (string label in Labels) str += label + " ";
            }
            if (Root != null)
            {
                str += "\nRoot: ";
                str += Root.ToString();
            }
            return str;
        }
    }
}
