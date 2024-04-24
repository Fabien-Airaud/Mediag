using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Mediag.ViewModels
{
    public class PrincipalVM : INotifyPropertyChanged
    {
        public Models.Doctor Doctor { get; set; }

        public Action ClosePrincipal { get; set; } = () => { };

        private UserControl _principalContent = new Views.Principal.Home.HomeUC();
        public UserControl PrincipalContent
        {
            get { return _principalContent; }
            set
            {
                if (_principalContent != value)
                {
                    _principalContent = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand HomeCommand { get; private set; }
        private void DisplayHome()
        {
            PrincipalContent = new Views.Principal.Home.HomeUC();
        }

        public ICommand PatientListCommand { get; private set; }
        private void DisplayPatientList()
        {
            PrincipalContent = new Views.Principal.Patients.PatientsListUC();
        }

        public ICommand MedicalFileListCommand { get; private set; }
        private void DisplayMedicalFileList()
        {
            PrincipalContent = new Views.Principal.MedicalFiles.MedicalFileListUC();
        }

        public ICommand DecisionTreeCommand { get; private set; }
        private void DisplayDecisionTree()
        {
            PrincipalContent = new Views.Principal.DecisionTree.DecisionTreeUC();
        }

        public ICommand DiagnosticCommand { get; private set; }
        private void DisplayDiagnostic()
        {
            PrincipalContent = new Views.Principal.Diagnostic.DiagnosticUC();
        }

        public ICommand ProfileCommand { get; private set; }
        private void DisplayProfile()
        {
            PrincipalContent = new Views.Principal.Profile.ProfileUC(Doctor);
        }

        public ICommand CheckCSVCommand { get; private set; }
        private void CheckCSVFile()
        {
            PrincipalContent = new Views.Principal.Tools.CheckCSVFileUC();
        }

        public ICommand AddPatientCommand { get; private set; }
        private void AddPatient()
        {
            Views.Principal.Patients.Patient patientWindow = new();
            patientWindow.Show();
            patientWindow.Closed += (_, _) => DisplayPatientList();
        }

        public ICommand AddMedicalFileCommand { get; private set; }
        private void AddMedicalFile()
        {
            Views.Principal.MedicalFiles.MedicalFile medicalFileWindow = new();
            medicalFileWindow.Show();
            medicalFileWindow.Closed += (_, _) => DisplayMedicalFileList();
        }

        public ICommand LogOutCommand { get; private set; }
        private void LogOut()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to log out?", "Log out", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Views.LogIn.SignLogIn loginWindow = new();
                loginWindow.Show();
                ClosePrincipal();
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public PrincipalVM(Models.Doctor doctor)
        {
            Doctor = doctor;
            HomeCommand = new RelayCommand(_ => true, _ => DisplayHome());
            PatientListCommand = new RelayCommand(_ => true, _ => DisplayPatientList());
            MedicalFileListCommand = new RelayCommand(_ => true, _ => DisplayMedicalFileList());
            DecisionTreeCommand = new RelayCommand(_ => true, _ => DisplayDecisionTree());
            DiagnosticCommand = new RelayCommand(_ => true, _ => DisplayDiagnostic());
            ProfileCommand = new RelayCommand(_ => true, _ => DisplayProfile());
            CheckCSVCommand = new RelayCommand(_ => true, _ => CheckCSVFile());
            AddPatientCommand = new RelayCommand(_ => true, _ => AddPatient());
            AddMedicalFileCommand = new RelayCommand(_ => true, _ => AddMedicalFile());
            LogOutCommand = new RelayCommand(_ => true, _ => LogOut());
        }
    }
}
