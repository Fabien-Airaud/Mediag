using System.Windows.Input;

namespace Mediag.ViewModels
{
    class SignLogInViewModel
    {
        public Models.Doctor Doctor { get; set; }

        public ICommand RegisterDoctorCommand { get; private set; }
        private void DisplayMessage()
        {
            System.Windows.MessageBox.Show($"{Doctor.LastName} {Doctor.FirstName} {Doctor.Birthdate.ToShortDateString()} {Doctor.City} {Doctor.Email} {Doctor.PhoneNumber} {Doctor.Username}");
        }

        public SignLogInViewModel()
        {
            Doctor = new Models.Doctor();
            RegisterDoctorCommand = new RelayCommand(o => true, o => DisplayMessage());
        }
    }
}
