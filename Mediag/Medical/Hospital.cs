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
            if (doctor != null)
            {
                Doctors.Add(doctor);

                if (!Equals(doctor.Hospital)) doctor.AddHospital(this);
            }
        }
        public void RemoveDoctor(Doctor doctor)
        {
            if (doctor != null)
            {
                Doctors.Remove(doctor);

                if (Equals(doctor.Hospital)) doctor.RemoveHospital();
            }
            Doctors.Remove(doctor);
        }

        public List<Patient> Patients { get; private set; } = new List<Patient>();
        public void AddPatient(Patient patient)
        {
            if (patient != null)
            {
                Patients.Add(patient);

                if (!Equals(patient.Hospital)) patient.AddHospital(this);
            }
        }
        public void RemovePatient(Patient patient)
        {
            if (patient != null)
            {
                Patients.Remove(patient);

                if (Equals(patient.Hospital)) patient.RemoveHospital();
            }
        }

        public List<MedicalFile> Files { get; private set; } = new List<MedicalFile>();
        public void AddFile(MedicalFile file)
        {
            if (file != null)
            {
                Files.Add(file);

                if (!Equals(file.Hospital)) file.AddHospital(this);
            }
        }
        public void RemoveFile(MedicalFile file)
        {
            if (file != null)
            {
                Files.Remove(file);

                if (Equals(file.Hospital)) file.RemoveHospital();
            }
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
    }
}
