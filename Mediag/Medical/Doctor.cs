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

        public override void AddHospital(Hospital hospital)
        {
            if (hospital != null)
            {
                Hospital = hospital;

                if (!hospital.Doctors.Contains(this)) hospital.AddDoctor(this);
            }
        }
        public override void RemoveHospital()
        {
            if (Hospital != null)
            {
                Hospital hospital = Hospital;
                Hospital = null;

                if (hospital.Doctors.Contains(this)) hospital.RemoveDoctor(this);
            }
        }

        public List<MedicalFile> FilesToTreat { get; private set; } = new List<MedicalFile>();
        public void AddFileToTreat(MedicalFile file)
        {
            if (file != null)
            {
                FilesToTreat.Add(file);

                if (!Equals(file.DoctorsInCharge)) file.AddDoctorInCharge(this);
            }
        }
        public void RemoveFileToTreat(MedicalFile file)
        {
            if (file != null)
            {
                FilesToTreat.Remove(file);

                if (Equals(file.DoctorsInCharge)) file.RemoveDoctorInCharge(this);
            }
        }


        //public Doctor() : base() { Id = ++lastId; }

        public Doctor(string lastName, string firstName, DateTime birthdate, string phoneNumber, string email, string address)
            : base(lastName, firstName, birthdate, phoneNumber, email, address)
        {
            Id = ++lastId;
            Username = firstName + lastName;
            Password = lastName.ToUpper()[0] + firstName.ToLower()[0] + birthdate.ToString("yyyy-MM-dd");
        }
    }
}
