using System.Windows.Controls;
using System.Windows.Data;

namespace Mediag.Views.Principal.Tools
{
    /// <summary>
    /// Interaction logic for CheckCSVFileUC.xaml
    /// </summary>
    public partial class CheckCSVFileUC : UserControl
    {
        public CheckCSVFileUC()
        {
            InitializeComponent();
            DataContext = new ViewModels.CheckCSVFileVM()
            {
                ChangeDatagridData = (headers, data) => ChangeDatagridData(headers, data)
            };
        }

        private void ChangeDatagridData(string[] headers, List<string[]> data)
        {
            DatagridCSV.Columns.Clear();

            for (int i = 0; i < headers.Length; i++)
            {
                DatagridCSV.Columns.Add(new DataGridTextColumn()
                {
                    Header = headers[i],
                    Binding = new Binding($"[{i}]")
                });
            }
            DatagridCSV.ItemsSource = data;
        }
    }
}
