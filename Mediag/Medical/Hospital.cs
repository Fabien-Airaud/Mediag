using System.Collections.Generic;

namespace Mediag.Medical
{
    class Hospital
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public List<Doctor> Doctors { get; set; } = new List<Doctor>();

        public List<Patient> Patients { get; set; } = new List<Patient>();


        public Hospital() { }

        public Hospital(long id, string name, string city)
        {
            Id = id;
            Name = name;
            City = city;
        }


        public override string ToString()
        {
            return $"Hospital {Id}: \"{Name}\" in {City}";
        }
    }
}
