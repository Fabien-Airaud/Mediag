﻿using DiagnosticDecision;
using System.Collections.Generic;

namespace Mediag.Medical
{
    class Hospital
    {
        private static long lastId = 0;

        public long Id { get; protected set; } = ++lastId;

        public string Name { get; set; }

        public string City { get; set; }

        public List<Doctor> Doctors { get; private set; } = [];
        public void AddDoctor(Doctor doctor)
        {
            if (doctor != null)
            {
                Doctors.Add(doctor);

                if (!Equals(doctor.Hospital)) doctor.AddHospital(this);
            }
        }
        public void RemoveDoctor(Doctor doctor)
        {
            if (doctor != null)
            {
                Doctors.Remove(doctor);

                if (Equals(doctor.Hospital)) doctor.RemoveHospital();
            }
            Doctors.Remove(doctor);
        }

        public List<Patient> Patients { get; private set; } = [];
        public void AddPatient(Patient patient)
        {
            if (patient != null)
            {
                Patients.Add(patient);

                if (!Equals(patient.Hospital)) patient.AddHospital(this);
            }
        }
        public void RemovePatient(Patient patient)
        {
            if (patient != null)
            {
                Patients.Remove(patient);

                if (Equals(patient.Hospital)) patient.RemoveHospital();
            }
        }

        public List<MedicalFile> Files { get; private set; } = [];
        public void AddFile(MedicalFile file)
        {
            if (file != null)
            {
                Files.Add(file);

                if (!Equals(file.Hospital)) file.AddHospital(this);
            }
        }
        public void RemoveFile(MedicalFile file)
        {
            if (file != null)
            {
                Files.Remove(file);

                if (Equals(file.Hospital)) file.RemoveHospital();
            }
        }

        public Dictionary<IllnessTypes, IDecisionTree> DecisionTrees { get; private set; } = [];
        public void AddDecisionTree(IllnessTypes illness, IDecisionTree tree)
        {
            if (tree != null && !DecisionTrees.ContainsKey(illness))
            {
                DecisionTrees.Add(illness, tree);
            }
        }
        public void RemoveDecisionTree(IllnessTypes illness)
        {
            DecisionTrees.Remove(illness);
        }


        public Hospital(string name, string city)
        {
            Name = name;
            City = city;
        }


        public Diagnosis Diagnose(MedicalFile file)
        {
            if (file != null && file.MedicalData != null)
            {
                IMedicalData data = file.MedicalData;
                if (DecisionTrees.ContainsKey(data.TargettedIllness()))
                {
                    string result = DecisionTrees[data.TargettedIllness()].Classify(data.Values()); // Get the result of the decision tree
                    if (result != null && result != "")
                    {
                        return new Diagnosis(file, data.TargettedIllness(), bool.Parse(result)); // Create and return a diagnosis with the result
                    }
                }
            }
            return null;
        }

        public override string ToString()
        {
            return $"Hospital {Id}: \"{Name}\" in {City} ; {Doctors.Count} doctors, {Patients.Count} patients, {Files.Count} files";
        }
    }
}
