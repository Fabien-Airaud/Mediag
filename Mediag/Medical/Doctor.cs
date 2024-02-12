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

        public List<MedicalFile> FilesToTreat { get; set; } = new List<MedicalFile>();


        public Doctor() : base() { Id = ++lastId; }

        public Doctor(string lastName, string firstName, DateTime birthdate, string phoneNumber, string email, string address)
            : base(lastName, firstName, birthdate, phoneNumber, email, address)
        {
            Id = ++lastId;
            Username = firstName + lastName;
            Password = lastName.ToUpper()[0] + firstName.ToLower()[0] + birthdate.ToString("yyyy-MM-dd");
        }
    }
}
