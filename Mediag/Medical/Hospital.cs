using System;
using System.Collections.Generic;

namespace Mediag.Medical
{
    class Hospital
    {
        private static long lastId = 0;

        public long Id { get; protected set; } = ++lastId;

        public string Name { get; set; }

        public string City { get; set; }

        public List<Doctor> Doctors { get; private set; } = new List<Doctor>();
        public void AddDoctor(Doctor doctor)
        {
            Doctors.Add(doctor);
        }
        public void RemoveDoctor(Doctor doctor)
        {
            Doctors.Remove(doctor);
        }

        public List<Patient> Patients { get; private set; } = new List<Patient>();
        public void AddPatient(Patient patient)
        {
            Patients.Add(patient);
        }
        public void RemovePatient(Patient patient)
        {
            Patients.Remove(patient);
        }

        public List<MedicalFile> Files { get; private set; } = new List<MedicalFile>();
        public void AddFile(MedicalFile file)
        {
            Files.Add(file);
        }
        public void RemoveFile(MedicalFile file)
        {
            Files.Remove(file);
        }


        //public Hospital() { }

        public Hospital(string name, string city)
        {
            Name = name;
            City = city;
        }


        public override string ToString()
        {
            return $"Hospital {Id}: \"{Name}\" in {City} ; {Doctors.Count} doctors, {Patients.Count} patients, {Files.Count} files";
        }

        public override bool Equals(object obj)
        {
            return obj is Hospital hospital &&
                   Id == hospital.Id &&
                   Name == hospital.Name &&
                   City == hospital.City;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, City);
        }
    }
}
