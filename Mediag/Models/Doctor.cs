
namespace Mediag.Models
{
    public class Doctor : User
    {
        private string _specialism = "";
        public string Specialism
        {
            get { return _specialism; }
            set
            {
                if (_specialism != value)
                {
                    _specialism = value;
                    OnPropertyChanged();
                    IsValidRegister = CheckIsValidRegister();
                }
            }
        }

        protected override bool CheckIsValidRegister()
        {
            return base.CheckIsValidRegister() && !string.IsNullOrWhiteSpace(Specialism);
        }

        public override void Reset()
        {
            base.Reset();
            Specialism = "";
        }

        public override void ResetToLogIn()
        {
            base.ResetToLogIn();
            Specialism = "";
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
            target.Username = Username;
            target.Password = Password;
            target.Specialism = Specialism;
        }

        public static Doctor? GetDoctor(string username, string? password = null)
        {
            MediagDbContext mediagDbContext = new();
            if (password is null)
                return mediagDbContext.Doctors.FirstOrDefault(doctor => doctor.Username.Equals(username));
            return mediagDbContext.Doctors.FirstOrDefault(doctor => doctor.Username.Equals(username) && doctor.Password.Equals(password));
        }

        public static Doctor AddDoctor(Doctor doctor)
        {
            MediagDbContext mediagDbContext = new();
            mediagDbContext.Doctors.Add(doctor);
            mediagDbContext.SaveChanges();
            return doctor;
        }

        public static Doctor UpdateDoctor(Doctor doctor)
        {
            MediagDbContext mediagDbContext = new();
            Doctor oldDoctor = mediagDbContext.Doctors.Find(doctor.Id)!; // Doctor is not null
            doctor.CopyTo(oldDoctor);
            mediagDbContext.SaveChanges();
            return doctor;
        }


        public override bool Equals(object? obj)
        {
            return obj is Doctor doctor &&
                   base.Equals(obj) &&
                   Specialism == doctor.Specialism;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Specialism);
        }
    }
}
