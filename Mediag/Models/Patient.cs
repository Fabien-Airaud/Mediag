using System.ComponentModel.DataAnnotations;

namespace Mediag.Models
{
    public class Patient : Person
    {
        public long HospitalId { get; set; }
        private Hospital? _hospital;
        [Required]
        public Hospital? Hospital
        {
            get { return _hospital; }
            set
            {
                if (_hospital != value)
                {
                    _hospital = value;
                    HospitalId = value?.Id ?? 0;
                    OnPropertyChanged();
                    IsValidRegister = CheckIsValidRegister();
                }
            }
        }

        protected override bool CheckIsValidRegister()
        {
            return base.CheckIsValidRegister() && Hospital is not null;
        }

        public override void Reset()
        {
            base.Reset();
            Hospital = null;
        }

        public void CopyTo(Doctor target)
        {
            target.Id = Id;
            target.LastName = LastName;
            target.FirstName = FirstName;
            target.Birthdate = Birthdate;
            target.PhoneNumber = PhoneNumber;
            target.Email = Email;
            target.City = City;
            target.Hospital = Hospital;
        }
    }
}
