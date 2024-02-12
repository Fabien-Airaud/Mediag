using System;
using System.Collections.Generic;

namespace Mediag.Medical
{
    class Patient : Person
    {
        private static long lastId = 0;

        public List<MedicalFile> Files { get; private set; }
        public void AddFile(MedicalFile file)
        {
            Files.Add(file);
        }
        public void RemoveFile(MedicalFile file)
        {
            Files.Remove(file);
        }


        //public Patient() : base() { Id = ++lastId; }

        public Patient(string lastName, string firstName, DateTime birthdate, string phoneNumber, string email, string address)
            : base(lastName, firstName, birthdate, phoneNumber, email, address) { Id = ++lastId; }
    }
}
