using System.Collections.ObjectModel;

namespace Mediag.ViewModels
{
    public class PatientListVM
    {
        public Models.Doctor Doctor { get; set; }

        public ObservableCollection<Models.Patient> Patients { get; set; }


        public PatientListVM(Models.Doctor doctor)
        {
            Doctor = doctor;
            Patients = [];
        }
    }
}
