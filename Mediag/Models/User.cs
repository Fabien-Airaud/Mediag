namespace Mediag.Models
{
    abstract class User : Person
    {
        private string _username = "";
        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged();
                    IsValidRegister = CheckIsValidRegister();
                }
            }
        }

        private string _password = "";
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                    IsValidRegister = CheckIsValidRegister();
                }
            }
        }

        protected override bool CheckIsValidRegister()
        {
            return base.CheckIsValidRegister() && !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }
    }
}
