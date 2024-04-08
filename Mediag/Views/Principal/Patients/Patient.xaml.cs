using System.Windows;

namespace Mediag.Views.Principal.Patients
{
    /// <summary>
    /// Interaction logic for Patient.xaml
    /// </summary>
    public partial class Patient : Window
    {
        public Patient(Models.Patient? patient = null, bool isEditMode = true)
        {
            InitializeComponent();
            DataContext = new ViewModels.PatientVM(patient, isEditMode);
        }
    }
}
