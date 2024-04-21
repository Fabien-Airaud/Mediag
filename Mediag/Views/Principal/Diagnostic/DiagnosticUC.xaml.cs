using System.Windows.Controls;

namespace Mediag.Views.Principal.Diagnostic
{
    /// <summary>
    /// Interaction logic for DiagnosticUC.xaml
    /// </summary>
    public partial class DiagnosticUC : UserControl
    {
        public DiagnosticUC()
        {
            InitializeComponent();
            DataContext = new ViewModels.DiagnosticVM();
        }
    }
}
