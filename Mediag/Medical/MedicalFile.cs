using System;
using System.Collections.Generic;

namespace Mediag.Medical
{
    class MedicalFile
    {
        private static long lastId = 0;

        public long Id { get; protected set; } = ++lastId;

        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime LastUpdate { get; set; } = DateTime.Now;

        public DateTime EndDate { get; set; }

        public Patient Patient { get; private set; }
        public void AddPatient(Patient patient)
        {
            Patient = patient;
        }
        public void RemovePatient()
        {
            Patient = null;
        }

        public Hospital Hospital { get; private set; }
        public void AddHospital(Hospital hospital)
        {
            Hospital = hospital;
        }
        public void RemoveHospital()
        {
            Hospital = null;
        }

        public List<Doctor> DoctorsInCharge { get; private set; } = new List<Doctor>();
        public void AddDoctorInCharge(Doctor doctor)
        {
            DoctorsInCharge.Add(doctor);
        }
        public void RemoveDoctorInCharge(Doctor doctor)
        {
            DoctorsInCharge.Remove(doctor);
        }


        //public MedicalFile() { }

        public MedicalFile(Patient patient)
        {
            AddPatient(patient);
        }

        public MedicalFile(Patient patient, Hospital hospital)
        {
            AddPatient(patient);
            AddHospital(hospital);
        }

        public MedicalFile(DateTime startDate, Patient patient, Hospital hospital)
        {
            StartDate = startDate;
            AddPatient(patient);
            AddHospital(hospital);
        }


        public override string ToString()
        {
            return $"Medical file {Id}: {Patient.FirstName} {Patient.LastName}, {DoctorsInCharge.Count} doctors in charge";
        }

        public override bool Equals(object obj)
        {
            return obj is MedicalFile file &&
                   Id == file.Id &&
                   StartDate == file.StartDate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, StartDate);
        }
    }
}
