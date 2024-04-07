using System.Windows;
using System.Windows.Input;

namespace Mediag.ViewModels
{
    public class SignLogInVM
    {
        //private readonly Views.LogIn.SignLogIn _logInView;

        public Models.Doctor Doctor { get; set; }

        public ICommand RegisterCommand { get; private set; }
        private void Register()
        {
            if (Models.Doctor.GetDoctor(Doctor.Username) is not null)
            {
                MessageBox.Show("Register failed, Username already exists!", "Register");
                return;
            }

            Models.Doctor.AddDoctor(Doctor);
            MessageBox.Show("Registered successfully!\nYou can now log in.", "Register");
            //_logInView.LogInTabs.SelectedItem = _logInView.LogInTab;
            Doctor.ResetToLogIn();
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
            Views.Principal.Principal principalWindow = new(doctor);
            principalWindow.Show();
            //_logInView.Close();
        }


        //public event PropertyChangedEventHandler? PropertyChanged;

        //protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}


        public SignLogInVM()
        {
            Doctor = new Models.Doctor();
            RegisterCommand = new RelayCommand(_ => Doctor.IsValidRegister, _ => Register());
            LogInCommand = new RelayCommand(_ => Doctor.IsValidLogIn, _ => LogIn());
        }

        //public SignLogInViewModel(Views.LogIn.SignLogIn logInView)
        //{
        //    Doctor = new Models.Doctor();
        //    RegisterCommand = new RelayCommand(_ => Doctor.IsValidRegister, _ => Register());
        //    LogInCommand = new RelayCommand(_ => Doctor.IsValidLogIn, _ => LogIn());
        //    _logInView = logInView;
        //}
    }
}
