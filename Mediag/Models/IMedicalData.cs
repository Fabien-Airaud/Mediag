using System.ComponentModel;

namespace Mediag.Models
{
    public interface IMedicalData : INotifyPropertyChanged
    {
        public long Id { get; set; }

        public long? MedicalFileId { get; set; }
        public MedicalFile? MedicalFile { get; set; }

        public bool IsValid { get; }

        public string[] Labels();

        public string[] Values();
    }
}
