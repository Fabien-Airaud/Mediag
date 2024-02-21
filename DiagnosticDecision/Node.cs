using System.Collections.Generic;

namespace DiagnosticDecision
{
    class Node
    {
        public string Label { get; set; }

        public Dictionary<string, Node> Children { get; private set; }
        public void AddChild(string value, Node child)
        {
            if (Children == null) Children = new Dictionary<string, Node>();
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

        public override string ToString()
        {
            if (IsLeaf()) return Value;
            
            string str = Label;
            foreach (var child in Children)
            {
                str += " " + child.Value.ToString();
            }
            return str;
        }
    }
}
