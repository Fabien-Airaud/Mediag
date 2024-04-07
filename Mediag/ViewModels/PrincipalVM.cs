using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace Mediag.ViewModels
{
    public class PrincipalVM(Models.Doctor doctor) : INotifyPropertyChanged
    {
        public Models.Doctor Doctor { get; set; } = doctor;

        private UserControl _principalContent = new Views.Principal.Home.HomeUC();
        public UserControl PrincipalContent
        {
            get { return _principalContent; }
            set
            {
                if (_principalContent != value)
                {
                    _principalContent = value;
                }
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
