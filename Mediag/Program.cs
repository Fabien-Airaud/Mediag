﻿using DiagnosticDecision;
using Mediag.DatabaseCSV;
using Mediag.Medical;
using System;
using System.Collections.Generic;

namespace Mediag
{
    internal class Program
    {
        private static void AddAllSamples(Hospital[] hospitals, List<IMedicalData> samples)
        {
            int nbSamples = samples.Count;

            foreach (Hospital hospital in hospitals)
            {
                foreach (MedicalFile file in hospital.Files)
                {
                    if (nbSamples == 0) return;
                    file.AddMedicalData(samples[--nbSamples]);
                }
            }
        }


        static void Main(string[] args)
        {
            // Breast cancer

            // Hospitals
            Hospital hospital1 = new("Hôpital général de Montréal", "Montréal");
            Hospital hospital2 = new("Hôpital Charles-Le Moyne", "Greenfield Park");
            Hospital hospital3 = new("Hôtel-Dieu d'Arthabaska", "Victoriaville");
            //Hospital hospital4 = new("Hôpital Honoré-Mercier", "Saint-Hyacinthe");
            //Hospital hospital5 = new("Hôpital Brome-Missisquoi-Perkins (BMP)", "Cowansville");
            //Hospital hospital6 = new("Centre gériatrique Maimonides Donald Berman", "Côte-Saint-Luc");
            //Hospital hospital7 = new("Hôppital de Granby", "Granby");
            //Hospital hospital8 = new("Hôpital Sainte-Anne-de-Beaupré", "Beaupré");
            //Hospital hospital9 = new("Centre hospitalier de l'Université de Montréal (CHUM)", "Montréal");
            //Hospital hospital10 = new("Hôpital de La Malbaie", "La Malbaie");

            // Doctors
            Doctor DThomasRichard1 = new("Richard", "Thomas", new DateOnly(1985, 6, 16), "phoneNumber", "email@email.com", "Clermont-Ferrand");
            Doctor DAnneMarieLeroux1 = new("Leroux", "AnneMarie", new DateOnly(1992, 12, 10), "phoneNumber", "email@email.com", "Angers");
            Doctor DSebastienRoux1 = new("Roux", "Sébastien", new DateOnly(1989, 4, 8), "phoneNumber", "email@email.com", "Nancy");
            Doctor DCelineGautier1 = new("Gautier", "Céline", new DateOnly(1996, 1, 13), "phoneNumber", "email@email.com", "Le Havre");
            Doctor DAlexandreDupuy1 = new("Dupuy", "Alexandre", new DateOnly(1987, 9, 5), "phoneNumber", "email@email.com", "Metz");
            Doctor DElodieMartin1 = new("Martin", "Élodie", new DateOnly(1993, 10, 17), "phoneNumber", "email@email.com", "Brest");
            Doctor DRomainLefebvre1 = new("Lefebvre", "Romain", new DateOnly(1988, 3, 6), "phoneNumber", "email@email.com", "Limoges");
            Doctor DSarahLeroy1 = new("Leroy", "Sarah", new DateOnly(1994, 6, 20), "phoneNumber", "email@email.com", "Amiens");
            Doctor DMaximeDupont1 = new("Dupont", "Maxime", new DateOnly(1986, 11, 28), "phoneNumber", "email@email.com", "Perpignan");
            Doctor DLauraMorel1 = new("Morel", "Laura", new DateOnly(1997, 4, 2), "phoneNumber", "email@email.com", "Rouen");

            // Add doctors to hospitals
            hospital1.AddDoctor(DThomasRichard1);
            hospital1.AddDoctor(DAnneMarieLeroux1);
            hospital1.AddDoctor(DSebastienRoux1);
            hospital1.AddDoctor(DCelineGautier1);
            hospital2.AddDoctor(DAlexandreDupuy1);
            hospital2.AddDoctor(DElodieMartin1);
            hospital2.AddDoctor(DRomainLefebvre1);
            hospital2.AddDoctor(DSarahLeroy1);
            hospital3.AddDoctor(DMaximeDupont1);
            hospital3.AddDoctor(DLauraMorel1);

            // Young patients
            //Patient PLucieMartin_BC1 = new("Martin", "Lucie", new DateOnly(1998, 2, 12), "phoneNumber", "email@email.com", "Lyon");
            //Patient PMathieuDubois_BC1 = new("Dubois", "Mathieu", new DateOnly(2002, 5, 7), "phoneNumber", "email@email.com", "Paris");
            //Patient PClaraLeroy_BC1 = new("Leroy", "Clara", new DateOnly(1995, 9, 21), "phoneNumber", "email@email.com", "Bordeaux");
            //Patient PAntoineLefevre_BC1 = new("Lefèvre", "Antoine", new DateOnly(2001, 3, 14), "phoneNumber", "email@email.com", "Nantes");
            //Patient PJulieMoreau_BC1 = new("Moreau", "Julie", new DateOnly(1997, 8, 18), "phoneNumber", "email@email.com", "Toulouse");

            // Old patients
            Patient PJeanneDupont_BC1 = new("Dupont_BC1", "Jeanne", new DateOnly(1954, 1, 4), "phoneNumber", "email@email.com", "Marseille");
            Patient PJeanneDupont_BC2 = new("Dupont_BC2", "Jeanne", new DateOnly(1954, 1, 4), "phoneNumber", "email@email.com", "Marseille");
            Patient PJeanneDupont_BC3 = new("Dupont_BC3", "Jeanne", new DateOnly(1954, 1, 4), "phoneNumber", "email@email.com", "Marseille");
            Patient PPierreDurand_BC1 = new("Durand_BC1", "Pierre", new DateOnly(1962, 10, 9), "phoneNumber", "email@email.com", "Strasbourg");
            Patient PPierreDurand_BC2 = new("Durand_BC2", "Pierre", new DateOnly(1962, 10, 9), "phoneNumber", "email@email.com", "Strasbourg");
            Patient PPierreDurand_BC3 = new("Durand_BC3", "Pierre", new DateOnly(1962, 10, 9), "phoneNumber", "email@email.com", "Strasbourg");
            Patient PMarieBernard_BC1 = new("Bernard_BC1", "Marie", new DateOnly(1957, 4, 15), "phoneNumber", "email@email.com", "Lille");
            Patient PMarieBernard_BC2 = new("Bernard_BC2", "Marie", new DateOnly(1957, 4, 15), "phoneNumber", "email@email.com", "Lille");
            Patient PMarieBernard_BC3 = new("Bernard_BC3", "Marie", new DateOnly(1957, 4, 15), "phoneNumber", "email@email.com", "Lille");
            Patient PJacquesPetit_BC1 = new("Petit_BC1", "Jacques", new DateOnly(1965, 7, 22), "phoneNumber", "email@email.com", "Nice");
            Patient PJacquesPetit_BC2 = new("Petit_BC2", "Jacques", new DateOnly(1965, 7, 22), "phoneNumber", "email@email.com", "Nice");
            Patient PJacquesPetit_BC3 = new("Petit_BC3", "Jacques", new DateOnly(1965, 7, 22), "phoneNumber", "email@email.com", "Nice");
            Patient PSophieLemaire_BC1 = new("Lemaire_BC1", "Sophie", new DateOnly(1959, 12, 27), "phoneNumber", "email@email.com", "Rennes");
            Patient PSophieLemaire_BC2 = new("Lemaire_BC2", "Sophie", new DateOnly(1959, 12, 27), "phoneNumber", "email@email.com", "Rennes");
            Patient PSophieLemaire_BC3 = new("Lemaire_BC3", "Sophie", new DateOnly(1959, 12, 27), "phoneNumber", "email@email.com", "Rennes");
            Patient PDanielleRobert_BC1 = new("Robert_BC1", "Danielle", new DateOnly(1956, 6, 3), "phoneNumber", "email@email.com", "Montpellier");
            Patient PDanielleRobert_BC2 = new("Robert_BC2", "Danielle", new DateOnly(1956, 6, 3), "phoneNumber", "email@email.com", "Montpellier");
            Patient PDanielleRobert_BC3 = new("Robert_BC3", "Danielle", new DateOnly(1956, 6, 3), "phoneNumber", "email@email.com", "Montpellier");
            Patient PMichelLacroix_BC1 = new("Lacroix_BC1", "Michel", new DateOnly(1963, 11, 11), "phoneNumber", "email@email.com", "Reims");
            Patient PMichelLacroix_BC2 = new("Lacroix_BC2", "Michel", new DateOnly(1963, 11, 11), "phoneNumber", "email@email.com", "Reims");
            Patient PMichelLacroix_BC3 = new("Lacroix_BC", "Michel", new DateOnly(1963, 11, 11), "phoneNumber", "email@email.com", "Reims");
            Patient PNathalieSimon_BC1 = new("Simon_BC1", "Nathalie", new DateOnly(1958, 2, 19), "phoneNumber", "email@email.com", "Dijon");
            Patient PNathalieSimon_BC2 = new("Simon_BC2", "Nathalie", new DateOnly(1958, 2, 19), "phoneNumber", "email@email.com", "Dijon");
            Patient PNathalieSimon_BC3 = new("Simon_BC3", "Nathalie", new DateOnly(1958, 2, 19), "phoneNumber", "email@email.com", "Dijon");
            Patient PBernardMorel_BC1 = new("Morel_BC1", "Bernard", new DateOnly(1967, 8, 25), "phoneNumber", "email@email.com", "Tours");
            Patient PBernardMorel_BC2 = new("Morel_BC2", "Bernard", new DateOnly(1967, 8, 25), "phoneNumber", "email@email.com", "Tours");
            Patient PBernardMorel_BC3 = new("Morel_BC3", "Bernard", new DateOnly(1967, 8, 25), "phoneNumber", "email@email.com", "Tours");
            Patient PIsabelleGirard_BC1 = new("Girard_BC1", "Isabelle", new DateOnly(1960, 3, 30), "phoneNumber", "email@email.com", "Grenoble");
            Patient PIsabelleGirard_BC2 = new("Girard_BC2", "Isabelle", new DateOnly(1960, 3, 30), "phoneNumber", "email@email.com", "Grenoble");
            //Patient PIsabelleGirard_BC3 = new("Girard_BC3", "Isabelle", new DateOnly(1960, 3, 30), "phoneNumber", "email@email.com", "Grenoble");

            // Add patients to hospitals
            hospital1.AddPatient(PJeanneDupont_BC1);
            hospital2.AddPatient(PJeanneDupont_BC2);
            hospital3.AddPatient(PJeanneDupont_BC3);
            hospital2.AddPatient(PPierreDurand_BC1);
            hospital3.AddPatient(PPierreDurand_BC2);
            hospital1.AddPatient(PPierreDurand_BC3);
            hospital3.AddPatient(PMarieBernard_BC1);
            hospital1.AddPatient(PMarieBernard_BC2);
            hospital2.AddPatient(PMarieBernard_BC3);
            hospital3.AddPatient(PJacquesPetit_BC1);
            hospital2.AddPatient(PJacquesPetit_BC2);
            hospital1.AddPatient(PJacquesPetit_BC3);
            hospital1.AddPatient(PSophieLemaire_BC1);
            hospital3.AddPatient(PSophieLemaire_BC2);
            hospital2.AddPatient(PSophieLemaire_BC3);
            hospital1.AddPatient(PDanielleRobert_BC1);
            hospital2.AddPatient(PDanielleRobert_BC2);
            hospital1.AddPatient(PDanielleRobert_BC3);
            hospital2.AddPatient(PMichelLacroix_BC1);
            hospital1.AddPatient(PMichelLacroix_BC2);
            hospital2.AddPatient(PMichelLacroix_BC3);
            hospital1.AddPatient(PNathalieSimon_BC1);
            hospital1.AddPatient(PNathalieSimon_BC2);
            hospital2.AddPatient(PNathalieSimon_BC3);
            hospital2.AddPatient(PBernardMorel_BC1);
            hospital2.AddPatient(PBernardMorel_BC2);
            hospital1.AddPatient(PBernardMorel_BC3);
            hospital1.AddPatient(PIsabelleGirard_BC1);
            hospital2.AddPatient(PIsabelleGirard_BC2);
            //hospital3.AddPatient(PIsabelleGirard_BC3);

            // Patients' medical files
            MedicalFile FJeanneDupont_BC1 = new(PJeanneDupont_BC1);
            MedicalFile FJeanneDupont_BC2 = new(PJeanneDupont_BC2);
            MedicalFile FJeanneDupont_BC3 = new(PJeanneDupont_BC3);
            MedicalFile FPierreDurand_BC1 = new(PPierreDurand_BC1);
            MedicalFile FPierreDurand_BC2 = new(PPierreDurand_BC2);
            MedicalFile FPierreDurand_BC3 = new(PPierreDurand_BC3);
            MedicalFile FMarieBernard_BC1 = new(PMarieBernard_BC1);
            MedicalFile FMarieBernard_BC2 = new(PMarieBernard_BC2);
            MedicalFile FMarieBernard_BC3 = new(PMarieBernard_BC3);
            MedicalFile FJacquesPetit_BC1 = new(PJacquesPetit_BC1);
            MedicalFile FJacquesPetit_BC2 = new(PJacquesPetit_BC2);
            MedicalFile FJacquesPetit_BC3 = new(PJacquesPetit_BC3);
            MedicalFile FSophieLemaire_BC1 = new(PSophieLemaire_BC1);
            MedicalFile FSophieLemaire_BC2 = new(PSophieLemaire_BC2);
            MedicalFile FSophieLemaire_BC3 = new(PSophieLemaire_BC3);
            MedicalFile FDanielleRobert_BC1 = new(PDanielleRobert_BC1);
            MedicalFile FDanielleRobert_BC2 = new(PDanielleRobert_BC2);
            MedicalFile FDanielleRobert_BC3 = new(PDanielleRobert_BC3);
            MedicalFile FMichelLacroix_BC1 = new(PMichelLacroix_BC1);
            MedicalFile FMichelLacroix_BC2 = new(PMichelLacroix_BC2);
            MedicalFile FMichelLacroix_BC3 = new(PMichelLacroix_BC3);
            MedicalFile FNathalieSimon_BC1 = new(PNathalieSimon_BC1);
            MedicalFile FNathalieSimon_BC2 = new(PNathalieSimon_BC2);
            MedicalFile FNathalieSimon_BC3 = new(PNathalieSimon_BC3);
            MedicalFile FBernardMorel_BC1 = new(PBernardMorel_BC1);
            MedicalFile FBernardMorel_BC2 = new(PBernardMorel_BC2);
            MedicalFile FBernardMorel_BC3 = new(PBernardMorel_BC3);
            MedicalFile FIsabelleGirard_BC1 = new(PIsabelleGirard_BC1);
            MedicalFile FIsabelleGirard_BC2 = new(PIsabelleGirard_BC2);
            //MedicalFile FIsabelleGirard_BC3 = new(PIsabelleGirard_BC3);

            // Add files to hospitals
            hospital1.AddFile(FJeanneDupont_BC1);
            hospital2.AddFile(FJeanneDupont_BC2);
            hospital3.AddFile(FJeanneDupont_BC3);
            hospital2.AddFile(FPierreDurand_BC1);
            hospital3.AddFile(FPierreDurand_BC2);
            hospital1.AddFile(FPierreDurand_BC3);
            hospital3.AddFile(FMarieBernard_BC1);
            hospital1.AddFile(FMarieBernard_BC2);
            hospital2.AddFile(FMarieBernard_BC3);
            hospital3.AddFile(FJacquesPetit_BC1);
            hospital2.AddFile(FJacquesPetit_BC2);
            hospital1.AddFile(FJacquesPetit_BC3);
            hospital1.AddFile(FSophieLemaire_BC1);
            hospital3.AddFile(FSophieLemaire_BC2);
            hospital2.AddFile(FSophieLemaire_BC3);
            hospital1.AddFile(FDanielleRobert_BC1);
            hospital2.AddFile(FDanielleRobert_BC2);
            hospital1.AddFile(FDanielleRobert_BC3);
            hospital2.AddFile(FMichelLacroix_BC1);
            hospital1.AddFile(FMichelLacroix_BC2);
            hospital2.AddFile(FMichelLacroix_BC3);
            hospital1.AddFile(FNathalieSimon_BC1);
            hospital1.AddFile(FNathalieSimon_BC2);
            hospital2.AddFile(FNathalieSimon_BC3);
            hospital2.AddFile(FBernardMorel_BC1);
            hospital2.AddFile(FBernardMorel_BC2);
            hospital1.AddFile(FBernardMorel_BC3);
            hospital1.AddFile(FIsabelleGirard_BC1);
            hospital2.AddFile(FIsabelleGirard_BC2);
            //hospital3.AddFile(FIsabelleGirard_BC3);

            // Add doctors to medical files
            FJeanneDupont_BC1.AddDoctorInCharge(DThomasRichard1);
            FSophieLemaire_BC1.AddDoctorInCharge(DThomasRichard1);
            FNathalieSimon_BC1.AddDoctorInCharge(DThomasRichard1);
            FPierreDurand_BC3.AddDoctorInCharge(DAnneMarieLeroux1);
            FDanielleRobert_BC1.AddDoctorInCharge(DAnneMarieLeroux1);
            FNathalieSimon_BC2.AddDoctorInCharge(DAnneMarieLeroux1);
            FMarieBernard_BC2.AddDoctorInCharge(DSebastienRoux1);
            FDanielleRobert_BC3.AddDoctorInCharge(DSebastienRoux1);
            FBernardMorel_BC3.AddDoctorInCharge(DSebastienRoux1);
            FJacquesPetit_BC3.AddDoctorInCharge(DCelineGautier1);
            FMichelLacroix_BC2.AddDoctorInCharge(DCelineGautier1);
            FIsabelleGirard_BC1.AddDoctorInCharge(DCelineGautier1);
            FJeanneDupont_BC2.AddDoctorInCharge(DAlexandreDupuy1);
            FSophieLemaire_BC3.AddDoctorInCharge(DAlexandreDupuy1);
            FNathalieSimon_BC3.AddDoctorInCharge(DAlexandreDupuy1);
            FPierreDurand_BC1.AddDoctorInCharge(DElodieMartin1);
            FDanielleRobert_BC2.AddDoctorInCharge(DElodieMartin1);
            FBernardMorel_BC1.AddDoctorInCharge(DElodieMartin1);
            FMarieBernard_BC3.AddDoctorInCharge(DRomainLefebvre1);
            FMichelLacroix_BC1.AddDoctorInCharge(DRomainLefebvre1);
            FBernardMorel_BC2.AddDoctorInCharge(DRomainLefebvre1);
            FJacquesPetit_BC2.AddDoctorInCharge(DSarahLeroy1);
            FMichelLacroix_BC3.AddDoctorInCharge(DSarahLeroy1);
            FIsabelleGirard_BC2.AddDoctorInCharge(DSarahLeroy1);
            FJeanneDupont_BC3.AddDoctorInCharge(DMaximeDupont1);
            FMarieBernard_BC1.AddDoctorInCharge(DMaximeDupont1);
            FSophieLemaire_BC2.AddDoctorInCharge(DMaximeDupont1);
            FPierreDurand_BC2.AddDoctorInCharge(DLauraMorel1);
            FJacquesPetit_BC1.AddDoctorInCharge(DLauraMorel1);
            //FIsabelleGirard_BC3.AddDoctorInCharge(DLauraMorel1);

            // Display some fake data
            Console.WriteLine("Some hospitals:");
            Console.WriteLine(hospital1.ToString());
            Console.WriteLine(hospital2.ToString());
            Console.WriteLine(hospital3.ToString());
            Console.WriteLine();
            Console.WriteLine("Some doctors:");
            Console.WriteLine(DThomasRichard1.ToString());
            Console.WriteLine(DAnneMarieLeroux1.ToString());
            Console.WriteLine(DSebastienRoux1.ToString());
            Console.WriteLine();
            Console.WriteLine("Some patients:");
            Console.WriteLine(PJeanneDupont_BC1.ToString());
            Console.WriteLine(PPierreDurand_BC1.ToString());
            Console.WriteLine(PMarieBernard_BC1.ToString());
            Console.WriteLine();
            Console.WriteLine("Some medical files:");
            Console.WriteLine(FJeanneDupont_BC1.ToString());
            Console.WriteLine(FPierreDurand_BC1.ToString());
            Console.WriteLine(FMarieBernard_BC1.ToString());
            Console.WriteLine();
            Console.WriteLine();


            // Get data from dataset
            DataManager<BreastCancerData, BreastCancerMap> dataManager = new("BreastCancer");
            Console.WriteLine("Breast Cancer train count: " + dataManager.GetTrainData().Count);
            Console.WriteLine("Breast Cancer test count: " + dataManager.GetTestData().Count);
            Console.WriteLine("Breast Cancer samples count: " + dataManager.GetSamplesData().Count);
            Console.WriteLine();

            // Decision tree
            DecisionTree decisionTree = new(IllnessTypes.BreastCancer.ToString());

            // Train
            List<string[]> trainValues = [];
            foreach (IMedicalData data in dataManager.GetTrainData()) trainValues.Add(data.Values());
            List<string> trainLabels = new(dataManager.GetTrainData()[0].Labels());
            decisionTree.BuildTree(trainValues, trainLabels);
            Console.WriteLine(decisionTree.ToString());
            Console.WriteLine();

            // Evaluate
            List<string[]> testValues = [];
            foreach (IMedicalData data in dataManager.GetTestData()) testValues.Add(data.Values());
            Console.WriteLine(decisionTree.Evaluate(testValues, out _, out _, out _));
            Console.WriteLine();

            // Add samples to medical files in hospitals
            AddAllSamples([hospital1, hospital2, hospital3], dataManager.GetSamplesData());

            // Add decision tree to hospitals
            hospital1.AddDecisionTree(IllnessTypes.BreastCancer, decisionTree);
            hospital2.AddDecisionTree(IllnessTypes.BreastCancer, decisionTree);
            hospital3.AddDecisionTree(IllnessTypes.BreastCancer, decisionTree);

            // Diagnose
            Console.WriteLine("Nb files to diagnose = " + DThomasRichard1.FilesToDiagnose().Count);
            MedicalFile medicalFile = DThomasRichard1.FilesToTreat[0];
            Console.WriteLine(DThomasRichard1.Diagnose(medicalFile).ToString() + " ; Expert result = " + medicalFile.MedicalData.Values()[^1]);
            Console.WriteLine("Nb files to diagnose = " + DThomasRichard1.FilesToDiagnose().Count);
            Console.WriteLine();
            foreach (Doctor doctor in hospital1.Doctors)
            {
                List<Diagnosis> diagnosisList = doctor.DiagnoseAllFiles();
                Console.WriteLine(doctor.ToString());
                Console.WriteLine(string.Join("\n", diagnosisList));
            }
            Console.WriteLine();
            Console.WriteLine();


            // Heart disease

            // Old patients
            Patient PJeanneDupont_HD1 = new("Dupont_HD1", "Jeanne", new DateOnly(1954, 1, 4), "phoneNumber", "email@email.com", "Marseille");
            Patient PJeanneDupont_HD2 = new("Dupont_HD2", "Jeanne", new DateOnly(1954, 1, 4), "phoneNumber", "email@email.com", "Marseille");
            Patient PJeanneDupont_HD3 = new("Dupont_HD3", "Jeanne", new DateOnly(1954, 1, 4), "phoneNumber", "email@email.com", "Marseille");
            Patient PJeanneDupont_HD4 = new("Dupont_HD4", "Jeanne", new DateOnly(1954, 1, 4), "phoneNumber", "email@email.com", "Marseille");
            Patient PJeanneDupont_HD5 = new("Dupont_HD5", "Jeanne", new DateOnly(1954, 1, 4), "phoneNumber", "email@email.com", "Marseille");
            Patient PJeanneDupont_HD6 = new("Dupont_HD6", "Jeanne", new DateOnly(1954, 1, 4), "phoneNumber", "email@email.com", "Marseille");
            Patient PPierreDurand_HD1 = new("Durand_HD1", "Pierre", new DateOnly(1962, 10, 9), "phoneNumber", "email@email.com", "Strasbourg");
            Patient PPierreDurand_HD2 = new("Durand_HD2", "Pierre", new DateOnly(1962, 10, 9), "phoneNumber", "email@email.com", "Strasbourg");
            Patient PPierreDurand_HD3 = new("Durand_HD3", "Pierre", new DateOnly(1962, 10, 9), "phoneNumber", "email@email.com", "Strasbourg");
            Patient PPierreDurand_HD4 = new("Durand_HD4", "Pierre", new DateOnly(1962, 10, 9), "phoneNumber", "email@email.com", "Strasbourg");
            Patient PPierreDurand_HD5 = new("Durand_HD5", "Pierre", new DateOnly(1962, 10, 9), "phoneNumber", "email@email.com", "Strasbourg");
            Patient PPierreDurand_HD6 = new("Durand_HD6", "Pierre", new DateOnly(1962, 10, 9), "phoneNumber", "email@email.com", "Strasbourg");
            Patient PMarieBernard_HD1 = new("Bernard_HD1", "Marie", new DateOnly(1957, 4, 15), "phoneNumber", "email@email.com", "Lille");
            Patient PMarieBernard_HD2 = new("Bernard_HD2", "Marie", new DateOnly(1957, 4, 15), "phoneNumber", "email@email.com", "Lille");
            Patient PMarieBernard_HD3 = new("Bernard_HD3", "Marie", new DateOnly(1957, 4, 15), "phoneNumber", "email@email.com", "Lille");
            Patient PMarieBernard_HD4 = new("Bernard_HD4", "Marie", new DateOnly(1957, 4, 15), "phoneNumber", "email@email.com", "Lille");
            Patient PMarieBernard_HD5 = new("Bernard_HD5", "Marie", new DateOnly(1957, 4, 15), "phoneNumber", "email@email.com", "Lille");
            Patient PMarieBernard_HD6 = new("Bernard_HD6", "Marie", new DateOnly(1957, 4, 15), "phoneNumber", "email@email.com", "Lille");
            Patient PJacquesPetit_HD1 = new("Petit_HD1", "Jacques", new DateOnly(1965, 7, 22), "phoneNumber", "email@email.com", "Nice");
            Patient PJacquesPetit_HD2 = new("Petit_HD2", "Jacques", new DateOnly(1965, 7, 22), "phoneNumber", "email@email.com", "Nice");
            Patient PJacquesPetit_HD3 = new("Petit_HD3", "Jacques", new DateOnly(1965, 7, 22), "phoneNumber", "email@email.com", "Nice");
            Patient PJacquesPetit_HD4 = new("Petit_HD4", "Jacques", new DateOnly(1965, 7, 22), "phoneNumber", "email@email.com", "Nice");
            Patient PJacquesPetit_HD5 = new("Petit_HD5", "Jacques", new DateOnly(1965, 7, 22), "phoneNumber", "email@email.com", "Nice");
            Patient PJacquesPetit_HD6 = new("Petit_HD6", "Jacques", new DateOnly(1965, 7, 22), "phoneNumber", "email@email.com", "Nice");
            Patient PSophieLemaire_HD1 = new("Lemaire_HD1", "Sophie", new DateOnly(1959, 12, 27), "phoneNumber", "email@email.com", "Rennes");
            Patient PSophieLemaire_HD2 = new("Lemaire_HD2", "Sophie", new DateOnly(1959, 12, 27), "phoneNumber", "email@email.com", "Rennes");
            Patient PSophieLemaire_HD3 = new("Lemaire_HD3", "Sophie", new DateOnly(1959, 12, 27), "phoneNumber", "email@email.com", "Rennes");
            Patient PSophieLemaire_HD4 = new("Lemaire_HD4", "Sophie", new DateOnly(1959, 12, 27), "phoneNumber", "email@email.com", "Rennes");
            Patient PSophieLemaire_HD5 = new("Lemaire_HD5", "Sophie", new DateOnly(1959, 12, 27), "phoneNumber", "email@email.com", "Rennes");
            Patient PSophieLemaire_HD6 = new("Lemaire_HD6", "Sophie", new DateOnly(1959, 12, 27), "phoneNumber", "email@email.com", "Rennes");
            Patient PDanielleRobert_HD1 = new("Robert_HD1", "Danielle", new DateOnly(1956, 6, 3), "phoneNumber", "email@email.com", "Montpellier");
            Patient PDanielleRobert_HD2 = new("Robert_HD2", "Danielle", new DateOnly(1956, 6, 3), "phoneNumber", "email@email.com", "Montpellier");
            Patient PDanielleRobert_HD3 = new("Robert_HD3", "Danielle", new DateOnly(1956, 6, 3), "phoneNumber", "email@email.com", "Montpellier");
            Patient PDanielleRobert_HD4 = new("Robert_HD4", "Danielle", new DateOnly(1956, 6, 3), "phoneNumber", "email@email.com", "Montpellier");
            Patient PDanielleRobert_HD5 = new("Robert_HD5", "Danielle", new DateOnly(1956, 6, 3), "phoneNumber", "email@email.com", "Montpellier");
            Patient PDanielleRobert_HD6 = new("Robert_HD6", "Danielle", new DateOnly(1956, 6, 3), "phoneNumber", "email@email.com", "Montpellier");
            Patient PMichelLacroix_HD1 = new("Lacroix_HD1", "Michel", new DateOnly(1963, 11, 11), "phoneNumber", "email@email.com", "Reims");
            Patient PMichelLacroix_HD2 = new("Lacroix_HD2", "Michel", new DateOnly(1963, 11, 11), "phoneNumber", "email@email.com", "Reims");
            Patient PMichelLacroix_HD3 = new("Lacroix_HD3", "Michel", new DateOnly(1963, 11, 11), "phoneNumber", "email@email.com", "Reims");
            Patient PMichelLacroix_HD4 = new("Lacroix_HD4", "Michel", new DateOnly(1963, 11, 11), "phoneNumber", "email@email.com", "Reims");
            Patient PMichelLacroix_HD5 = new("Lacroix_HD5", "Michel", new DateOnly(1963, 11, 11), "phoneNumber", "email@email.com", "Reims");
            Patient PMichelLacroix_HD6 = new("Lacroix_HD6", "Michel", new DateOnly(1963, 11, 11), "phoneNumber", "email@email.com", "Reims");
            Patient PNathalieSimon_HD1 = new("Simon_HD1", "Nathalie", new DateOnly(1958, 2, 19), "phoneNumber", "email@email.com", "Dijon");
            Patient PNathalieSimon_HD2 = new("Simon_HD2", "Nathalie", new DateOnly(1958, 2, 19), "phoneNumber", "email@email.com", "Dijon");
            Patient PNathalieSimon_HD3 = new("Simon_HD3", "Nathalie", new DateOnly(1958, 2, 19), "phoneNumber", "email@email.com", "Dijon");
            Patient PNathalieSimon_HD4 = new("Simon_HD4", "Nathalie", new DateOnly(1958, 2, 19), "phoneNumber", "email@email.com", "Dijon");
            Patient PNathalieSimon_HD5 = new("Simon_HD5", "Nathalie", new DateOnly(1958, 2, 19), "phoneNumber", "email@email.com", "Dijon");
            Patient PNathalieSimon_HD6 = new("Simon_HD6", "Nathalie", new DateOnly(1958, 2, 19), "phoneNumber", "email@email.com", "Dijon");
            Patient PBernardMorel_HD1 = new("Morel_HD1", "Bernard", new DateOnly(1967, 8, 25), "phoneNumber", "email@email.com", "Tours");
            Patient PBernardMorel_HD2 = new("Morel_HD2", "Bernard", new DateOnly(1967, 8, 25), "phoneNumber", "email@email.com", "Tours");
            Patient PBernardMorel_HD3 = new("Morel_HD3", "Bernard", new DateOnly(1967, 8, 25), "phoneNumber", "email@email.com", "Tours");
            Patient PBernardMorel_HD4 = new("Morel_HD4", "Bernard", new DateOnly(1967, 8, 25), "phoneNumber", "email@email.com", "Tours");
            Patient PBernardMorel_HD5 = new("Morel_HD5", "Bernard", new DateOnly(1967, 8, 25), "phoneNumber", "email@email.com", "Tours");
            Patient PBernardMorel_HD6 = new("Morel_HD6", "Bernard", new DateOnly(1967, 8, 25), "phoneNumber", "email@email.com", "Tours");
            Patient PIsabelleGirard_HD1 = new("Girard_HD1", "Isabelle", new DateOnly(1960, 3, 30), "phoneNumber", "email@email.com", "Grenoble");
            Patient PIsabelleGirard_HD2 = new("Girard_HD2", "Isabelle", new DateOnly(1960, 3, 30), "phoneNumber", "email@email.com", "Grenoble");
            Patient PIsabelleGirard_HD3 = new("Girard_HD3", "Isabelle", new DateOnly(1960, 3, 30), "phoneNumber", "email@email.com", "Grenoble");
            Patient PIsabelleGirard_HD4 = new("Girard_HD4", "Isabelle", new DateOnly(1960, 3, 30), "phoneNumber", "email@email.com", "Grenoble");
            Patient PIsabelleGirard_HD5 = new("Girard_HD5", "Isabelle", new DateOnly(1960, 3, 30), "phoneNumber", "email@email.com", "Grenoble");
            Patient PIsabelleGirard_HD6 = new("Girard_HD6", "Isabelle", new DateOnly(1960, 3, 30), "phoneNumber", "email@email.com", "Grenoble");

            //DataManager<HeartDiseaseData, HeartDiseaseMap> dataManager2 = new("HeartDisease");
            //Console.WriteLine("Heart Disease train count: " + dataManager2.GetTrainData().Count);
            //Console.WriteLine("Heart Disease test count: " + dataManager2.GetTestData().Count);
            //Console.WriteLine("Heart Disease samples count: " + dataManager2.GetSamplesData().Count);
        }
    }
}
