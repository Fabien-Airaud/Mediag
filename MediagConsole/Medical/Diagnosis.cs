using System;

namespace Mediag.Medical
{
    class Diagnosis
    {
        private static long lastId = 0;

        public long Id { get; protected set; } = ++lastId;

        public IllnessTypes Illness { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public bool Result { get; set; }

        public MedicalFile File { get; private set; }
        public void AddFile(MedicalFile file)
        {
            if (file != null)
            {
                File = file;

                if (!Equals(file.Diagnosis)) file.AddDiagnosis(this);
            }
        }
        public void RemoveFile()
        {
            if (File != null)
            {
                MedicalFile file = File;
                File = null;

                if (Equals(file.Diagnosis)) file.RemoveDiagnosis();
            }
        }


        public Diagnosis(MedicalFile file, IllnessTypes illness, bool result)
        {
            AddFile(file);
            Illness = illness;
            Result = result;
        }

        public Diagnosis(MedicalFile file, IllnessTypes illness, bool result, DateTime date)
        {
            AddFile(file);
            Illness = illness;
            Result = result;
            Date = date;
        }


        public override string ToString()
        {
            return $"{File.Patient.FirstName} {File.Patient.LastName}'s diagnosis for {Illness}: {Result} on {Date}";
        }
    }
}
