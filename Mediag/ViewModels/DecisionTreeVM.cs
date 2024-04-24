using DiagnosticDecision;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Mediag.ViewModels
{
    public class DecisionTreeVM : INotifyPropertyChanged
    {
        private Models.IllnessTypes _targetIllness;
        public Models.IllnessTypes TargetIllness
        {
            get { return _targetIllness; }
            set
            {
                if (_targetIllness != value)
                {
                    _targetIllness = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Models.IllnessTypes> IllnessTypes { get; set; }

        public Dictionary<Models.IllnessTypes, EvaluationResult> EvaluationResults { get; set; } = [];

        private EvaluationResult? _currentResult;
        public EvaluationResult? CurrentResult
        {
            get { return _currentResult; }
            set
            {
                if (_currentResult != value)
                {
                    _currentResult = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _evaluateVisibility = "Hidden";
        public string EvaluateVisibility
        {
            get { return _evaluateVisibility; }
            set
            {
                if (_evaluateVisibility != value)
                {
                    _evaluateVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _resultVisibility = "Hidden";
        public string ResultVisibility
        {
            get { return _resultVisibility; }
            set
            {
                if (_resultVisibility != value)
                {
                    _resultVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand TrainCommand { get; private set; }
        private void Train()
        {
            // Configure open file dialog box
            OpenFileDialog openFileDialog = new()
            {
                FileName = "train", // Default file name
                DefaultExt = ".csv", // Default file extension
                Filter = "CSV Files (*.csv)|*.csv" // Filter files by extension
            };

            // Process open file dialog box
            if (openFileDialog.ShowDialog() == true)
            {
                string filename = openFileDialog.FileName;
                if (filename == null || !System.IO.File.Exists(filename))
                {
                    MessageBox.Show("File not found", "File error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Train the decision tree
                Node? resultTree = TrainDecisionTree(filename);
                if (resultTree == null)
                {
                    MessageBox.Show("Error training decision tree\nCheck your CSV file if it contains correct data for " + TargetIllness,
                        "Training", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                MessageBoxResult result = MessageBox.Show("Training successful", "Training", MessageBoxButton.OK);
                if (result == MessageBoxResult.OK) EvaluateVisibility = "Visible";
            }
        }

        public ICommand EvaluateCommand { get; private set; }
        private void Evaluate()
        {
            // Configure open file dialog box
            OpenFileDialog openFileDialog = new()
            {
                FileName = "test", // Default file name
                DefaultExt = ".csv", // Default file extension
                Filter = "CSV Files (*.csv)|*.csv" // Filter files by extension
            };

            // Process open file dialog box
            if (openFileDialog.ShowDialog() == true)
            {
                string filename = openFileDialog.FileName;
                if (filename == null || !System.IO.File.Exists(filename))
                {
                    MessageBox.Show("File not found", "File error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Evaluate the decision tree
                CurrentResult = EvaluateDecisionTree(filename);
                if (CurrentResult == null)
                {
                    ResultVisibility = "Hidden";
                    MessageBox.Show("Error evaluating decision tree\nCheck your CSV file if it contains correct data for " + TargetIllness,
                        "Evaluation", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                ResultVisibility = "Visible";
                MessageBox.Show("Evaluation successful !", "Evaluation", MessageBoxButton.OK);
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (propertyName == nameof(TargetIllness))
            {
                if (Models.Hospital.DecisionTrees.ContainsKey(TargetIllness))
                {
                    EvaluateVisibility = "Visible";

                    if (EvaluationResults.TryGetValue(TargetIllness, out EvaluationResult? result))
                    {
                        CurrentResult = result;
                        ResultVisibility = "Visible";
                    }
                    else ResultVisibility = "Hidden";
                }
                else
                {
                    EvaluateVisibility = "Hidden";
                    ResultVisibility = "Hidden";
                }
            }
        }


        public DecisionTreeVM()
        {
            IllnessTypes = new ObservableCollection<Models.IllnessTypes>(Models.IllnessTypes.GetIllnessTypes());
            _targetIllness = IllnessTypes.First();
            OnPropertyChanged(nameof(TargetIllness));

            TrainCommand = new RelayCommand(_ => true, _ => Train());
            EvaluateCommand = new RelayCommand(_ => true, _ => Evaluate());
        }


        private Node? TrainDecisionTree(string filename)
        {
            // Get the decision tree
            IDecisionTree tree;
            if (Models.Hospital.DecisionTrees.TryGetValue(TargetIllness, out IDecisionTree? value))
            {
                tree = value;
            }
            else
            {
                tree = new DecisionTree(TargetIllness.Name);
                Models.Hospital.DecisionTrees.Add(TargetIllness, tree);
            }

            // Train the decision tree
            List<string> labels;
            List<string[]> values;
            switch (TargetIllness.Name)
            {
                case "Breast cancer":
                    List<Models.BreastCancerData>? bcRows = Models.BreastCancerData.GetCSVData(filename);
                    if (bcRows == null) return null;
                    
                    labels = new List<string>(bcRows[0].Labels());
                    values = [];
                    foreach (Models.BreastCancerData row in bcRows) values.Add(row.Values());

                    break;
                case "Heart disease":
                    List<Models.HeartDiseaseData>? hdRows = Models.HeartDiseaseData.GetCSVData(filename);
                    if (hdRows == null) return null;

                    labels = new(hdRows[0].Labels());
                    values = [];
                    foreach (Models.HeartDiseaseData row in hdRows) values.Add(row.Values());

                    break;
                default:
                    return null;
            }
            return tree.BuildTree(values, labels);
        }

        private EvaluationResult? EvaluateDecisionTree(string filename)
        {
            // Get the decision tree
            IDecisionTree tree;
            if (Models.Hospital.DecisionTrees.TryGetValue(TargetIllness, out IDecisionTree? value))
            {
                tree = value;
            }
            else
            {
                return null;
            }

            // Evaluate the decision tree
            List<string[]> values;
            switch (TargetIllness.Name)
            {
                case "Breast cancer":
                    List<Models.BreastCancerData>? bcRows = Models.BreastCancerData.GetCSVData(filename);
                    if (bcRows == null) return null;

                    values = [];
                    foreach (Models.BreastCancerData row in bcRows) values.Add(row.Values());

                    break;
                case "Heart disease":
                    List<Models.HeartDiseaseData>? hdRows = Models.HeartDiseaseData.GetCSVData(filename);
                    if (hdRows == null) return null;

                    values = [];
                    foreach (Models.HeartDiseaseData row in hdRows) values.Add(row.Values());

                    break;
                default:
                    return null;
            }

            EvaluationResult result = tree.Evaluate(values);
            EvaluationResults[TargetIllness] = result;
            return result;
        }
    }
}
