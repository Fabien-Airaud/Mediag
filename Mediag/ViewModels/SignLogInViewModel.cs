using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Mediag.ViewModels
{
    class SignLogInViewModel : INotifyPropertyChanged
    {
        public Models.Doctor Doctor { get; set; }

        private string _registerConfirmPassword = "";
        public string RegisterConfirmPassword
        {
            get { return _registerConfirmPassword; }
            set
            {
                if (_registerConfirmPassword != value)
                {
                    _registerConfirmPassword = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand RegisterCommand { get; private set; }
        private void Register()
        {
            Models.Doctor.AddDoctor(Doctor);
            System.Windows.MessageBox.Show("Registered successfully!\nYou can now log in.", "Register");
        }

        public ICommand LogInCommand { get; private set; }
        private void LogIn()
        {
            Models.Doctor? doctor = Models.Doctor.GetDoctor(Doctor.Username, Doctor.Password);
            if (doctor is null)
            {
                System.Windows.MessageBox.Show("Invalid username or password!", "Log in");
                return;
            }
            System.Windows.MessageBox.Show("Logged in successfully!", "Log in");
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public SignLogInViewModel()
        {
            Doctor = new Models.Doctor();
            RegisterCommand = new RelayCommand(_ => Doctor.IsValidRegister && Doctor.Password.Equals(RegisterConfirmPassword), _ => Register());
            LogInCommand = new RelayCommand(_ => Doctor.IsValidLogIn, _ => LogIn());
        }
    }
}
