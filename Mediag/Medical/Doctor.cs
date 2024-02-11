using System;

namespace Mediag.Medical
{
    class Doctor : Person
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool Active { get; set; } = true;


        public Doctor() : base() { }

        public Doctor(long id, string lastName, string firstName, DateTime birthdate, string phoneNumber, string email, string address)
            : base(id, lastName, firstName, birthdate, phoneNumber, email, address)
        {
            Username = firstName + lastName;
            Password = lastName.ToUpper()[0] + firstName.ToLower()[0] + birthdate.ToString("yyyy-MM-dd");
        }
    }
}
