using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Mediag.Medical
{
    class MedicalFile
    {
        private static long lastId = 0;

        public long Id { get; set; } = ++lastId;

        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime LastUpdate { get; set; }

        public DateTime EndDate { get; set; }

        /// <summary>
        /// Must be initialized
        /// </summary>
        public Patient Patient { get; set; }

        /// <summary>
        /// Must be initialized
        /// </summary>
        public Hospital Hospital { get; set; }

        public List<Doctor> DoctorsInCharge { get; set; } = new List<Doctor>();


        public MedicalFile() { }

        public MedicalFile(Patient patient, Hospital hospital)
        {
            Patient = patient;
            Hospital = hospital;
        }

        public MedicalFile(DateTime startDate, Patient patient, Hospital hospital)
        {
            StartDate = startDate;
            Patient = patient;
            Hospital = hospital;
        }


        public override string ToString()
        {
            return $"Medical file {Id}: {Patient.FirstName} {Patient.LastName}";
        }
    }
}
