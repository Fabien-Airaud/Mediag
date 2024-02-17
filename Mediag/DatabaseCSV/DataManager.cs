using CsvHelper;
using CsvHelper.Configuration;
using Mediag.Medical;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Mediag.DatabaseCSV
{
    class DataManager<T, K> where T : IMedicalData where K : ClassMap<T>
    {
        public string DatabaseFolder { get; set; }

        public string SamplesFilename { get; set; } = "samples.csv";


        public DataManager(string databaseFolder)
        {
            DatabaseFolder = databaseFolder;
        }


        public List<T> GetSamplesData()
        {
            string filename = Path.Combine(DatabaseFolder, SamplesFilename);
            if (!File.Exists(filename)) { return null; }

            List<T> dataList = null;
            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<K>();
                var records = csv.GetRecords<T>();
                dataList = new List<T>(records);
            }
            return dataList;
        }
    }
}
