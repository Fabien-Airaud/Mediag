namespace Mediag.Models
{
    class Doctor : User
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

        public static Doctor AddDoctor(Doctor doctor)
        {
            MediagDbContext mediagDbContext = new();
            mediagDbContext.Doctors.Add(doctor);
            mediagDbContext.SaveChanges();
            return doctor;
        }
    }
}
