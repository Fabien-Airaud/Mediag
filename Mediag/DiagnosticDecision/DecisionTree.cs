using Mediag.Database;
using System.Collections.Generic;

namespace Mediag.DiagnosticDecision
{
    class DecisionTree
    {
        public List<IForDecisionTree> Train { get; set; }
        public List<IForDecisionTree> Test { get; set; }
        

        public DecisionTree()
        {
            ResetTrainToDefault();
            ResetTestToDefault();
        }
        public DecisionTree(List<IForDecisionTree> train, List<IForDecisionTree> test)
        {
            Train = train;
            Test = test;
        }


        public void ResetTrainToDefault() { Train = new List<IForDecisionTree>(CsvManager.GetTrainDiagnosis()); }

        public void ResetTestToDefault() { Test = new List<IForDecisionTree>(CsvManager.GetTestDiagnosis()); }


        public override string ToString()
        {
            return Train.Count + " elements for training and " + Test.Count + " elements for testing";
        }
    }
}
