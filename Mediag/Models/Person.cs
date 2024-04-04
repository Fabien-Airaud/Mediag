using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mediag.Models
{
    abstract class Person : INotifyPropertyChanged
    {
        public long Id { get; set; }

        private string _lastName = "";
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _firstName = "";
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime _birthdate = DateTime.Today.AddYears(-20);
        public DateTime Birthdate
        {
            get { return _birthdate; }
            set
            {
                if (_birthdate != value)
                {
                    _birthdate = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _phoneNumber = "";
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _email = "";
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _city = "";
        public string City
        {
            get { return _city; }
            set
            {
                if (_city != value)
                {
                    _city = value;
                    OnPropertyChanged();
                }
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
