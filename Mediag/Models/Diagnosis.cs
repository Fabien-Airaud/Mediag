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

        public void CopyTo(Diagnosis target)
        {
            target.Id = Id;
            target.Date = Date;
            target.Result = Result;
            target.MedicalFile = MedicalFile;
        }

        private static void CorrectInObjects(MediagDbContext mediagDbContext, Diagnosis diagnosis)
        {
            diagnosis.MedicalFile = mediagDbContext.MedicalFiles.Find(diagnosis.MedicalFileId);
            diagnosis.Result = diagnosis.Result;
        }

        public static Diagnosis? GetDiagnosis(long medicalFileId)
        {
            MediagDbContext mediagDbContext = new();
            Diagnosis? diagnosis = mediagDbContext.Diagnosis.FirstOrDefault(diagnosis => diagnosis.MedicalFileId == medicalFileId);
            if (diagnosis is not null) CorrectInObjects(mediagDbContext, diagnosis);
            return diagnosis;
        }

        public static Diagnosis AddDiagnosis(Diagnosis diagnosis)
        {
            MediagDbContext mediagDbContext = new();
            CorrectInObjects(mediagDbContext, diagnosis);
            mediagDbContext.Diagnosis.Add(diagnosis);
            mediagDbContext.SaveChanges();
            return diagnosis;
        }

        public static Diagnosis UpdateDiagnosis(Diagnosis diagnosis)
        {
            MediagDbContext mediagDbContext = new();
            Diagnosis oldDiagnosis = mediagDbContext.Diagnosis.Find(diagnosis.Id)!;
            diagnosis.CopyTo(oldDiagnosis);
            CorrectInObjects(mediagDbContext, oldDiagnosis);
            mediagDbContext.SaveChanges();
            return diagnosis;
        }

        public static void DeleteDiagnosis(Diagnosis diagnosis)
        {
            MediagDbContext mediagDbContext = new();
            mediagDbContext.Diagnosis.Remove(diagnosis);
            mediagDbContext.SaveChanges();
        }

        public override string? ToString()
        {
            return $"Diagnosis:\t{ResultString} on {Date}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Diagnosis diagnosis &&
                   Id == diagnosis.Id &&
                   Date == diagnosis.Date &&
                   Result == diagnosis.Result &&
                   MedicalFileId == diagnosis.MedicalFileId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Date, Result, MedicalFileId);
        }
    }
}
