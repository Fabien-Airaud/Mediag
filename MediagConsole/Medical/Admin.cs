using System;

namespace Mediag.Medical
{
    class Admin : User
    {
        private static long lastId = 0;


        public Admin(string lastName, string firstName, DateOnly birthdate, string phoneNumber, string email, string city)
            : base(lastName, firstName, birthdate, phoneNumber, email, city) { Id = ++lastId; }


        public override bool Equals(object obj)
        {
            return obj is Admin &&
                   base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode());
        }
    }
}
