using System;

namespace Mediag.Medical
{
    class Patient : Person
    {
        private static long lastId = 0;


        public Patient() : base() { Id = ++lastId; }

        public Patient(string lastName, string firstName, DateTime birthdate, string phoneNumber, string email, string address)
            : base(lastName, firstName, birthdate, phoneNumber, email, address) { Id = ++lastId; }
    }
}
