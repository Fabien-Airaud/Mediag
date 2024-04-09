using System.Windows;

namespace Mediag.Views.Principal.MedicalFiles
{
    /// <summary>
    /// Interaction logic for MedicalFile.xaml
    /// </summary>
    public partial class MedicalFile : Window
    {
        public MedicalFile(Models.MedicalFile? medicalFile = null, bool isEditMode = true)
        {
            InitializeComponent();
            DataContext = new ViewModels.MedicalFileVM(medicalFile, isEditMode)
            {
                CloseMedicalFile = () => Close()
            };
        }
    }
}
