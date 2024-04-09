using System.ComponentModel.DataAnnotations;

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
                }
            }
        }

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
                }
            }
        }

        public ICollection<MedicalFile> MedicalFiles { get; set; } = [];

        protected override bool CheckIsValidRegister()
        {
            return base.CheckIsValidRegister() && !string.IsNullOrWhiteSpace(Specialism) && Hospital is not null;
        }

        public override void Reset()
        {
            base.Reset();
            Specialism = "";
            Hospital = null;
        }

        public override void ResetToLogIn()
        {
            base.ResetToLogIn();
            Specialism = "";
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
            target.Username = Username;
            target.Password = Password;
            target.ConfirmPassword = Password;
            target.Specialism = Specialism;
            target.Hospital = Hospital;
        }

        public static Doctor? GetDoctor(string username, string? password = null)
        {
            MediagDbContext mediagDbContext = new();
            if (password is null)
                return mediagDbContext.Doctors.FirstOrDefault(doctor => doctor.Username.Equals(username));
            
            Doctor? doctor = mediagDbContext.Doctors.FirstOrDefault(doctor => doctor.Username.Equals(username) && doctor.Password.Equals(password));
            if (doctor is not null) doctor.Hospital = mediagDbContext.Hospitals.Find(doctor.HospitalId);
            return doctor;
        }

        public static Doctor AddDoctor(Doctor doctor)
        {
            MediagDbContext mediagDbContext = new();
            doctor.Hospital = mediagDbContext.Hospitals.Find(doctor.HospitalId);
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


        public override string? ToString()
        {
            return "Dr. " + base.ToString();
        }

        public override bool Equals(object? obj)
        {
            return obj is Doctor doctor &&
                   base.Equals(obj) &&
                   Specialism == doctor.Specialism &&
                   HospitalId == doctor.HospitalId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Specialism, HospitalId);
        }
    }
}
