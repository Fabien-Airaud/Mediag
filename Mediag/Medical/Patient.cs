using System;

namespace Mediag.Medical
{
    class Patient : Person
    {
        public Patient() : base() { }

        public Patient(long id, string lastName, string firstName, DateTime birthdate, string phoneNumber, string email, string address)
            : base(id, lastName, firstName, birthdate, phoneNumber, email, address) { }
    }
}
