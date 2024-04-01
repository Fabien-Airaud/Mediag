using System.Windows.Controls;

namespace Mediag.Views.Principal
{
    /// <summary>
    /// Interaction logic for MedicalFiles.xaml
    /// </summary>
    public partial class MedicalFilesPage : Page
    {
        public MedicalFilesPage()
        {
            InitializeComponent();

            object data = new {Id = 1, LastName = "Doe", FirstName = "John", TargetIllness = "BreastCancer", StartDate = new DateTime(2021, 1, 1), LastUpdate = new DateTime(2021, 1, 2), EndDate = new DateTime(2021, 1, 3), Diagnosis = "True" };
            MedicalFilesGrid.Items.Add(data);
        }
    }
}
