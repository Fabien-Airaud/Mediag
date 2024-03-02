using System.Collections.Generic;

namespace DiagnosticDecision
{
    public class Node
    {
        public string Label { get; set; }

        public Dictionary<string, Node> Children { get; private set; }
        public void AddChild(string value, Node child)
        {
            Children ??= [];
            Children.Add(value, child);
        }
        public void RemoveChild(string value) { Children.Remove(value); }

        public string Value { get; set; } = "";

        public double? Pivot { get; set; }


        public Node(string label)
        {
            Label = label;
        }

        public Node(string label, string value)
        {
            Label = label;
            Value = value;
        }

        public Node(string label, double pivot)
        {
            Label = label;
            Pivot = pivot;
        }


        public bool IsLeaf() { return Children == null; }

        public bool HasPivot() { return Pivot != null; }

        public bool HasValue() { return Value != ""; }

        public string Prefix(string startString)
        {
            if (IsLeaf()) return Value + "\n";

            string str = Label + "\n";

            // Find the longest key
            int maxLen = 0;
            foreach (var key in Children.Keys)
            {
                int keyLength = (HasPivot() ? key + " " + Pivot : key).Length;
                if (keyLength > maxLen) maxLen = keyLength;
            }

            // Create the string to add to the start string
            string supStartString = "  | ";
            for (int i = 0; i < maxLen; i++) supStartString += " ";
            supStartString += "     ";

            // Add children display
            foreach (var child in Children)
            {
                str += startString + "  + ";
                str += ((HasPivot() ? child.Key + " " + Pivot : child.Key) + " ").PadRight(maxLen+4, '-') + " ";

                str += child.Value.Prefix(startString + supStartString);
            }
            return str;
        }

        public override string ToString()
        {
            return Prefix("");
        }
    }
}
