using System.Windows;

namespace Mediag.Views.Principal
{
    /// <summary>
    /// Interaction logic for Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal(Models.Doctor doctor)
        {
            InitializeComponent();
            DataContext = new ViewModels.PrincipalVM(doctor);
            Home_Click(this, new RoutedEventArgs());
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            PrincipalControl.Content = new Home.HomeUC() { DataContext = DataContext };
            Title = "Home";
        }
    }
}
