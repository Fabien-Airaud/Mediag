﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Mediag.Models
{
    public class MedicalFile : INotifyPropertyChanged
    {
        public long Id { get; set; }

        private DateTime _startDate = DateTime.Today;
        [Column(TypeName = "date")]
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime _lastUpdate = DateTime.Now;
        public DateTime LastUpdate
        {
            get { return _lastUpdate; }
            set
            {
                if (_lastUpdate != value)
                {
                    _lastUpdate = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime? _endDate;
        [Column(TypeName = "date")]
        public DateTime? EndDate
        {
            get { return _endDate; }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public long TargetIllnessId { get; set; }
        private IllnessTypes? _targetIllness;
        [Required]
        public IllnessTypes? TargetIllness
        {
            get { return _targetIllness; }
            set
            {
                if (_targetIllness != value)
                {
                    _targetIllness = value;
                    TargetIllnessId = value?.Id ?? 0;
                    OnPropertyChanged();
                }
            }
        }

        public long PatientId { get; set; }
        private Patient? _patient;
        [Required]
        public Patient? Patient
        {
            get { return _patient; }
            set
            {
                if (_patient != value)
                {
                    _patient = value;
                    PatientId = value?.Id ?? 0;
                    OnPropertyChanged();
                }
            }
        }

        public long DoctorId { get; set; }
        private Doctor? _doctor;
        [Required]
        public Doctor? Doctor
        {
            get { return _doctor; }
            set
            {
                if (_doctor != value)
                {
                    _doctor = value;
                    DoctorId = value?.Id ?? 0;
                    OnPropertyChanged();
                }
            }
        }

        public long? HospitalId { get; set; }
        private Hospital? _hospital;
        public Hospital? Hospital
        {
            get { return _hospital; }
            set
            {
                if (_hospital != value)
                {
                    _hospital = value;
                    HospitalId = value?.Id ?? 0;
                    OnPropertyChanged();
                }
            }
        }

        private IMedicalData? _medicalData;
        [NotMapped]
        public IMedicalData? MedicalData
        {
            get { return _medicalData; }
            set
            {
                if (_medicalData != value)
                {
                    _medicalData = value;
                    OnPropertyChanged();
                }
            }
        }

        private Diagnosis? _diagnosis;
        [NotMapped]
        public Diagnosis? Diagnosis
        {
            get { return _diagnosis; }
            set
            {
                if (_diagnosis != value)
                {
                    _diagnosis = value;
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
            return StartDate <= DateTime.Today && (EndDate is null || EndDate <= DateTime.Today)
                && TargetIllness is not null && Patient is not null && Doctor is not null && Hospital is not null;
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (propertyName != nameof(IsValid) && propertyName != nameof(LastUpdate))
            {
                IsValid = CheckIsValid();
                LastUpdate = DateTime.Now;
            }
        }

        public void CopyTo(MedicalFile target)
        {
            target.Id = Id;
            target.StartDate = StartDate;
            target.LastUpdate = LastUpdate;
            target.EndDate = EndDate;
            target.TargetIllness = TargetIllness;
            target.Patient = Patient;
            target.Doctor = Doctor;
            target.Hospital = Hospital;
            target.Diagnosis = Diagnosis;
            target.MedicalData = TargetIllness?.Name switch
            {
                "Breast cancer" => new BreastCancerData()
                {
                    MedicalFileId = Id,
                    MedicalFile = target
                },
                "Heart disease" => new HeartDiseaseData()
                {
                    MedicalFileId = Id,
                    MedicalFile = target
                },
                _ => null
            };
            if (target.MedicalData is not null) MedicalData!.CopyTo(target.MedicalData);
        }

        private static void CorrectInObjects(MediagDbContext mediagDbContext, MedicalFile medicalFile)
        {
            medicalFile.TargetIllness = mediagDbContext.IllnessTypes.Find(medicalFile.TargetIllnessId);
            medicalFile.Patient = mediagDbContext.Patients.Find(medicalFile.PatientId);
            medicalFile.Doctor = mediagDbContext.Doctors.Find(medicalFile.DoctorId);
            medicalFile.Hospital = mediagDbContext.Hospitals.Find(medicalFile.HospitalId);
            medicalFile.Diagnosis = Diagnosis.GetDiagnosis(medicalFile.Id);
            if (medicalFile.Id != 0)
            {
                medicalFile.MedicalData = medicalFile.TargetIllness?.Name switch
                {
                    "Breast cancer" => BreastCancerData.GetMedicalData(medicalFile.Id),
                    "Heart disease" => HeartDiseaseData.GetMedicalData(medicalFile.Id),
                    _ => throw new ArgumentException("Invalid medical data type.")
                };
            }
        }

        public static ICollection<MedicalFile> GetMedicalFiles()
        {
            MediagDbContext mediagDbContext = new();
            ICollection<MedicalFile> medicalFiles = [.. mediagDbContext.MedicalFiles];
            foreach (MedicalFile medicalFile in medicalFiles) CorrectInObjects(mediagDbContext, medicalFile);
            return medicalFiles;
        }

        public static MedicalFile AddMedicalFile(MedicalFile medicalFile)
        {
            MediagDbContext mediagDbContext = new();
            CorrectInObjects(mediagDbContext, medicalFile);
            mediagDbContext.MedicalFiles.Add(medicalFile);
            mediagDbContext.SaveChanges();

            // Add medical data
            medicalFile.MedicalData!.MedicalFileId = medicalFile.Id;
            medicalFile.MedicalData = medicalFile.MedicalData switch
            {
                BreastCancerData breastCancerData => BreastCancerData.AddMedicalData(breastCancerData),
                HeartDiseaseData heartDiseaseData => HeartDiseaseData.AddMedicalData(heartDiseaseData),
                _ => throw new ArgumentException("Invalid medical data type.")
            };

            // Add diagnosis
            if (medicalFile.Diagnosis is not null)
            {
                medicalFile.Diagnosis.MedicalFileId = medicalFile.Id;
                medicalFile.Diagnosis = Diagnosis.AddDiagnosis(medicalFile.Diagnosis);
            }
            return medicalFile;
        }

        public static MedicalFile UpdateMedicalFile(MedicalFile medicalFile)
        {
            MediagDbContext mediagDbContext = new();
            MedicalFile oldMedicalFile = mediagDbContext.MedicalFiles.Find(medicalFile.Id)!; // Medical file is not null
            medicalFile.CopyTo(oldMedicalFile);
            CorrectInObjects(mediagDbContext, oldMedicalFile);
            mediagDbContext.SaveChanges();

            // Update medical data
            medicalFile.MedicalData = medicalFile.MedicalData switch
            {
                BreastCancerData breastCancerData => BreastCancerData.UpdateMedicalData(breastCancerData),
                HeartDiseaseData heartDiseaseData => HeartDiseaseData.UpdateMedicalData(heartDiseaseData),
                _ => throw new ArgumentException("Invalid medical data type.")
            };

            // Update diagnosis
            if (medicalFile.Diagnosis is not null)
            {
                medicalFile.Diagnosis.MedicalFileId = medicalFile.Id;

                if (oldMedicalFile.Diagnosis is not null) medicalFile.Diagnosis = Diagnosis.UpdateDiagnosis(medicalFile.Diagnosis);
                else medicalFile.Diagnosis = Diagnosis.AddDiagnosis(medicalFile.Diagnosis);
            }
            else
            {
                if (oldMedicalFile.Diagnosis is not null) Diagnosis.DeleteDiagnosis(oldMedicalFile.Diagnosis);
            }
            return medicalFile;
        }

        public static void DeleteMedicalFile(MedicalFile medicalFile)
        {
            // Delete medical data
            switch (medicalFile.MedicalData)
            {
                case BreastCancerData breastCancerData:
                    BreastCancerData.DeleteMedicalData(breastCancerData);
                    break;
                case HeartDiseaseData heartDiseaseData:
                    HeartDiseaseData.DeleteMedicalData(heartDiseaseData);
                    break;
                default:
                    throw new ArgumentException("Invalid medical data type.");
            }

            // Delete diagnosis
            if (medicalFile.Diagnosis is not null) Diagnosis.DeleteDiagnosis(medicalFile.Diagnosis);

            MediagDbContext mediagDbContext = new();
            mediagDbContext.MedicalFiles.Remove(medicalFile);
            mediagDbContext.SaveChanges();
        }

        public override bool Equals(object? obj)
        {
            return obj is MedicalFile file &&
                   Id == file.Id &&
                   StartDate == file.StartDate &&
                   LastUpdate == file.LastUpdate &&
                   EndDate == file.EndDate &&
                   TargetIllness == file.TargetIllness &&
                   PatientId == file.PatientId &&
                   DoctorId == file.DoctorId &&
                   HospitalId == file.HospitalId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, StartDate, LastUpdate, EndDate, TargetIllness, PatientId, DoctorId, HospitalId);
        }
    }
}
