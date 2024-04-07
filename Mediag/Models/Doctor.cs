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

        public static Doctor AddDoctor(Doctor doctor)
        {
            MediagDbContext mediagDbContext = new();
            mediagDbContext.Doctors.Add(doctor);
            mediagDbContext.SaveChanges();
            return doctor;
        }

        public static Doctor? GetDoctor(string username, string password)
        {
            MediagDbContext mediagDbContext = new();
            return mediagDbContext.Doctors.FirstOrDefault(doctor => doctor.Username.Equals(username) && doctor.Password.Equals(password));
        }
    }
}
