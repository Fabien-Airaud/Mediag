using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Mediag.ViewModels
{
    public class PatientListVM
    {
        public ObservableCollection<Models.Patient> Patients { get; set; }

        public ICommand NewCommand { get; private set; }

        public ICommand ViewCommand { get; private set; }
        private void ViewPatient(object? patient)
        {
            Views.Principal.Patients.Patient patientWindow = patient is null ? new() : new((Models.Patient)patient, false);
            patientWindow.Show();
        }

        public ICommand EditCommand { get; private set; }
        private void EditPatient(object? patient = null)
        {
            // Open a new window to edit the patient, or create a new patient if patient is null
            Views.Principal.Patients.Patient patientWindow = patient is null ? new() : new((Models.Patient)patient);
            patientWindow.Show();
        }


        public PatientListVM()
        {
            Patients = new ObservableCollection<Models.Patient>(Models.Patient.GetPatients());
            NewCommand = new RelayCommand(_ => true, _ => EditPatient());
            ViewCommand = new RelayCommand(_ => true, patient => ViewPatient(patient));
            EditCommand = new RelayCommand(_ => true, patient => EditPatient(patient));
        }
    }
}
