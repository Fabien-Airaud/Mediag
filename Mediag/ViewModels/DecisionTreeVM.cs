using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mediag.ViewModels
{
    public class DecisionTreeVM
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


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public DecisionTreeVM()
        {
            IllnessTypes = new ObservableCollection<Models.IllnessTypes>(Models.IllnessTypes.GetIllnessTypes());
            TargetIllness = IllnessTypes.First();
        }
    }
}
