namespace Mediag.ViewModels
{
    public class ProfileVM
    {
        public Models.Doctor Doctor { get; set; }


        public ProfileVM(Models.Doctor doctor)
        {
            Doctor = doctor;
        }
    }
}
