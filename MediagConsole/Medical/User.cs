using System;

namespace Mediag.Medical
{
    abstract class User : Person
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool Active { get; set; } = true;


        public User(string lastName, string firstName, DateOnly birthdate, string phoneNumber, string email, string city)
            : base(lastName, firstName, birthdate, phoneNumber, email, city)
        {
            Username = firstName + lastName;
            Password = lastName.ToUpper()[0] + firstName.ToLower()[0] + birthdate.ToString("yyyy-MM-dd");
        }

        public override string ToString()
        {
            return $"{GetType().Name} {Id}: {FirstName} {LastName} ({Username})";
        }

        public override bool Equals(object obj)
        {
            return obj is User &&
                   base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Username);
        }
    }
}
