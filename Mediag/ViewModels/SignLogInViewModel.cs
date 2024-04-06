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
        private void RegisterDoctor()
        {
            Models.Doctor.AddDoctor(Doctor);
            System.Windows.MessageBox.Show("Doctor registered successfully!, " + Doctor.Id);
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
                _ => RegisterDoctor());
        }
    }
}
