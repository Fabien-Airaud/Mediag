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

        public ICommand RegisterDoctorCommand { get; private set; }
        private void DisplayMessage()
        {
            System.Windows.MessageBox.Show($"{Doctor.LastName} {Doctor.FirstName} {Doctor.Birthdate.ToShortDateString()} {Doctor.City} {Doctor.Email} {Doctor.PhoneNumber} {Doctor.Username} {Doctor.Password}|{RegisterConfirmPassword}");
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public SignLogInViewModel()
        {
            Doctor = new Models.Doctor();
            RegisterDoctorCommand = new RelayCommand(_ => Doctor.IsValidRegister && Doctor.Password.Equals(RegisterConfirmPassword),
                _ => DisplayMessage());
        }
    }
}
