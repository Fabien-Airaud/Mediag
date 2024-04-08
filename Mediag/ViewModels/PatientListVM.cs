using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Mediag.ViewModels
{
    public class PatientListVM
    {
        public ObservableCollection<Models.Patient> Patients { get; set; }

        public ICommand NewCommand { get; private set; }
        private void NewPatient()
        {
            Views.Principal.Patients.Patient patientWindow = new();
            patientWindow.Show();
        }


        public PatientListVM()
        {
            Patients = [];
            NewCommand = new RelayCommand(_ => true, _ => NewPatient());
        }
    }
}
