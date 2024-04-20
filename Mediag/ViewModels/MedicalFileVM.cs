using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Mediag.ViewModels
{
    public class MedicalFileVM : INotifyPropertyChanged
    {
        public Models.MedicalFile MedicalFile { get; set; }
        public Models.MedicalFile OldMedicalFile { get; set; }

        public ObservableCollection<Models.Patient> Patients { get; set; }

        public ObservableCollection<Models.Doctor> Doctors { get; set; }

        public ObservableCollection<Models.Hospital> Hospitals { get; set; }

        public ObservableCollection<Models.IllnessTypes> IllnessTypes { get; set; }

        private UserControl _medicalDataContent;
        public UserControl MedicalDataContent
        {
            get { return _medicalDataContent; }
            set
            {
                if (_medicalDataContent != value)
                {
                    _medicalDataContent = value;
                    OnPropertyChanged();
                }
            }
        }

        public Action CloseMedicalFile { get; set; } = () => { };

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
            if (!MedicalFile.Equals(OldMedicalFile)) MedicalFile.CopyTo(OldMedicalFile);
        }

        public ICommand SaveCommand { get; private set; }
        private void SaveMedicalFile()
        {
            ViewVisibility = "Visible";
            if (MedicalFile.Equals(OldMedicalFile))
            {
                if (MedicalFile.MedicalData is not null
                    && MedicalFile.MedicalData.Equals(OldMedicalFile.MedicalData)) return; // No changes to save
            }

            if (!OldMedicalFile.IsValid) MedicalFile = Models.MedicalFile.AddMedicalFile(MedicalFile);
            else MedicalFile = Models.MedicalFile.UpdateMedicalFile(MedicalFile);
            MessageBox.Show("Medical file saved.");
        }

        public ICommand CancelCommand { get; private set; }
        private void CancelEdit()
        {
            if (!OldMedicalFile.IsValid) CloseMedicalFile(); // Close window if was in create mode

            ViewVisibility = "Visible";
            if (!OldMedicalFile.Equals(MedicalFile))
            {
                if (MedicalFile.MedicalData is not null
                    && !MedicalFile.MedicalData.Equals(OldMedicalFile.MedicalData)) OldMedicalFile.CopyTo(MedicalFile);
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
            MedicalFile.PropertyChanged += (_, e) => ChangeMedicalDataContent(e);
            _medicalDataContent = EmptyUserControl();

            Patients = new ObservableCollection<Models.Patient>(Models.Patient.GetPatients());
            Doctors = new ObservableCollection<Models.Doctor>(Models.Doctor.GetDoctors());
            Hospitals = new ObservableCollection<Models.Hospital>(Models.Hospital.GetHospitals());
            IllnessTypes = new ObservableCollection<Models.IllnessTypes>(Models.IllnessTypes.GetIllnessTypes());

            if (MedicalFile.IsValid)
            {
                MedicalFile.TargetIllness = IllnessTypes.First(it => it.Id == MedicalFile.TargetIllnessId);
                MedicalFile.Patient = Patients.First(p => p.Id == MedicalFile.PatientId);
                MedicalFile.Doctor = Doctors.First(d => d.Id == MedicalFile.DoctorId);
                MedicalFile.Hospital = Hospitals.First(h => h.Id == MedicalFile.HospitalId);
            }

            _editVisibility = isEditMode || medicalFile is null ? "Visible" : "Hidden"; // Edit mode is default when medical file is null
            _viewVisibility = isEditMode || medicalFile is null ? "Hidden" : "Visible"; // View mode is default when medical file is not null

            EditCommand = new RelayCommand(_ => true, _ => ActiveEdit());
            SaveCommand = new RelayCommand(
                _ => MedicalFile.IsValid && (MedicalFile.MedicalData is not null && MedicalFile.MedicalData.IsValid),
                _ => SaveMedicalFile());
            CancelCommand = new RelayCommand(_ => true, _ => CancelEdit());
        }

        public void ChangeMedicalDataContent(PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MedicalFile.TargetIllness))
            {
                MedicalDataContent = MedicalFile.TargetIllness?.Name switch
                {
                    "Breast cancer" => new Views.Principal.MedicalFiles.BreastCancerDataUC(),
                    //"Heart disease" => new Views.Principal.MedicalFiles.HeartDiseaseDataUC(),
                    _ => EmptyUserControl()
                };
                ChangeMedicalData();
            }
        }

        private static UserControl EmptyUserControl()
        {
            return new UserControl
            {
                Content = new Label
                {
                    Content = "No data available for this illness type."
                },
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
        }

        public void ChangeMedicalData()
        {
            if (MedicalFile.TargetIllnessId == OldMedicalFile.TargetIllnessId && OldMedicalFile.MedicalData is not null)
            {
                MedicalFile.MedicalData = OldMedicalFile.MedicalData;
                OldMedicalFile.MedicalData.CopyTo(MedicalFile.MedicalData); // Force setters to be called
                return;
            }

            switch (MedicalFile.TargetIllness?.Name)
            {
                case "Breast cancer":
                    if (MedicalFile.MedicalData is not Models.BreastCancerData)
                    {
                        MedicalFile.MedicalData = new Models.BreastCancerData()
                        {
                            MedicalFileId = MedicalFile.Id,
                            MedicalFile = MedicalFile
                        };
                    }
                    break;
                //case "Heart disease":
                //MedicalFile.MedicalData = new Models.HeartDiseaseData()
                //{
                //    MedicalFileId = MedicalFile.Id,
                //    MedicalFile = MedicalFile
                //};
                //break;
                default:
                    MedicalFile.MedicalData = null;
                    break;
            }

            /*Models.IMedicalData? medicalData = MedicalFile.TargetIllness?.Name switch
            {
                "Breast cancer" => new Models.BreastCancerData()
                {
                    MedicalFileId = MedicalFile.Id,
                    MedicalFile = MedicalFile
                },
                //"Heart disease" => new Models.HeartDiseaseData()
                //{
                //    MedicalFileId = MedicalFile.Id,
                //    MedicalFile = MedicalFile
                //},
                _ => null
            };
            MedicalFile.MedicalData = medicalData;
            //if (MedicalFile.MedicalData is not null) medicalData!.CopyTo(MedicalFile.MedicalData);*/
        }
    }
}
