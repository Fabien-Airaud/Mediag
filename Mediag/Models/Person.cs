using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Mediag.Models
{
    public abstract class Person : INotifyPropertyChanged
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
                    IsValidRegister = CheckIsValidRegister();
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
                    IsValidRegister = CheckIsValidRegister();
                }
            }
        }

        private DateTime _birthdate;
        [Column(TypeName = "date")]
        public DateTime Birthdate
        {
            get { return _birthdate; }
            set
            {
                if (_birthdate != value)
                {
                    _birthdate = value;
                    OnPropertyChanged();
                    IsValidRegister = CheckIsValidRegister();
                }
            }
        }

        private string _phoneNumber = "";
        [Phone]
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    OnPropertyChanged();
                    IsValidRegister = CheckIsValidRegister();
                }
            }
        }

        private string _email = "";
        [EmailAddress]
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
                    IsValidRegister = CheckIsValidRegister();
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
                    IsValidRegister = CheckIsValidRegister();
                }
            }
        }

        private bool _isValidRegister;
        [NotMapped]
        public bool IsValidRegister
        {
            get { return _isValidRegister; }
            protected set
            {
                if (_isValidRegister != value)
                {
                    _isValidRegister = value;
                    OnPropertyChanged();
                }
            }
        }
        protected virtual bool CheckIsValidRegister()
        {
            return !string.IsNullOrWhiteSpace(LastName) && !string.IsNullOrWhiteSpace(FirstName)
                && Birthdate != DateTime.MinValue && !string.IsNullOrWhiteSpace(PhoneNumber)
                && !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(City);
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void Reset()
        {
            LastName = "";
            FirstName = "";
            Birthdate = DateTime.MinValue;
            PhoneNumber = "";
            Email = "";
            City = "";
        }

        public override bool Equals(object? obj)
        {
            return obj is Person person &&
                   Id == person.Id &&
                   LastName == person.LastName &&
                   FirstName == person.FirstName &&
                   Birthdate == person.Birthdate &&
                   PhoneNumber == person.PhoneNumber &&
                   Email == person.Email &&
                   City == person.City;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, LastName, FirstName, Birthdate, PhoneNumber, Email, City);
        }
    }
}
