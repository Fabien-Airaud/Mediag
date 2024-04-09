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
            patientWindow.Closed += (_, _) => RefreshPatients();
        }

        public ICommand EditCommand { get; private set; }
        private void EditPatient(object? patient = null)
        {
            // Open a new window to edit the patient, or create a new patient if patient is null
            Views.Principal.Patients.Patient patientWindow = patient is null ? new() : new((Models.Patient)patient);
            patientWindow.Show();
            patientWindow.Closed += (_, _) => RefreshPatients();
        }

        public ICommand DeleteCommand { get; private set; }
        private void DeletePatient(object? patient = null)
        {
            if (patient is null) return;

            Models.Patient patientToDelete = (Models.Patient)patient;
            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to delete this patient?\n" +
                $"Patient ({patientToDelete.Id}): {patientToDelete.FirstName} {patientToDelete.LastName}",
                "Delete Patient",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);
            if (result.Equals(MessageBoxResult.Yes))
            {
                Models.Patient.DeletePatient(patientToDelete);
                Patients.Remove(patientToDelete);
            }
        }


        public PatientListVM()
        {
            Patients = new ObservableCollection<Models.Patient>(Models.Patient.GetPatients());
            NewCommand = new RelayCommand(_ => true, _ => EditPatient());
            ViewCommand = new RelayCommand(_ => true, patient => ViewPatient(patient));
            EditCommand = new RelayCommand(_ => true, patient => EditPatient(patient));
            DeleteCommand = new RelayCommand(_ => true, patient => DeletePatient(patient));
        }

        private void RefreshPatients()
        {
            Patients.Clear();
            foreach (Models.Patient patient in Models.Patient.GetPatients())
            {
                Patients.Add(patient);
            }
        }
    }
}
