using System.ComponentModel.DataAnnotations.Schema;

namespace Mediag.Models
{
    public abstract class User : Person
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
                    IsValidLogIn = CheckIsValidLogIn();
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
                    IsValidLogIn = CheckIsValidLogIn();
                    IsValidRegister = CheckIsValidRegister();
                }
            }
        }

        private string _confirmPassword = "";
        [NotMapped]
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                if (_confirmPassword != value)
                {
                    _confirmPassword = value;
                    OnPropertyChanged();
                    IsValidRegister = CheckIsValidRegister();
                }
            }
        }

        private bool _isValidLogIn;
        [NotMapped]
        public bool IsValidLogIn
        {
            get { return _isValidLogIn; }
            protected set
            {
                if (_isValidLogIn != value)
                {
                    _isValidLogIn = value;
                    OnPropertyChanged();
                }
            }
        }
        protected virtual bool CheckIsValidLogIn()
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        protected override bool CheckIsValidRegister()
        {
            return base.CheckIsValidRegister() && IsValidLogIn && Password.Equals(ConfirmPassword);
        }

        public override void Reset()
        {
            base.Reset();
            Username = "";
            Password = "";
            ConfirmPassword = "";
        }

        public virtual void ResetToLogIn()
        {
            base.Reset();
            ConfirmPassword = "";
        }
    }
}
