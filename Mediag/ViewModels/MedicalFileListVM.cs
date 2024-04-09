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
        private void ViewMedicalFile(object? medicalFile)
        {
            //MessageBox.Show("View Medical File");
            Views.Principal.MedicalFiles.MedicalFile medicalFileWindow = medicalFile is null ? new() : new((Models.MedicalFile)medicalFile, false);
            medicalFileWindow.Show();
            medicalFileWindow.Closed += (_, _) => RefreshMedicalFiles();
        }

        public ICommand EditCommand { get; private set; }
        private void EditMedicalFile(object? medicalFile = null)
        {
            // Open a new window to edit the medical file, or create a new medical file if medical file is null
            Views.Principal.MedicalFiles.MedicalFile medicalFileWindow = medicalFile is null ? new() : new((Models.MedicalFile)medicalFile);
            medicalFileWindow.Show();
            medicalFileWindow.Closed += (_, _) => RefreshMedicalFiles();
        }

        public ICommand DeleteCommand { get; private set; }
        private void DeleteMedicalFile(object? medicalFile = null)
        {
            //MessageBox.Show("Delete Medical File");
            if (medicalFile is null) return;

            Models.MedicalFile medicalFileToDelete = (Models.MedicalFile)medicalFile;
            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to delete this medical file?\n" +
                $"Medical file ({medicalFileToDelete.Id}): {medicalFileToDelete.Patient}",
                "Delete Medical file",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);
            if (result.Equals(MessageBoxResult.Yes))
            {
                Models.MedicalFile.DeleteMedicalFile(medicalFileToDelete);
                MedicalFiles.Remove(medicalFileToDelete);
            }
        }

        public MedicalFileListVM()
        {
            MedicalFiles = new ObservableCollection<Models.MedicalFile>(Models.MedicalFile.GetMedicalFiles());
            NewCommand = new RelayCommand(_ => true, _ => EditMedicalFile());
            ViewCommand = new RelayCommand(_ => true, medicalFile => ViewMedicalFile(medicalFile));
            EditCommand = new RelayCommand(_ => true, medicalFile => EditMedicalFile(medicalFile));
            DeleteCommand = new RelayCommand(_ => true, medicalFile => DeleteMedicalFile(medicalFile));
        }

        private void RefreshMedicalFiles()
        {
            MedicalFiles.Clear();
            foreach (Models.MedicalFile medicalFile in Models.MedicalFile.GetMedicalFiles())
            {
                MedicalFiles.Add(medicalFile);
            }
        }
    }
}
