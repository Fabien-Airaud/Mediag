using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Mediag.ViewModels
{
    public class DecisionTreeVM : INotifyPropertyChanged
    {
        public Models.IllnessTypes TargetIllness { get; set; }

        public ObservableCollection<Models.IllnessTypes> IllnessTypes { get; set; }

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

        public ICommand TrainCommand { get; private set; }
        private void Train()
        {
            MessageBoxResult result = MessageBox.Show("Training...", "Training", MessageBoxButton.OK);
            if (result.Equals(MessageBoxResult.OK))
            {
                EvaluateVisibility = "Visible";
            }
        }

        public ICommand EvaluateCommand { get; private set; }
        private void Evaluate()
        {
            MessageBoxResult result = MessageBox.Show("Evaluating...", "Evaluating", MessageBoxButton.OK);
            if (result.Equals(MessageBoxResult.OK))
            {
                EvaluateVisibility = "Hidden";
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public DecisionTreeVM()
        {
            IllnessTypes = new ObservableCollection<Models.IllnessTypes>(Models.IllnessTypes.GetIllnessTypes());
            TargetIllness = IllnessTypes.First();

            TrainCommand = new RelayCommand(_ => true, _ => Train());
            EvaluateCommand = new RelayCommand(_ => true, _ => Evaluate());
        }
    }
}
