﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Mediag.Models
{
    [Index(nameof(Name), nameof(City), IsUnique = true)]
    public class Hospital : INotifyPropertyChanged
    {
        public long Id { get; set; }

        private string _name = "";
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _city = "";
        public string City
        {
            get { return _city; }
            set
            {
                if (_city != value)
                {
                    _city = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICollection<Doctor> Doctors { get; set; } = [];

        public ICollection<Patient> Patients { get; set; } = [];

        public ICollection<MedicalFile> MedicalFiles { get; set; } = [];

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
            return !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(City);
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

        public static ICollection<Hospital> GetHospitals()
        {
            MediagDbContext mediagDbContext = new();
            return [.. mediagDbContext.Hospitals]; // Copy the collection
        }

        public override string? ToString()
        {
            return $"{Name} in {City}";
        }
    }
}
