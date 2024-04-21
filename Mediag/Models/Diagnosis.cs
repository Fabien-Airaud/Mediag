using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Mediag.Models
{
    public class Diagnosis : INotifyPropertyChanged
    {
        public long Id { get; set; }

        private DateTime _date = DateTime.Now;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _result;
        public bool Result
        {
            get { return _result; }
            set
            {
                if (_result != value)
                {
                    _result = value;
                    OnPropertyChanged();
                }
                ResultString = _result ? "Malignant" : "Benign";
            }
        }

        private string _resultString = "Malignant";
        [NotMapped]
        public string ResultString
        {
            get { return _resultString; }
            set
            {
                if (_resultString != value)
                {
                    _resultString = value;
                    OnPropertyChanged();
                }
            }
        }

        public long? MedicalFileId { get; set; }
        private MedicalFile? _medicalFile;
        [Required]
        public MedicalFile? MedicalFile
        {
            get { return _medicalFile; }
            set
            {
                if (_medicalFile != value)
                {
                    _medicalFile = value;
                    MedicalFileId = value?.Id ?? 0;
                    OnPropertyChanged();
                }
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
