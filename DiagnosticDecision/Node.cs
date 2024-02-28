﻿using System.Collections.Generic;

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
            string str = startString;

            if (IsLeaf()) return str + Value;
            return str + Label;
        }

        public override string ToString()
        {
            return Prefix("");
            //if (IsLeaf()) return Value;
            
            //string str = Label;
            //foreach (var child in Children)
            //{
            //    str += " " + child.Value.ToString();
            //}
            //return str;
        }
    }
}
