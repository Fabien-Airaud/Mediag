using System;
using System.Collections.Generic;

namespace Mediag.Medical
{
    class Doctor : Person
    {
        private static long lastId = 0;

        public string Username { get; set; }

        public string Password { get; set; }

        public bool Active { get; set; } = true;

        public Hospital Hospital { get; protected set; }
        public void AddHospital(Hospital hospital)
        {
            if (hospital != null)
            {
                Hospital = hospital;

                if (!hospital.Doctors.Contains(this)) hospital.AddDoctor(this);
            }
        }
        public void RemoveHospital()
        {
            if (Hospital != null)
            {
                Hospital hospital = Hospital;
                Hospital = null;

                if (hospital.Doctors.Contains(this)) hospital.RemoveDoctor(this);
            }
        }

        public List<MedicalFile> FilesToTreat { get; private set; } = [];
        public void AddFileToTreat(MedicalFile file)
        {
            if (file != null)
            {
                FilesToTreat.Add(file);

                if (!file.DoctorsInCharge.Contains(this)) file.AddDoctorInCharge(this);
            }
        }
        public void RemoveFileToTreat(MedicalFile file)
        {
            if (file != null)
            {
                FilesToTreat.Remove(file);

                if (file.DoctorsInCharge.Contains(this)) file.RemoveDoctorInCharge(this);
            }
        }


        public Doctor(string lastName, string firstName, DateOnly birthdate, string phoneNumber, string email, string address)
            : base(lastName, firstName, birthdate, phoneNumber, email, address)
        {
            Id = ++lastId;
            Username = firstName + lastName;
            Password = lastName.ToUpper()[0] + firstName.ToLower()[0] + birthdate.ToString("yyyy-MM-dd");
        }


        public Diagnosis Diagnose(MedicalFile file)
        {
            return Hospital.Diagnose(file); 
        }

        public List<MedicalFile> FilesToDiagnose()
        {
            List<MedicalFile> files = [];
            foreach (MedicalFile file in FilesToTreat)
            {
                if (file.EndDate == null && file.Diagnosis == null) files.Add(file);
            }
            return files;
        }

        public List<Diagnosis> DiagnoseAllFiles()
        {
            List<Diagnosis> diagnosisList = [];
            foreach (MedicalFile file in FilesToDiagnose())
            {
                diagnosisList.Add(Diagnose(file));
            }
            return diagnosisList;
        }

        public List<Diagnosis> DiagnoseAllFiles(List<MedicalFile> filesToDiagnose)
        {
            List<Diagnosis> diagnosisList = [];
            foreach (MedicalFile file in filesToDiagnose)
            {
                diagnosisList.Add(Diagnose(file));
            }
            return diagnosisList;
        }

        public override bool Equals(object obj)
        {
            return obj is Doctor &&
                   base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode());
        }
    }
}
