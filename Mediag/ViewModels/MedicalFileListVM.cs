using System.Collections.ObjectModel;

namespace Mediag.ViewModels
{
    public class MedicalFileListVM
    {
        public ObservableCollection<Models.MedicalFile> MedicalFiles { get; set; }

        public MedicalFileListVM()
        {
            MedicalFiles = new ObservableCollection<Models.MedicalFile>();
        }
    }
}
