using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Mediag.ViewModels
{
    public class ProfileVM : INotifyPropertyChanged
    {
        public Models.Doctor Doctor { get; set; }

        private string _editVisibility = "Hidden";
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

        private string _viewVisibility = "Visible";
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
        }

        public ICommand SaveCommand { get; private set; }
        private void SaveProfile()
        {
            ViewVisibility = "Visible";
        }

        public ICommand CancelCommand { get; private set; }
        private void CancelEdit()
        {
            ViewVisibility = "Visible";
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public ProfileVM(Models.Doctor doctor)
        {
            Doctor = doctor;
            EditCommand = new RelayCommand(_ => true, _ => ActiveEdit());
            SaveCommand = new RelayCommand(_ => true, _ => SaveProfile());
            CancelCommand = new RelayCommand(_ => true, _ => CancelEdit());
        }
    }
}
