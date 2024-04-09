using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mediag.ViewModels
{
    public class MedicalFileVM : INotifyPropertyChanged
    {
        public Models.MedicalFile MedicalFile { get; set; }
        public Models.MedicalFile OldMedicalFile { get; set; }

        public ObservableCollection<Models.Patient> Patients { get; set; }

        public ObservableCollection<Models.Doctor> Doctors { get; set; }

        public ObservableCollection<Models.Hospital> Hospitals { get; set; }

        public Action ClosePatient { get; set; } = () => { };

        private string _editVisibility;
        public string EditVisibility
        {
            get { return _editVisibility; }
            set
            {
                if (_editVisibility != value)
                {
                    _editVisibility = value;
                    OnPropertyChanged();
                    ViewVisibility = value == "Visible" ? "Hidden" : "Visible";
                }
            }
        }

        private string _viewVisibility;
        public string ViewVisibility
        {
            get { return _viewVisibility; }
            set
            {
                if (_viewVisibility != value)
                {
                    _viewVisibility = value;
                    OnPropertyChanged();
                    EditVisibility = value == "Visible" ? "Hidden" : "Visible";
                }
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public MedicalFileVM(Models.MedicalFile? medicalFile = null, bool isEditMode = true)
        {
            MedicalFile = new Models.MedicalFile();
            medicalFile?.CopyTo(MedicalFile);
            OldMedicalFile = new Models.MedicalFile();
            MedicalFile.CopyTo(OldMedicalFile);

            Patients = new ObservableCollection<Models.Patient>(Models.Patient.GetPatients());
            Doctors = new ObservableCollection<Models.Doctor>(Models.Doctor.GetDoctors());
            Hospitals = new ObservableCollection<Models.Hospital>(Models.Hospital.GetHospitals());

            if (MedicalFile.IsValid)
            {
                MedicalFile.Patient = Patients.First(p => p.Id == MedicalFile.PatientId);
                MedicalFile.Doctor = Doctors.First(d => d.Id == MedicalFile.DoctorId);
                MedicalFile.Hospital = Hospitals.First(h => h.Id == MedicalFile.HospitalId);
            }

            _editVisibility = isEditMode || medicalFile is null ? "Visible" : "Hidden"; // Edit mode is default when medical file is null
            _viewVisibility = isEditMode || medicalFile is null ? "Hidden" : "Visible"; // View mode is default when medical file is not null
        }
    }
}
