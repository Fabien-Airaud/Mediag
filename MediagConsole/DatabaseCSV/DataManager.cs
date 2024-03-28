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

        public string TrainFilename { get; set; } = "train.csv";

        public string TestFilename { get; set; } = "test.csv";

        public string SamplesFilename { get; set; } = "samples.csv";


        public DataManager(string databaseFolder)
        {
            DatabaseFolder = databaseFolder;
        }


        private List<IMedicalData> GetData(string filename)
        {
            if (!File.Exists(filename)) { return null; }

            List<IMedicalData> dataList = null;
            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<K>();
                var records = csv.GetRecords<T>();

                dataList = [];
                foreach (T record in records) dataList.Add(record);
            }
            return dataList;
        }

        public List<IMedicalData> GetTrainData()
        {
            string filename = Path.Combine(DatabaseFolder, TrainFilename);
            return GetData(filename);
        }

        public List<IMedicalData> GetTestData()
        {
            string filename = Path.Combine(DatabaseFolder, TestFilename);
            return GetData(filename);
        }

        public List<IMedicalData> GetSamplesData()
        {
            string filename = Path.Combine(DatabaseFolder, SamplesFilename);
            return GetData(filename);
        }
    }
}
