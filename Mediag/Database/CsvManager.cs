using CsvHelper;
using Mediag.Medical;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Mediag.Database
{
    class CsvManager
    {
        private const string DefaultDatabase = "database";

        private const string SamplesFilename = "samples.csv";


        public static List<Diagnosis> GetTrainDiagnosis() { return GetTrainDiagnosis(DefaultDatabase); }
        public static List<Diagnosis> GetTrainDiagnosis(string databaseFolder)
        {
            // Change to get train set
            return GetSamplesDiagnosis(databaseFolder);
        }

        public static List<Diagnosis> GetTestDiagnosis() { return GetTestDiagnosis(DefaultDatabase); }
        public static List<Diagnosis> GetTestDiagnosis(string databaseFolder)
        {
            // Change to get test set
            return GetSamplesDiagnosis(databaseFolder);
        }

        public static List<Diagnosis> GetSamplesDiagnosis() { return GetSamplesDiagnosis(DefaultDatabase); }
        public static List<Diagnosis> GetSamplesDiagnosis(string databaseFolder)
        {
            string filename = Path.Combine(databaseFolder, SamplesFilename);
            if (!File.Exists(filename)) { return null; }

            List<Diagnosis> diagnosisList = new List<Diagnosis>();

            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<DiagnosisMap>();
                var records = csv.GetRecords<Diagnosis>().GetEnumerator();
                
                // Get all diagnosis from the csv file
                int i = 1;
                while (records.MoveNext())
                {
                    records.Current.Id = i++;
                    diagnosisList.Add(records.Current);
                }
            }
            return diagnosisList;
        }
    }
}
