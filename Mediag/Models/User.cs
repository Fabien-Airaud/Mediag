namespace Mediag.Models
{
    abstract class User(string lastName, string firstName, DateOnly birthdate, string phoneNumber, string email, string city,
        string username, string password)
        : Person(lastName, firstName, birthdate, phoneNumber, email, city)
    {
        private string _username = username;
        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _password = password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
