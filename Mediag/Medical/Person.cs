using System;

namespace Mediag.Medical
{
    abstract class Person
    {
        public long Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTime Birthdate { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }


        public override string ToString()
        {
            return GetType().Name + " " + FirstName + " " + LastName;
        }
    }
}
