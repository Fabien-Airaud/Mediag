using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Mediag.Models
{
    public class BreastCancerData : IMedicalData
    {
        public long Id { get; set; }

        public double RadiusWorst { get; set; }

        public double AreaWorst { get; set; }

        public double PerimeterWorst { get; set; }

        public double ConcavePointsWorst { get; set; }

        public double ConcavePointsMean { get; set; }

        public double PerimeterMean { get; set; }

        public bool Result { get; set; }

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

        private bool _isValid;
        [NotMapped]
        public bool IsValid
        {
            get { return _isValid; }
            protected set
            {
                if (_isValid != value)
                {
                    _isValid = value;
                    OnPropertyChanged();
                }
            }
        }
        protected virtual bool CheckIsValid()
        {
            return !string.IsNullOrWhiteSpace(RadiusWorst.ToString()) && !string.IsNullOrWhiteSpace(AreaWorst.ToString())
                && !string.IsNullOrWhiteSpace(PerimeterWorst.ToString()) && !string.IsNullOrWhiteSpace(ConcavePointsWorst.ToString())
                && !string.IsNullOrWhiteSpace(ConcavePointsMean.ToString()) && !string.IsNullOrWhiteSpace(PerimeterMean.ToString())
                && !string.IsNullOrWhiteSpace(Result.ToString()) && MedicalFile is not null;
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (propertyName != nameof(IsValid))
            {
                IsValid = CheckIsValid();
            }
        }

        public string[] Labels()
        {
            return ["RadiusWorst", "AreaWorst", "PerimeterWorst", "ConcavePointsWorst", "ConcavePointsMean", "PerimeterMean", "Result"];
        }

        public string[] Values()
        {
            return [RadiusWorst.ToString(), AreaWorst.ToString(), PerimeterWorst.ToString(), ConcavePointsWorst.ToString(), ConcavePointsMean.ToString(), PerimeterMean.ToString(), Result.ToString()];
        }

        public void CopyTo(BreastCancerData target)
        {
            target.Id = Id;
            target.RadiusWorst = RadiusWorst;
            target.AreaWorst = AreaWorst;
            target.PerimeterWorst = PerimeterWorst;
            target.ConcavePointsWorst = ConcavePointsWorst;
            target.ConcavePointsMean = ConcavePointsMean;
            target.PerimeterMean = PerimeterMean;
            target.Result = Result;
            target.MedicalFile = MedicalFile;
        }

        public override bool Equals(object? obj)
        {
            return obj is BreastCancerData data &&
                   Id == data.Id &&
                   RadiusWorst == data.RadiusWorst &&
                   AreaWorst == data.AreaWorst &&
                   PerimeterWorst == data.PerimeterWorst &&
                   ConcavePointsWorst == data.ConcavePointsWorst &&
                   ConcavePointsMean == data.ConcavePointsMean &&
                   PerimeterMean == data.PerimeterMean &&
                   Result == data.Result &&
                   MedicalFileId == data.MedicalFileId;
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(Id);
            hash.Add(RadiusWorst);
            hash.Add(AreaWorst);
            hash.Add(PerimeterWorst);
            hash.Add(ConcavePointsWorst);
            hash.Add(ConcavePointsMean);
            hash.Add(PerimeterMean);
            hash.Add(Result);
            hash.Add(MedicalFileId);
            return hash.ToHashCode();
        }
    }
}
