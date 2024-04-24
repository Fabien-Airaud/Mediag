using CsvHelper;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Mediag.ViewModels
{
    public class CheckCSVFileVM : INotifyPropertyChanged
    {
        private static readonly string positiveResult = "The CSV file is valid.";
        private static readonly string negativeResult = "The CSV file is not valid.";

        private string _csvFilePath;
        private string _filename;
        public string Filename
        {
            get { return _filename; }
            set
            {
                if (_filename != value)
                {
                    _filename = value;
                    OnPropertyChanged();
                }
            }
        }

        private Models.IllnessTypes _targetIllness;
        public Models.IllnessTypes TargetIllness
        {
            get { return _targetIllness; }
            set
            {
                if (_targetIllness != value)
                {
                    _targetIllness = value;
                    ResultCheckCSV = "";
                    OnPropertyChanged();
                }
            }
        }

        private string _resultCheckCSV;
        public string ResultCheckCSV
        {
            get { return _resultCheckCSV; }
            set
            {
                if (_resultCheckCSV != value)
                {
                    _resultCheckCSV = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _datagridVisibility;
        public string DatagridVisibility
        {
            get { return _datagridVisibility; }
            set
            {
                if (_datagridVisibility != value)
                {
                    _datagridVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Models.IllnessTypes> IllnessTypes { get; set; }

        public Action<string[], List<string[]>> ChangeDatagridData { get; set; } = (_, _) => { };

        public ICommand OpenCSVCommand { get; private set; }
        private void OpenCSVFile()
        {
            // Configure open file dialog box
            OpenFileDialog openFileDialog = new()
            {
                DefaultExt = ".csv", // Default file extension
                Filter = "CSV Files (*.csv)|*.csv" // Filter files by extension
            };

            // Process open file dialog box
            if (openFileDialog.ShowDialog() == true)
            {
                string filename = openFileDialog.FileName;
                if (filename == null || !System.IO.File.Exists(filename))
                {
                    MessageBox.Show("File not found", "File error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _csvFilePath = filename;
                Filename = openFileDialog.SafeFileName;
                ReadCSV(filename);
                DatagridVisibility = "Visible";
            }
        }

        public ICommand CheckCSVCommand { get; private set; }
        private void CheckCSV()
        {
            switch (TargetIllness.Name)
            {
                case "Breast cancer":
                    ResultCheckCSV = Models.BreastCancerData.IsValidCSV(_csvFilePath) ? positiveResult : negativeResult;
                    break;
                case "Heart disease":
                    ResultCheckCSV = Models.HeartDiseaseData.IsValidCSV(_csvFilePath) ? positiveResult : negativeResult;
                    break;
                default:
                    MessageBox.Show("Illness not found", "Illness error", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public CheckCSVFileVM()
        {
            _csvFilePath = "";
            _filename = "";

            _resultCheckCSV = "";
            OnPropertyChanged(nameof(ResultCheckCSV));
            _datagridVisibility = "Hidden";
            OnPropertyChanged(nameof(DatagridVisibility));

            IllnessTypes = new(Models.IllnessTypes.GetIllnessTypes());
            _targetIllness = IllnessTypes.First();
            OnPropertyChanged(nameof(TargetIllness));

            OpenCSVCommand = new RelayCommand(_ => true, _ => OpenCSVFile());
            CheckCSVCommand = new RelayCommand(_ => !string.IsNullOrWhiteSpace(_csvFilePath), _ => CheckCSV());
        }


        private void ReadCSV(string filename)
        {
            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                string[] headers = csv.HeaderRecord;
                Debug.WriteLine(string.Join(", ", headers));

                List<string[]> records = [];
                while (csv.Read())
                {
                    string[] record = new string[csv.HeaderRecord.Length];
                    for (int i = 0; i < csv.HeaderRecord.Length; i++) record[i] = csv.GetField(i);
                    records.Add(record);
                }
                ChangeDatagridData(headers, records);
            }
        }
    }
}
