namespace Mediag.ViewModels
{
    public class PrincipalVM
    {
        public Models.Doctor Doctor { get; set; }


        public PrincipalVM(Models.Doctor doctor)
        {
            Doctor = doctor;
        }
    }
}
