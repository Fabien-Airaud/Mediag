using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mediag.ViewModels
{
    public class MedicalFileVM : INotifyPropertyChanged
    {
        public Models.MedicalFile MedicalFile { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public MedicalFileVM(Models.MedicalFile? medicalFile = null, bool isEditMode = true)
        {
            MedicalFile = new Models.MedicalFile();
            medicalFile?.CopyTo(MedicalFile);
        }
    }
}
