using Mediag.DiagnosticDecision;
using System;

namespace Mediag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<Diagnosis> data = CsvManager.GetSamplesDiagnosis();
            //Console.WriteLine(data == null ? "File doesn't exist" : data.ToString());

            //foreach (object value in data[0].Values())
            //{
            //    Console.WriteLine(value.GetType().Name + " = " + value.ToString());
            //}

            DecisionTree decisionTree = new DecisionTree();
            Console.WriteLine(decisionTree.ToString());
        }
    }
}
