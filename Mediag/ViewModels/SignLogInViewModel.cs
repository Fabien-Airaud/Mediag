using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Mediag.ViewModels
{
    class SignLogInViewModel : INotifyPropertyChanged
    {
        //private readonly Views.LogIn.SignLogIn _logInView;

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
            MessageBox.Show("Registered successfully!\nYou can now log in.", "Register");
            //_logInView.LogInTabs.SelectedItem = _logInView.LogInTab;
        }

        public ICommand LogInCommand { get; private set; }
        private void LogIn()
        {
            Models.Doctor? doctor = Models.Doctor.GetDoctor(Doctor.Username, Doctor.Password);
            if (doctor is null)
            {
                MessageBox.Show("Invalid username or password!", "Log in");
                return;
            }
            MessageBox.Show("Logged in successfully!", "Log in");
            Views.Principal.Principal principalWindow = new();
            principalWindow.Show();
            //_logInView.Close();
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

        //public SignLogInViewModel(Views.LogIn.SignLogIn logInView)
        //{
        //    Doctor = new Models.Doctor();
        //    RegisterCommand = new RelayCommand(_ => Doctor.IsValidRegister && Doctor.Password.Equals(RegisterConfirmPassword), _ => Register());
        //    LogInCommand = new RelayCommand(_ => Doctor.IsValidLogIn, _ => LogIn());
        //    _logInView = logInView;
        //}
    }
}
