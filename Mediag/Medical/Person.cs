using System;

namespace Mediag.Medical
{
    abstract class Person
    {
        private static long lastId = 0;

        public long Id { get; set; } = ++lastId;

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTime Birthdate { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }


        public Person() { }

        public Person(string lastName, string firstName, DateTime birthdate, string phoneNumber, string email, string address)
        {
            LastName = lastName;
            FirstName = firstName;
            Birthdate = birthdate;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
        }


        public override string ToString()
        {
            return $"{GetType().Name} {Id}: {FirstName} {LastName}";
        }
    }
}
