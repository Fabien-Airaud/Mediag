using CsvHelper;
using Mediag.Hospital;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Mediag.Database
{
    class CsvManager
    {
        private static readonly string SamplesFilename = "database/samples.csv";


        public static List<Diagnosis> GetTrainDiagnosis()
        {
            // Change to get train set
            return GetSamplesDiagnosis();
        }

        public static List<Diagnosis> GetTestDiagnosis()
        {
            // Change to get test set
            return GetSamplesDiagnosis();
        }

        public static List<Diagnosis> GetSamplesDiagnosis()
        {
            if (!File.Exists(SamplesFilename)) { return null; }
            List<Diagnosis> diagnosisList = new List<Diagnosis>();

            using (var reader = new StreamReader(SamplesFilename))
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
