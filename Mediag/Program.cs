using Mediag.Database;
using Mediag.Hospital;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Mediag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Diagnosis> data = CsvManager.GetSamplesDiagnosis();
            Console.WriteLine(data == null ? "File doesn't exist" : data.ToString());

            foreach (object value in data[0].Values())
            {
                Console.WriteLine(value.GetType().Name + " = " + value.ToString());
            }

            //PropertyInfo[] propertyInfos = data[0].GetType().GetProperties();
            //foreach (PropertyInfo propertyInfo in propertyInfos)
            //{
            //    Console.WriteLine(propertyInfo.Name);
            //}
            //Console.WriteLine(propertyInfos[0].GetValue(data[0]));
            //Console.WriteLine(data[0].GetType().GetProperty("Id").GetValue(data[0]));
        }
    }
}
