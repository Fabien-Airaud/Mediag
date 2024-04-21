using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mediag.Models
{
    public class HeartDiseaseData : IMedicalData
    {
        public long Id { get; set; }

        public long ChestPainId { get; set; }
        private ChestPainTypes? _chestPain;
        public ChestPainTypes? ChestPain
        {
            get { return _chestPain; }
            set
            {
                if (_chestPain != value)
                {
                    _chestPain = value;
                    ChestPainId = value?.Id ?? 0;
                    OnPropertyChanged();
                }
            }
        }

        public long ThalassemiaId { get; set; }
        private ThalassemiaTypes? _thalassemia;
        public ThalassemiaTypes? Thalassemia
        {
            get { return _thalassemia; }
            set
            {
                if (_thalassemia != value)
                {
                    _thalassemia = value;
                    ThalassemiaId = value?.Id ?? 0;
                    OnPropertyChanged();
                }
            }
        }

        public long MajorVesselsId { get; set; }
        private MajorVesselsTypes? _majorVessels;
        public MajorVesselsTypes? MajorVessels
        {
            get { return _majorVessels; }
            set
            {
                if (_majorVessels != value)
                {
                    _majorVessels = value;
                    MajorVesselsId = value?.Id ?? 0;
                    OnPropertyChanged();
                }
            }
        }

        private double _oldPeak;
        public double OldPeak
        {
            get { return _oldPeak; }
            set
            {
                if (_oldPeak != value)
                {
                    _oldPeak = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _maximumHeartRateAchieved;
        public int MaximumHeartRateAchieved
        {
            get { return _maximumHeartRateAchieved; }
            set
            {
                if (_maximumHeartRateAchieved != value)
                {
                    _maximumHeartRateAchieved = value;
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
            return ChestPain != null && Thalassemia != null && MajorVessels != null
                && OldPeak >= 0 && MaximumHeartRateAchieved >= 0
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
            return ["ChestPain", "Thalassemia", "MajorVessels", "OldPeak", "MaximumHeartRateAchieved", "Result"];
        }

        public string[] Values()
        {
            return [ ChestPain?.ToString() ?? "", Thalassemia?.ToString() ?? "", MajorVessels?.ToString() ?? "", OldPeak.ToString(), MaximumHeartRateAchieved.ToString(), Result.ToString()];
        }

        public void CopyTo(IMedicalData medicalData)
        {
            if (medicalData is not HeartDiseaseData target) throw new ArgumentException("Invalid medical data type.");

            target.Id = Id;
            target.ChestPain = ChestPain;
            target.Thalassemia = Thalassemia;
            target.MajorVessels = MajorVessels;
            target.OldPeak = OldPeak;
            target.MaximumHeartRateAchieved = MaximumHeartRateAchieved;
            target.Result = Result;
            target.MedicalFile = MedicalFile;
        }

        private static void CorrectInObjects(MediagDbContext mediagDbContext, HeartDiseaseData heartDiseaseData)
        {
            heartDiseaseData.ChestPain = mediagDbContext.ChestPainTypes.Find(heartDiseaseData.ChestPainId);
            heartDiseaseData.Thalassemia = mediagDbContext.ThalassemiaTypes.Find(heartDiseaseData.ThalassemiaId);
            heartDiseaseData.MajorVessels = mediagDbContext.MajorVesselsTypes.Find(heartDiseaseData.MajorVesselsId);
            heartDiseaseData.MedicalFile = mediagDbContext.MedicalFiles.Find(heartDiseaseData.MedicalFileId);
            heartDiseaseData.Result = heartDiseaseData.Result; // To set IsMalignant and IsBenign
        }

        public static IMedicalData? GetMedicalData(long medicalFileId)
        {
            MediagDbContext mediagDbContext = new();
            HeartDiseaseData? heartDiseaseData = mediagDbContext.HeartDiseaseDatas.FirstOrDefault(heartDiseaseData => heartDiseaseData.MedicalFileId == medicalFileId);
            if (heartDiseaseData is not null) CorrectInObjects(mediagDbContext, heartDiseaseData);
            return heartDiseaseData;
        }

        public static IMedicalData AddMedicalData(IMedicalData medicalData)
        {
            if (medicalData is not HeartDiseaseData heartDiseaseData) throw new ArgumentException("Invalid medical data type.");

            MediagDbContext mediagDbContext = new();
            CorrectInObjects(mediagDbContext, heartDiseaseData);
            mediagDbContext.HeartDiseaseDatas.Add(heartDiseaseData);
            mediagDbContext.SaveChanges();
            return heartDiseaseData;
        }

        public static IMedicalData UpdateMedicalData(IMedicalData medicalData)
        {
            MediagDbContext mediagDbContext = new();
            HeartDiseaseData oldData = mediagDbContext.HeartDiseaseDatas.Find(medicalData.Id)!;
            medicalData.CopyTo(oldData);
            CorrectInObjects(mediagDbContext, oldData);
            mediagDbContext.SaveChanges();
            return medicalData;
        }

        public static void DeleteMedicalData(IMedicalData medicalData)
        {
            if (medicalData is not HeartDiseaseData heartDiseaseData) throw new ArgumentException("Invalid medical data type.");

            MediagDbContext mediagDbContext = new();
            mediagDbContext.HeartDiseaseDatas.Remove(heartDiseaseData);
            mediagDbContext.SaveChanges();
        }

        public override bool Equals(object? obj)
        {
            return obj is HeartDiseaseData data &&
                   Id == data.Id &&
                   ChestPainId == data.ChestPainId &&
                   ThalassemiaId == data.ThalassemiaId &&
                   MajorVesselsId == data.MajorVesselsId &&
                   OldPeak == data.OldPeak &&
                   MaximumHeartRateAchieved == data.MaximumHeartRateAchieved &&
                   Result == data.Result &&
                   MedicalFileId == data.MedicalFileId;
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(Id);
            hash.Add(ChestPainId);
            hash.Add(ThalassemiaId);
            hash.Add(MajorVesselsId);
            hash.Add(OldPeak);
            hash.Add(MaximumHeartRateAchieved);
            hash.Add(Result);
            hash.Add(MedicalFileId);
            return hash.ToHashCode();
        }
    }
}
