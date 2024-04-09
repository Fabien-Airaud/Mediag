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
                    //IsValidRegister = CheckIsValidRegister();
                }
            }
        }

        public long HospitalId { get; set; }
        private Hospital? _hospital;
        [Required]
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
                    //IsValidRegister = CheckIsValidRegister();
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
                    //IsValidRegister = CheckIsValidRegister();
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
                && Patient is not null && Hospital is not null && Doctor is not null;
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (propertyName != nameof(IsValid))
            {
                IsValid = CheckIsValid();
                if (propertyName != nameof(LastUpdate)) LastUpdate = DateTime.Now;
            }
        }

        public void CopyTo(MedicalFile target)
        {
            target.Id = Id;
            target.StartDate = StartDate;
            target.LastUpdate = LastUpdate;
            target.EndDate = EndDate;
            target.Patient = Patient;
            target.Hospital = Hospital;
            target.Doctor = Doctor;
        }

        public override bool Equals(object? obj)
        {
            return obj is MedicalFile file &&
                   Id == file.Id &&
                   StartDate == file.StartDate &&
                   LastUpdate == file.LastUpdate &&
                   EndDate == file.EndDate &&
                   PatientId == file.PatientId &&
                   HospitalId == file.HospitalId &&
                   DoctorId == file.DoctorId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, StartDate, LastUpdate, EndDate, PatientId, HospitalId, DoctorId);
        }
    }
}
