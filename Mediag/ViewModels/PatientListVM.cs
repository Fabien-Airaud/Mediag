using System.Collections.ObjectModel;

namespace Mediag.ViewModels
{
    public class PatientListVM
    {
        public ObservableCollection<Models.Patient> Patients { get; set; }


        public PatientListVM()
        {
            Patients = [];
        }
    }
}
