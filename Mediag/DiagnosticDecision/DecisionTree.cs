using Mediag.DatabaseCSV;
using Mediag.Medical;
using System.Collections.Generic;

namespace Mediag.DiagnosticDecision
{
    class DecisionTree
    {
        public List<IMedicalData> Train { get; set; }
        public List<IMedicalData> Test { get; set; }
        public DataManager<BreastCancerData, BreastCancerMap> DataManager { get; private set; } = new DataManager<BreastCancerData, BreastCancerMap>("BreastCancer");


        public DecisionTree()
        {
            ResetTrainToDefault();
            ResetTestToDefault();
        }
        public DecisionTree(List<IMedicalData> train, List<IMedicalData> test)
        {
            Train = train;
            Test = test;
        }


        public void ResetTrainToDefault() { Train = new List<IMedicalData>(DataManager.GetTrainData()); }

        public void ResetTestToDefault() { Test = new List<IMedicalData>(DataManager.GetTestData()); }


        public override string ToString()
        {
            return Train.Count + " elements for training and " + Test.Count + " elements for testing";
        }
    }
}
