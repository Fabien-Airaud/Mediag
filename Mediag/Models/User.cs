namespace Mediag.Models
{
    abstract class User(string lastName, string firstName, DateOnly birthdate, string phoneNumber, string email, string city,
        string username, string password)
        : Person(lastName, firstName, birthdate, phoneNumber, email, city)
    {
        public string Username { get; set; } = username;

        public string Password { get; set; } = password;
    }
}
