using System;

namespace Mediag.Medical
{
    abstract class Person
    {
        public long Id { get; protected set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateOnly Birthdate { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }


        public Person(string lastName, string firstName, DateOnly birthdate, string phoneNumber, string email, string address)
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

        public override bool Equals(object obj)
        {
            return obj is Person person &&
                   Id == person.Id &&
                   LastName == person.LastName &&
                   FirstName == person.FirstName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, LastName, FirstName);
        }
    }
}
