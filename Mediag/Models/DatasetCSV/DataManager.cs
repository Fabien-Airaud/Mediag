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
            if (!File.Exists(filename)) { return []; }

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
    }
}
