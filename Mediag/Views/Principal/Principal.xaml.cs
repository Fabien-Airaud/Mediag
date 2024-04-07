using System.Windows;

namespace Mediag.Views.Principal
{
    /// <summary>
    /// Interaction logic for Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
            DataContext = new ViewModels.PrincipalVM();

            PrincipalControl.Content = new Home.HomeUC();
            PrincipalControl.DataContext = DataContext;
            Title = "Home";
        }
    }
}
