﻿using System.Collections.Generic;

namespace Mediag.Medical
{
    class Hospital
    {
        private static long lastId = 0;

        public long Id { get; set; } = ++lastId;

        public string Name { get; set; }

        public string City { get; set; }

        public List<Doctor> Doctors { get; set; } = new List<Doctor>();

        public List<Patient> Patients { get; set; } = new List<Patient>();

        public List<MedicalFile> OnGoingFiles { get; set; } = new List<MedicalFile>();

        public List<MedicalFile> ClosedFiles { get; set; } = new List<MedicalFile>();


        public Hospital() { }

        public Hospital(string name, string city)
        {
            Name = name;
            City = city;
        }


        public override string ToString()
        {
            return $"Hospital {Id}: \"{Name}\" in {City}";
        }
    }
}
