namespace Mediag.ViewModels
{
    class SignInViewModel
    {
        public Models.Doctor Doctor { get; set; }

        public SignInViewModel()
        {
            Doctor = new Models.Doctor();
        }
    }
}
