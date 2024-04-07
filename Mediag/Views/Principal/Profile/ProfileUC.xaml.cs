using System.Windows.Controls;

namespace Mediag.Views.Principal.Profile
{
    /// <summary>
    /// Interaction logic for ProfileUC.xaml
    /// </summary>
    public partial class ProfileUC : UserControl
    {
        public ProfileUC(Models.Doctor doctor)
        {
            InitializeComponent();
            DataContext = new ViewModels.ProfileVM(doctor);
        }
    }
}
