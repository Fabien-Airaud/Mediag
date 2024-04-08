using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Mediag.ViewModels
{
    public class PatientVM : INotifyPropertyChanged
    {
        public Models.Patient Patient { get; set; }
        public Models.Patient OldPatient { get; set; }

        public ObservableCollection<Models.Hospital> Hospitals { get; set; }

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

        public ICommand EditCommand { get; private set; }
        private void ActiveEdit()
        {
            EditVisibility = "Visible";
            if (!Patient.Equals(OldPatient)) Patient.CopyTo(OldPatient);
            Patient.Hospital = Hospitals.First(h => h.Id == Patient.HospitalId);
        }

        public ICommand SaveCommand { get; private set; }
        private void SaveProfile()
        {
            //ViewVisibility = "Visible";
            //if (Patient.Equals(OldPatient)) return; // No changes

            //Patient = Models.Patient.UpdatePatient(Patient);
            //MessageBox.Show("Profile saved.");
        }

        public ICommand CancelCommand { get; private set; }
        private void CancelEdit()
        {
            //ViewVisibility = "Visible";
            //if (!OldPatient.Equals(Patient)) OldPatient.CopyTo(Patient);
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public PatientVM(Models.Patient? patient = null, bool isEditMode = true)
        {
            Patient = new Models.Patient();
            patient?.CopyTo(Patient);
            OldPatient = new Models.Patient();
            Hospitals = new ObservableCollection<Models.Hospital>(Models.Hospital.GetHospitals());
            _editVisibility = isEditMode || patient is null ? "Visible" : "Hidden"; // Edit mode is default when patient is null
            _viewVisibility = isEditMode || patient is null ? "Hidden" : "Visible"; // View mode is default when patient is not null
            EditCommand = new RelayCommand(_ => true, _ => ActiveEdit());
            SaveCommand = new RelayCommand(_ => Patient.IsValidRegister, _ => SaveProfile());
            CancelCommand = new RelayCommand(_ => true, _ => CancelEdit());
        }
    }
}
