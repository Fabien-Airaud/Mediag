using System;
using System.Collections.Generic;

namespace Mediag.Medical
{
    class Patient : Person
    {
        private static long lastId = 0;

        public override void AddHospital(Hospital hospital)
        {
            if (hospital != null)
            {
                Hospital = hospital;

                if (!hospital.Patients.Contains(this)) hospital.AddPatient(this);
            }
        }
        public override void RemoveHospital()
        {
            if (Hospital != null)
            {
                Hospital hospital = Hospital;
                Hospital = null;

                if (hospital.Patients.Contains(this)) hospital.RemovePatient(this);
            }
        }

        public List<MedicalFile> Files { get; private set; }
        public void AddFile(MedicalFile file)
        {
            if (Files != null)
            {
                Files.Add(file);

                if (!file.Patient.Equals(this)) file.AddPatient(this);
            }
        }
        public void RemoveFile(MedicalFile file)
        {
            if (Files != null)
            {
                Files.Remove(file);

                if (file.Patient.Equals(this)) file.RemovePatient();
            }
        }


        //public Patient() : base() { Id = ++lastId; }

        public Patient(string lastName, string firstName, DateTime birthdate, string phoneNumber, string email, string address)
            : base(lastName, firstName, birthdate, phoneNumber, email, address) { Id = ++lastId; }
    }
}
