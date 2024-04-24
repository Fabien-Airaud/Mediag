using CsvHelper;
using CsvHelper.Configuration;
using System.Collections;
using System.Globalization;
using System.IO;

namespace Mediag.Models
{
    public class DataManager<T, K> where T : IMedicalData where K : ClassMap<T>
    {
        public static List<T> GetCSVData(string filename)
        {
            List<T> dataList = [];
            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<K>();
                IEnumerable records = csv.GetRecords<T>();

                foreach (T record in records) dataList.Add(record);
            }
            return dataList;
        }

        public static bool IsValidCSV(string filename)
        {
            if (!File.Exists(filename)) return false;

            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                csv.Context.RegisterClassMap<K>();

                csv.Read();
                try { T record = csv.GetRecord<T>(); } // Check if data in the CSV file is valid
                catch (CsvHelperException) { return false; }
            }
            return true;
        }
    }
}
