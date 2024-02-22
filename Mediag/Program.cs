using DiagnosticDecision;
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
                    file.MedicalData = samples[--nbSamples];
                }
            }
        }


        static void Main(string[] args)
        {
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
            //Patient PLucieMartin1 = new("Martin", "Lucie", new DateOnly(1998, 2, 12), "phoneNumber", "email@email.com", "Lyon");
            //Patient PMathieuDubois1 = new("Dubois", "Mathieu", new DateOnly(2002, 5, 7), "phoneNumber", "email@email.com", "Paris");
            //Patient PClaraLeroy1 = new("Leroy", "Clara", new DateOnly(1995, 9, 21), "phoneNumber", "email@email.com", "Bordeaux");
            //Patient PAntoineLefevre1 = new("Lefèvre", "Antoine", new DateOnly(2001, 3, 14), "phoneNumber", "email@email.com", "Nantes");
            //Patient PJulieMoreau1 = new("Moreau", "Julie", new DateOnly(1997, 8, 18), "phoneNumber", "email@email.com", "Toulouse");

            // Old patients
            Patient PJeanneDupont1 = new("Dupont", "Jeanne", new DateOnly(1954, 1, 4), "phoneNumber", "email@email.com", "Marseille");
            Patient PJeanneDupont2 = new("Dupont", "Jeanne", new DateOnly(1954, 1, 4), "phoneNumber", "email@email.com", "Marseille");
            Patient PJeanneDupont3 = new("Dupont", "Jeanne", new DateOnly(1954, 1, 4), "phoneNumber", "email@email.com", "Marseille");
            Patient PPierreDurand1 = new("Durand", "Pierre", new DateOnly(1962, 10, 9), "phoneNumber", "email@email.com", "Strasbourg");
            Patient PPierreDurand2 = new("Durand", "Pierre", new DateOnly(1962, 10, 9), "phoneNumber", "email@email.com", "Strasbourg");
            Patient PPierreDurand3 = new("Durand", "Pierre", new DateOnly(1962, 10, 9), "phoneNumber", "email@email.com", "Strasbourg");
            Patient PMarieBernard1 = new("Bernard", "Marie", new DateOnly(1957, 4, 15), "phoneNumber", "email@email.com", "Lille");
            Patient PMarieBernard2 = new("Bernard", "Marie", new DateOnly(1957, 4, 15), "phoneNumber", "email@email.com", "Lille");
            Patient PMarieBernard3 = new("Bernard", "Marie", new DateOnly(1957, 4, 15), "phoneNumber", "email@email.com", "Lille");
            Patient PJacquesPetit1 = new("Petit", "Jacques", new DateOnly(1965, 7, 22), "phoneNumber", "email@email.com", "Nice");
            Patient PJacquesPetit2 = new("Petit", "Jacques", new DateOnly(1965, 7, 22), "phoneNumber", "email@email.com", "Nice");
            Patient PJacquesPetit3 = new("Petit", "Jacques", new DateOnly(1965, 7, 22), "phoneNumber", "email@email.com", "Nice");
            Patient PSophieLemaire1 = new("Lemaire", "Sophie", new DateOnly(1959, 12, 27), "phoneNumber", "email@email.com", "Rennes");
            Patient PSophieLemaire2 = new("Lemaire", "Sophie", new DateOnly(1959, 12, 27), "phoneNumber", "email@email.com", "Rennes");
            Patient PSophieLemaire3 = new("Lemaire", "Sophie", new DateOnly(1959, 12, 27), "phoneNumber", "email@email.com", "Rennes");
            Patient PDanielleRobert1 = new("Robert", "Danielle", new DateOnly(1956, 6, 3), "phoneNumber", "email@email.com", "Montpellier");
            Patient PDanielleRobert2 = new("Robert", "Danielle", new DateOnly(1956, 6, 3), "phoneNumber", "email@email.com", "Montpellier");
            Patient PDanielleRobert3 = new("Robert", "Danielle", new DateOnly(1956, 6, 3), "phoneNumber", "email@email.com", "Montpellier");
            Patient PMichelLacroix1 = new("Lacroix", "Michel", new DateOnly(1963, 11, 11), "phoneNumber", "email@email.com", "Reims");
            Patient PMichelLacroix2 = new("Lacroix", "Michel", new DateOnly(1963, 11, 11), "phoneNumber", "email@email.com", "Reims");
            Patient PMichelLacroix3 = new("Lacroix", "Michel", new DateOnly(1963, 11, 11), "phoneNumber", "email@email.com", "Reims");
            Patient PNathalieSimon1 = new("Simon", "Nathalie", new DateOnly(1958, 2, 19), "phoneNumber", "email@email.com", "Dijon");
            Patient PNathalieSimon2 = new("Simon", "Nathalie", new DateOnly(1958, 2, 19), "phoneNumber", "email@email.com", "Dijon");
            Patient PNathalieSimon3 = new("Simon", "Nathalie", new DateOnly(1958, 2, 19), "phoneNumber", "email@email.com", "Dijon");
            Patient PBernardMorel1 = new("Morel", "Bernard", new DateOnly(1967, 8, 25), "phoneNumber", "email@email.com", "Tours");
            Patient PBernardMorel2 = new("Morel", "Bernard", new DateOnly(1967, 8, 25), "phoneNumber", "email@email.com", "Tours");
            Patient PBernardMorel3 = new("Morel", "Bernard", new DateOnly(1967, 8, 25), "phoneNumber", "email@email.com", "Tours");
            Patient PIsabelleGirard1 = new("Girard", "Isabelle", new DateOnly(1960, 3, 30), "phoneNumber", "email@email.com", "Grenoble");
            Patient PIsabelleGirard2 = new("Girard", "Isabelle", new DateOnly(1960, 3, 30), "phoneNumber", "email@email.com", "Grenoble");
            //Patient PIsabelleGirard3 = new("Girard", "Isabelle", new DateTime(1960, 3, 30), "phoneNumber", "email@email.com", "Grenoble");

            // Add patients to hospitals
            hospital1.AddPatient(PJeanneDupont1);
            hospital2.AddPatient(PJeanneDupont2);
            hospital3.AddPatient(PJeanneDupont3);
            hospital2.AddPatient(PPierreDurand1);
            hospital3.AddPatient(PPierreDurand2);
            hospital1.AddPatient(PPierreDurand3);
            hospital3.AddPatient(PMarieBernard1);
            hospital1.AddPatient(PMarieBernard2);
            hospital2.AddPatient(PMarieBernard3);
            hospital3.AddPatient(PJacquesPetit1);
            hospital2.AddPatient(PJacquesPetit2);
            hospital1.AddPatient(PJacquesPetit3);
            hospital1.AddPatient(PSophieLemaire1);
            hospital3.AddPatient(PSophieLemaire2);
            hospital2.AddPatient(PSophieLemaire3);
            hospital1.AddPatient(PDanielleRobert1);
            hospital2.AddPatient(PDanielleRobert2);
            hospital1.AddPatient(PDanielleRobert3);
            hospital2.AddPatient(PMichelLacroix1);
            hospital1.AddPatient(PMichelLacroix2);
            hospital2.AddPatient(PMichelLacroix3);
            hospital1.AddPatient(PNathalieSimon1);
            hospital1.AddPatient(PNathalieSimon2);
            hospital2.AddPatient(PNathalieSimon3);
            hospital2.AddPatient(PBernardMorel1);
            hospital2.AddPatient(PBernardMorel2);
            hospital1.AddPatient(PBernardMorel3);
            hospital1.AddPatient(PIsabelleGirard1);
            hospital2.AddPatient(PIsabelleGirard2);
            //hospital3.AddPatient(PIsabelleGirard3);

            // Patients' medical files
            MedicalFile FJeanneDupont1 = new(PJeanneDupont1);
            MedicalFile FJeanneDupont2 = new(PJeanneDupont2);
            MedicalFile FJeanneDupont3 = new(PJeanneDupont3);
            MedicalFile FPierreDurand1 = new(PPierreDurand1);
            MedicalFile FPierreDurand2 = new(PPierreDurand2);
            MedicalFile FPierreDurand3 = new(PPierreDurand3);
            MedicalFile FMarieBernard1 = new(PMarieBernard1);
            MedicalFile FMarieBernard2 = new(PMarieBernard2);
            MedicalFile FMarieBernard3 = new(PMarieBernard3);
            MedicalFile FJacquesPetit1 = new(PJacquesPetit1);
            MedicalFile FJacquesPetit2 = new(PJacquesPetit2);
            MedicalFile FJacquesPetit3 = new(PJacquesPetit3);
            MedicalFile FSophieLemaire1 = new(PSophieLemaire1);
            MedicalFile FSophieLemaire2 = new(PSophieLemaire2);
            MedicalFile FSophieLemaire3 = new(PSophieLemaire3);
            MedicalFile FDanielleRobert1 = new(PDanielleRobert1);
            MedicalFile FDanielleRobert2 = new(PDanielleRobert2);
            MedicalFile FDanielleRobert3 = new(PDanielleRobert3);
            MedicalFile FMichelLacroix1 = new(PMichelLacroix1);
            MedicalFile FMichelLacroix2 = new(PMichelLacroix2);
            MedicalFile FMichelLacroix3 = new(PMichelLacroix3);
            MedicalFile FNathalieSimon1 = new(PNathalieSimon1);
            MedicalFile FNathalieSimon2 = new(PNathalieSimon2);
            MedicalFile FNathalieSimon3 = new(PNathalieSimon3);
            MedicalFile FBernardMorel1 = new(PBernardMorel1);
            MedicalFile FBernardMorel2 = new(PBernardMorel2);
            MedicalFile FBernardMorel3 = new(PBernardMorel3);
            MedicalFile FIsabelleGirard1 = new(PIsabelleGirard1);
            MedicalFile FIsabelleGirard2 = new(PIsabelleGirard2);
            //MedicalFile FIsabelleGirard3 = new(PIsabelleGirard3);

            // Add files to hospitals
            hospital1.AddFile(FJeanneDupont1);
            hospital2.AddFile(FJeanneDupont2);
            hospital3.AddFile(FJeanneDupont3);
            hospital2.AddFile(FPierreDurand1);
            hospital3.AddFile(FPierreDurand2);
            hospital1.AddFile(FPierreDurand3);
            hospital3.AddFile(FMarieBernard1);
            hospital1.AddFile(FMarieBernard2);
            hospital2.AddFile(FMarieBernard3);
            hospital3.AddFile(FJacquesPetit1);
            hospital2.AddFile(FJacquesPetit2);
            hospital1.AddFile(FJacquesPetit3);
            hospital1.AddFile(FSophieLemaire1);
            hospital3.AddFile(FSophieLemaire2);
            hospital2.AddFile(FSophieLemaire3);
            hospital1.AddFile(FDanielleRobert1);
            hospital2.AddFile(FDanielleRobert2);
            hospital1.AddFile(FDanielleRobert3);
            hospital2.AddFile(FMichelLacroix1);
            hospital1.AddFile(FMichelLacroix2);
            hospital2.AddFile(FMichelLacroix3);
            hospital1.AddFile(FNathalieSimon1);
            hospital1.AddFile(FNathalieSimon2);
            hospital2.AddFile(FNathalieSimon3);
            hospital2.AddFile(FBernardMorel1);
            hospital2.AddFile(FBernardMorel2);
            hospital1.AddFile(FBernardMorel3);
            hospital1.AddFile(FIsabelleGirard1);
            hospital2.AddFile(FIsabelleGirard2);
            //hospital3.AddFile(FIsabelleGirard3);

            // Add doctors to medical files
            FJeanneDupont1.AddDoctorInCharge(DThomasRichard1);
            FSophieLemaire1.AddDoctorInCharge(DThomasRichard1);
            FNathalieSimon1.AddDoctorInCharge(DThomasRichard1);
            FPierreDurand3.AddDoctorInCharge(DAnneMarieLeroux1);
            FDanielleRobert1.AddDoctorInCharge(DAnneMarieLeroux1);
            FNathalieSimon2.AddDoctorInCharge(DAnneMarieLeroux1);
            FMarieBernard2.AddDoctorInCharge(DSebastienRoux1);
            FDanielleRobert3.AddDoctorInCharge(DSebastienRoux1);
            FBernardMorel3.AddDoctorInCharge(DSebastienRoux1);
            FJacquesPetit3.AddDoctorInCharge(DCelineGautier1);
            FMichelLacroix2.AddDoctorInCharge(DCelineGautier1);
            FIsabelleGirard1.AddDoctorInCharge(DCelineGautier1);
            FJeanneDupont2.AddDoctorInCharge(DAlexandreDupuy1);
            FSophieLemaire3.AddDoctorInCharge(DAlexandreDupuy1);
            FNathalieSimon3.AddDoctorInCharge(DAlexandreDupuy1);
            FPierreDurand1.AddDoctorInCharge(DElodieMartin1);
            FDanielleRobert2.AddDoctorInCharge(DElodieMartin1);
            FBernardMorel1.AddDoctorInCharge(DElodieMartin1);
            FMarieBernard3.AddDoctorInCharge(DRomainLefebvre1);
            FMichelLacroix1.AddDoctorInCharge(DRomainLefebvre1);
            FBernardMorel2.AddDoctorInCharge(DRomainLefebvre1);
            FJacquesPetit2.AddDoctorInCharge(DSarahLeroy1);
            FMichelLacroix3.AddDoctorInCharge(DSarahLeroy1);
            FIsabelleGirard2.AddDoctorInCharge(DSarahLeroy1);
            FJeanneDupont3.AddDoctorInCharge(DMaximeDupont1);
            FMarieBernard1.AddDoctorInCharge(DMaximeDupont1);
            FSophieLemaire2.AddDoctorInCharge(DMaximeDupont1);
            FPierreDurand2.AddDoctorInCharge(DLauraMorel1);
            FJacquesPetit1.AddDoctorInCharge(DLauraMorel1);
            //FIsabelleGirard3.AddDoctorInCharge(DLauraMorel1);

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
            Console.WriteLine(PJeanneDupont1.ToString());
            Console.WriteLine(PPierreDurand1.ToString());
            Console.WriteLine(PMarieBernard1.ToString());
            Console.WriteLine();
            Console.WriteLine("Some medical files:");
            Console.WriteLine(FJeanneDupont1.ToString());
            Console.WriteLine(FPierreDurand1.ToString());
            Console.WriteLine(FMarieBernard1.ToString());
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
        }
    }
}
