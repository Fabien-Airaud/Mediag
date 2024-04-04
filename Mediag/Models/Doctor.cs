namespace Mediag.Models
{
    class Doctor(string lastName, string firstName, DateOnly birthdate, string phoneNumber, string email, string city,
        string username, string password)
        : User(lastName, firstName, birthdate, phoneNumber, email, city, username, password)
    {
        public long DoctorId { get; set; }
    }
}
