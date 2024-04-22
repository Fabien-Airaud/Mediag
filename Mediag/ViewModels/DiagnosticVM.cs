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
            if (medicalFile == null) return;

            Models.MedicalFile toDiagnose = (Models.MedicalFile)medicalFile;
            if (Models.Hospital.Diagnose(toDiagnose)) MessageBox.Show("Diagnosis result: " + toDiagnose.Diagnosis!.ResultString);
            else MessageBox.Show("Diagnosis for " + toDiagnose.Patient + " failed");
        }

        public ICommand DiagnosticAllCommand { get; private set; }
        private void DiagnosticAll()
        {
            long nbFails = 0;
            foreach (Models.MedicalFile medicalFile in MedicalFiles)
            {
                if (!Models.Hospital.Diagnose(medicalFile)) nbFails++;
            }
            if (nbFails > 0) MessageBox.Show("Diagnosis succeeded for " + (nbFails * 100 / MedicalFiles.Count) + "% of medical files");
            else MessageBox.Show("Diagnosis succeeded for all medical files");
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            ApplyFilters(); // Apply filters when IllnessType or DiagnosisChoice changes
        }


        public DiagnosticVM()
        {
            IllnessTypes = new ObservableCollection<Models.IllnessTypes>(Models.Hospital.DecisionTrees.Keys);
            IllnessTypes.Insert(0, new Models.IllnessTypes { Name = "All" });
            DiagnosisChoices = new ObservableCollection<string>([ "Don't have diagnosis", "Already have diagnosis" ]);
            DiagnosisChoices.Insert(0, "All");
            MedicalFiles = [];

            _illnessType = IllnessTypes[0];
            _diagnosisChoice = DiagnosisChoices[0];
            ApplyFilters();

            DiagnosticCommand = new RelayCommand(_ => true, medicalFile => Diagnostic(medicalFile));
            DiagnosticAllCommand = new RelayCommand(_ => MedicalFiles.Count > 0, _ => DiagnosticAll());
        }

        private void ApplyFilters()
        {
            MedicalFiles.Clear();
            foreach (Models.MedicalFile medicalFile in Models.MedicalFile.GetMedicalFiles())
            {
                // If all or same illness type
                if (IllnessType.Name.Equals("All") && IllnessTypes.Contains(medicalFile.TargetIllness!)
                    || medicalFile.TargetIllness!.Name.Equals(IllnessType.Name))
                {
                    // If all or same diagnosis choice
                    if (DiagnosisChoice.Equals("All")
                        || DiagnosisChoice.Equals("Don't have diagnosis") && medicalFile.Diagnosis is null
                        || DiagnosisChoice.Equals("Already have diagnosis") && medicalFile.Diagnosis is not null)
                    {
                        MedicalFiles.Add(medicalFile);
                    }
                }
            }
        }
    }
}
