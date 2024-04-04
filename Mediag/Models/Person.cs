namespace Mediag.Medical
{
    abstract class Person(string lastName, string firstName, DateOnly birthdate, string phoneNumber, string email, string city)
    {
        public string LastName { get; set; } = lastName;

        public string FirstName { get; set; } = firstName;

        public DateOnly Birthdate { get; set; } = birthdate;

        public string PhoneNumber { get; set; } = phoneNumber;

        public string Email { get; set; } = email;

        public string City { get; set; } = city;
    }
}
