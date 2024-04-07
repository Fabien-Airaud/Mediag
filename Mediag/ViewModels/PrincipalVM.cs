using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mediag.ViewModels
{
    public class PrincipalVM : INotifyPropertyChanged
    {
        public Models.Doctor Doctor { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public PrincipalVM(Models.Doctor doctor)
        {
            Doctor = doctor;
        }
    }
}
