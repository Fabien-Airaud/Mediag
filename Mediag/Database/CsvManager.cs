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
        public static List<Diagnosis> GetDiagnoses(string filename)
        {
            if (!File.Exists(filename)) { return null; }
            List<Diagnosis> diagnosisList = new List<Diagnosis>();

            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<DiagnosisMap>();
                var records = csv.GetRecords<Diagnosis>().GetEnumerator();
                
                int i = 1;
                while (records.MoveNext())
                {
                    records.Current.Id = i++;
                    diagnosisList.Add(records.Current);
                }
            }

            foreach (var diagnosis in diagnosisList)
            {
                Console.WriteLine(diagnosis);
            }
            return diagnosisList;
        }
    }
}
