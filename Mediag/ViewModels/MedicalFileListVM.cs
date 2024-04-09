using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;

namespace Mediag.ViewModels
{
    public class MedicalFileListVM
    {
        public ObservableCollection<Models.MedicalFile> MedicalFiles { get; set; }

        public ICommand NewCommand { get; private set; }

        public ICommand ViewCommand { get; private set; }
        private void ViewPatient(object? patient)
        {
            MessageBox.Show("View Medical File");
            //Views.Principal.Patients.Patient patientWindow = patient is null ? new() : new((Models.Patient)patient, false);
            //patientWindow.Show();
            //patientWindow.Closed += (_, _) => RefreshPatients();
        }

        public ICommand EditCommand { get; private set; }
        private void EditMedicalFile(object? medicalFile = null)
        {
            // Open a new window to edit the medical file, or create a new medical file if medical file is null
            Views.Principal.MedicalFiles.MedicalFile medicalFileWindow = medicalFile is null ? new() : new((Models.MedicalFile)medicalFile);
            medicalFileWindow.Show();
            //medicalFileWindow.Closed += (_, _) => RefreshPatients();
        }

        public ICommand DeleteCommand { get; private set; }
        private void DeleteMedicalFile(object? medicalFile = null)
        {
            MessageBox.Show("Delete Medical File");
            //if (patient is null) return;

            //Models.Patient patientToDelete = (Models.Patient)patient;
            //MessageBoxResult result = MessageBox.Show(
            //    "Are you sure you want to delete this patient?\n" +
            //    $"Patient ({patientToDelete.Id}): {patientToDelete.FirstName} {patientToDelete.LastName}",
            //    "Delete Patient",
            //    MessageBoxButton.YesNo,
            //    MessageBoxImage.Warning);
            //if (result.Equals(MessageBoxResult.Yes))
            //{
            //    Models.Patient.DeletePatient(patientToDelete);
            //    Patients.Remove(patientToDelete);
            //}
        }

        public MedicalFileListVM()
        {
            MedicalFiles = new ObservableCollection<Models.MedicalFile>();
            NewCommand = new RelayCommand(_ => true, _ => EditMedicalFile());
            ViewCommand = new RelayCommand(_ => true, medicalFile => ViewPatient(medicalFile));
            EditCommand = new RelayCommand(_ => true, medicalFile => EditMedicalFile(medicalFile));
            DeleteCommand = new RelayCommand(_ => true, medicalFile => DeleteMedicalFile(medicalFile));

        }
    }
}
