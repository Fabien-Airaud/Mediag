using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Mediag.ViewModels
{
    public class DiagnosticVM : INotifyPropertyChanged
    {
        private Models.IllnessTypes _illnessType;
        public Models.IllnessTypes IllnessType
        {
            get { return _illnessType; }
            set
            {
                if (_illnessType != value)
                {
                    _illnessType = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _diagnosisChoice;
        public string DiagnosisChoice
        {
            get { return _diagnosisChoice; }
            set
            {
                if (_diagnosisChoice != value)
                {
                    _diagnosisChoice = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Models.IllnessTypes> IllnessTypes { get; set; }

        public ObservableCollection<string> DiagnosisChoices { get; set; }

        public ObservableCollection<Models.MedicalFile> MedicalFiles { get; set; }

        public ICommand DiagnosticCommand { get; private set; }
        private void Diagnostic(object? medicalFile)
        {
            MessageBox.Show("Diagnostic " + (medicalFile is null ? "none" : (Models.MedicalFile)medicalFile));
        }

        public ICommand DiagnosticAllCommand { get; private set; }
        private void DiagnosticAll()
        {
            MessageBox.Show("Diagnostic all");
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public DiagnosticVM()
        {
            IllnessTypes = new ObservableCollection<Models.IllnessTypes>(Models.Hospital.DecisionTrees.Keys);
            IllnessTypes.Insert(0, new Models.IllnessTypes { Name = "All" });
            DiagnosisChoices = new ObservableCollection<string>([ "Don't have diagnosis", "Already have diagnosis" ]);
            DiagnosisChoices.Insert(0, "All");
            MedicalFiles = new ObservableCollection<Models.MedicalFile>(Models.MedicalFile.GetMedicalFiles());

            _illnessType = IllnessTypes[0];
            _diagnosisChoice = DiagnosisChoices[0];

            DiagnosticCommand = new RelayCommand(_ => true, medicalFile => Diagnostic(medicalFile));
            DiagnosticAllCommand = new RelayCommand(_ => true, _ => DiagnosticAll());
        }
    }
}
