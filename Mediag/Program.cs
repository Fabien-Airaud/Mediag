using Mediag.Database;
using Mediag.Hospital;
using System;
using System.Collections.Generic;

namespace Mediag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Diagnosis> data = CsvManager.GetDiagnoses("database/samples.csv");
            Console.WriteLine(data == null ? "File doesn't exist" : data.ToString());
        }
    }
}
