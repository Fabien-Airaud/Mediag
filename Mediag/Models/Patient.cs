namespace Mediag.Models
{
    public class Patient : Person
    {
        public long? HospitalId { get; set; }
        private Hospital? _hospital;
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
            return base.CheckIsValidRegister() && Hospital is not null;
        }

        public override void Reset()
        {
            base.Reset();
            Hospital = null;
        }

        public void CopyTo(Patient target)
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

        private static void CorrectInObjects(MediagDbContext mediagDbContext, Patient patient)
        {
            patient.Hospital = mediagDbContext.Hospitals.Find(patient.HospitalId);
        }

        public static ICollection<Patient> GetPatients()
        {
            MediagDbContext mediagDbContext = new();
            ICollection<Patient> patients = [.. mediagDbContext.Patients];
            foreach (Patient patient in patients) CorrectInObjects(mediagDbContext, patient);
            return patients;
        }

        public static Patient AddPatient(Patient patient)
        {
            MediagDbContext mediagDbContext = new();
            CorrectInObjects(mediagDbContext, patient);
            mediagDbContext.Patients.Add(patient);
            mediagDbContext.SaveChanges();
            return patient;
        }

        public static Patient UpdatePatient(Patient patient)
        {
            MediagDbContext mediagDbContext = new();
            Patient oldPatient = mediagDbContext.Patients.Find(patient.Id)!; // Patient is not null
            patient.CopyTo(oldPatient);
            CorrectInObjects(mediagDbContext, oldPatient);
            mediagDbContext.SaveChanges();
            return patient;
        }

        public static void DeletePatient(Patient patient)
        {
            MediagDbContext mediagDbContext = new();
            mediagDbContext.Patients.Remove(patient);
            mediagDbContext.SaveChanges();
        }

        public override bool Equals(object? obj)
        {
            return obj is Patient patient &&
                   base.Equals(obj) &&
                   HospitalId == patient.HospitalId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), HospitalId);
        }
    }
}
