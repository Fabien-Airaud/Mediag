using System.Windows.Controls;

namespace Mediag.Views.Principal.MedicalFiles
{
    /// <summary>
    /// Interaction logic for MedicalFileListUC.xaml
    /// </summary>
    public partial class MedicalFileListUC : UserControl
    {
        public MedicalFileListUC()
        {
            InitializeComponent();
            DataContext = new ViewModels.MedicalFileListVM();
        }
    }
}
