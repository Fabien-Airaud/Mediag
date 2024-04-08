using System.Windows.Controls;

namespace Mediag.Views.Principal.Patients
{
    /// <summary>
    /// Interaction logic for PatientsListUC.xaml
    /// </summary>
    public partial class PatientsListUC : UserControl
    {
        public PatientsListUC()
        {
            InitializeComponent();
            DataContext = new ViewModels.PatientListVM();
        }
    }
}
