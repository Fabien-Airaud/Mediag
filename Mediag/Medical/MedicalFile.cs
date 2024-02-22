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
            if (patient != null)
            {
                Patient = patient;

                if (!patient.Files.Contains(this)) patient.AddFile(this);
            }
        }
        public void RemovePatient()
        {
            if (Patient != null)
            {
                Patient patient = Patient;
                Patient = null;

                if (patient.Files.Contains(this)) patient.RemoveFile(this);
            }
        }

        public Hospital Hospital { get; private set; }
        public void AddHospital(Hospital hospital)
        {
            if (hospital != null)
            {
                Hospital = hospital;

                if (!hospital.Files.Contains(this)) hospital.AddFile(this);
            }
        }
        public void RemoveHospital()
        {
            if (Hospital != null)
            {
                Hospital hospital = Hospital;
                Hospital = null;

                if (hospital.Files.Contains(this)) hospital.RemoveFile(this);
            }
        }

        public List<Doctor> DoctorsInCharge { get; private set; } = [];
        public void AddDoctorInCharge(Doctor doctor)
        {
            if (doctor != null)
            {
                DoctorsInCharge.Add(doctor);

                if (!doctor.FilesToTreat.Contains(this)) doctor.AddFileToTreat(this);
            }
        }
        public void RemoveDoctorInCharge(Doctor doctor)
        {
            if (doctor != null)
            {
                DoctorsInCharge.Remove(doctor);

                if (doctor.FilesToTreat.Contains(this)) doctor.RemoveFileToTreat(this);
            }
        }

        public IMedicalData MedicalData { get; set; }


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
