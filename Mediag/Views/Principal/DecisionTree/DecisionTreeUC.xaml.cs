using System.Windows.Controls;

namespace Mediag.Views.Principal.DecisionTree
{
    /// <summary>
    /// Interaction logic for DecisionTreeUC.xaml
    /// </summary>
    public partial class DecisionTreeUC : UserControl
    {
        public DecisionTreeUC()
        {
            InitializeComponent();
            DataContext = new ViewModels.DecisionTreeVM();
        }
    }
}
