using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mediag.Models
{
    abstract class Person(string lastName, string firstName, DateOnly birthdate, string phoneNumber, string email, string city)
        : INotifyPropertyChanged
    {
        public long Id { get; set; }

        public string LastName { get; set; } = lastName;

        public string FirstName { get; set; } = firstName;

        public DateOnly Birthdate { get; set; } = birthdate;

        public string PhoneNumber { get; set; } = phoneNumber;

        public string Email { get; set; } = email;

        public string City { get; set; } = city;


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
