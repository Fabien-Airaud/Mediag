using System;
using System.Collections.Generic;

namespace Mediag.Medical
{
    class Patient : Person
    {
        private static long lastId = 0;

        public Hospital Hospital { get; protected set; }
        public void AddHospital(Hospital hospital)
        {
            if (hospital != null)
            {
                Hospital = hospital;

                if (!hospital.Patients.Contains(this)) hospital.AddPatient(this);
            }
        }
        public void RemoveHospital()
        {
            if (Hospital != null)
            {
                Hospital hospital = Hospital;
                Hospital = null;

                if (hospital.Patients.Contains(this)) hospital.RemovePatient(this);
            }
        }

        public List<MedicalFile> Files { get; private set; } = [];
        public void AddFile(MedicalFile file)
        {
            if (file != null)
            {
                Files.Add(file);

                if (!Equals(file.Patient)) file.AddPatient(this);
            }
        }
        public void RemoveFile(MedicalFile file)
        {
            if (file != null)
            {
                Files.Remove(file);

                if (Equals(file.Patient)) file.RemovePatient();
            }
        }


        public Patient(string lastName, string firstName, DateOnly birthdate, string phoneNumber, string email, string city)
            : base(lastName, firstName, birthdate, phoneNumber, email, city) { Id = ++lastId; }


        public override bool Equals(object obj)
        {
            return obj is Patient &&
                   base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode());
        }
    }
}
