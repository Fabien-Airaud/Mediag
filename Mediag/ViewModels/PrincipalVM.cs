using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;

namespace Mediag.ViewModels
{
    public class PrincipalVM : INotifyPropertyChanged
    {
        public Models.Doctor Doctor { get; set; }

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

        public ICommand ProfileCommand { get; private set; }
        private void DisplayProfile()
        {
            PrincipalContent = new Views.Principal.Profile.ProfileUC(Doctor);
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
            ProfileCommand = new RelayCommand(_ => true, _ => DisplayProfile());
        }
    }
}
