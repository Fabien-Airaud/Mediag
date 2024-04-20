using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Mediag.Models
{
    public class BreastCancerData : IMedicalData
    {
        public long Id { get; set; }

        private double _radiusWorst;
        public double RadiusWorst
        {
            get { return _radiusWorst; }
            set
            {
                if (_radiusWorst != value)
                {
                    _radiusWorst = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _areaWorst;
        public double AreaWorst
        {
            get { return _areaWorst; }
            set
            {
                if (_areaWorst != value)
                {
                    _areaWorst = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _perimeterWorst;
        public double PerimeterWorst
        {
            get { return _perimeterWorst; }
            set
            {
                if (_perimeterWorst != value)
                {
                    _perimeterWorst = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _concavePointsWorst;
        public double ConcavePointsWorst
        {
            get { return _concavePointsWorst; }
            set
            {
                if (_concavePointsWorst != value)
                {
                    _concavePointsWorst = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _concavePointsMean;
        public double ConcavePointsMean
        {
            get { return _concavePointsMean; }
            set
            {
                if (_concavePointsMean != value)
                {
                    _concavePointsMean = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _perimeterMean;
        public double PerimeterMean
        {
            get { return _perimeterMean; }
            set
            {
                if (_perimeterMean != value)
                {
                    _perimeterMean = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _result = true;
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
                if (IsMalignant != _result && IsBenign == _result)
                {
                    IsMalignant = _result;
                    IsBenign = !_result;
                }
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

        private bool _isMalignant = true;
        [NotMapped]
        public bool IsMalignant
        {
            get { return _isMalignant; }
            set
            {
                if (_isMalignant != value)
                {
                    _isMalignant = value;
                    Result = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isBenign = false;
        [NotMapped]
        public bool IsBenign
        {
            get { return _isBenign; }
            set
            {
                if (_isBenign != value)
                {
                    _isBenign = value;
                    Result = !value;
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
            if (propertyName == nameof(Result) || propertyName == nameof(IsMalignant) || propertyName == nameof(IsBenign))
            {
                ResultString = Result ? "Malignant" : "Benign";
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

        public void CopyTo(IMedicalData medicalData)
        {
            if (medicalData is not BreastCancerData target) throw new ArgumentException("Invalid medical data type.");

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

        private static void CorrectInObjects(MediagDbContext mediagDbContext, BreastCancerData breastCancerData)
        {
            breastCancerData.MedicalFile = mediagDbContext.MedicalFiles.Find(breastCancerData.MedicalFileId);
            breastCancerData.Result = breastCancerData.Result; // To set IsMalignant and IsBenign
        }

        public static IMedicalData? GetMedicalData(long medicalFileId)
        {
            MediagDbContext mediagDbContext = new();
            BreastCancerData? breastCancerData = mediagDbContext.BreastCancerDatas.FirstOrDefault(breastCancerData => breastCancerData.MedicalFileId == medicalFileId);
            if (breastCancerData is not null) CorrectInObjects(mediagDbContext, breastCancerData);
            return breastCancerData;
        }

        public static IMedicalData AddMedicalData(IMedicalData medicalData)
        {
            if (medicalData is not BreastCancerData breastCancerData) throw new ArgumentException("Invalid medical data type.");

            MediagDbContext mediagDbContext = new();
            CorrectInObjects(mediagDbContext, breastCancerData);
            mediagDbContext.BreastCancerDatas.Add(breastCancerData);
            mediagDbContext.SaveChanges();
            return breastCancerData;
        }

        public static IMedicalData UpdateMedicalData(IMedicalData medicalData)
        {
            MediagDbContext mediagDbContext = new();
            BreastCancerData oldData = mediagDbContext.BreastCancerDatas.Find(medicalData.Id)!;
            medicalData.CopyTo(oldData);
            CorrectInObjects(mediagDbContext, oldData);
            mediagDbContext.SaveChanges();
            return medicalData;
        }

        public static void DeleteMedicalData(IMedicalData medicalData)
        {
            if (medicalData is not BreastCancerData breastCancerData) throw new ArgumentException("Invalid medical data type.");

            MediagDbContext mediagDbContext = new();
            mediagDbContext.BreastCancerDatas.Remove(breastCancerData);
            mediagDbContext.SaveChanges();
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
