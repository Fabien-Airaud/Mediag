using System.Windows;

namespace Mediag.Views.LogIn
{
    /// <summary>
    /// Interaction logic for SignLogIn.xaml
    /// </summary>
    public partial class SignLogIn : Window
    {
        public SignLogIn()
        {
            InitializeComponent();
            DataContext = new ViewModels.SignLogInViewModel();
            //DataContext = new ViewModels.SignLogInViewModel(this);
        }

        private void GoToRegister_Click(object sender, RoutedEventArgs e)
        {
            LogInTabs.SelectedItem = RegisterTab;
        }

        private void GoToLogIn_Click(object sender, RoutedEventArgs e)
        {
            LogInTabs.SelectedItem = LogInTab;
        }
    }
}
