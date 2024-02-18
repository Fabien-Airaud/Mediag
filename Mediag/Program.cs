using Mediag.DatabaseCSV;
using Mediag.DiagnosticDecision;
using Mediag.Medical;
using System;
using System.Collections.Generic;

namespace Mediag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Hospitals
            Hospital hospital1 = new Hospital("Hôpital général de Montréal", "Montréal");
            Hospital hospital2 = new Hospital("Hôpital Charles-Le Moyne", "Greenfield Park");
            Hospital hospital3 = new Hospital("Hôtel-Dieu d'Arthabaska", "Victoriaville");
            //Hospital hospital4 = new Hospital("Hôpital Honoré-Mercier", "Saint-Hyacinthe");
            //Hospital hospital5 = new Hospital("Hôpital Brome-Missisquoi-Perkins (BMP)", "Cowansville");
            //Hospital hospital6 = new Hospital("Centre gériatrique Maimonides Donald Berman", "Côte-Saint-Luc");
            //Hospital hospital7 = new Hospital("Hôppital de Granby", "Granby");
            //Hospital hospital8 = new Hospital("Hôpital Sainte-Anne-de-Beaupré", "Beaupré");
            //Hospital hospital9 = new Hospital("Centre hospitalier de l'Université de Montréal (CHUM)", "Montréal");
            //Hospital hospital10 = new Hospital("Hôpital de La Malbaie", "La Malbaie");

            // Doctors
            Doctor DThomasRichard1 = new Doctor("Richard", "Thomas", new DateTime(1985, 6, 16), "phoneNumber", "email@email.com", "Clermont-Ferrand");
            Doctor DAnneMarieLeroux1 = new Doctor("Leroux", "AnneMarie", new DateTime(1992, 12, 10), "phoneNumber", "email@email.com", "Angers");
            Doctor DSebastienRoux1 = new Doctor("Roux", "Sébastien", new DateTime(1989, 4, 8), "phoneNumber", "email@email.com", "Nancy");
            Doctor DCelineGautier1 = new Doctor("Gautier", "Céline", new DateTime(1996, 1, 13), "phoneNumber", "email@email.com", "Le Havre");
            Doctor DAlexandreDupuy1 = new Doctor("Dupuy", "Alexandre", new DateTime(1987, 9, 5), "phoneNumber", "email@email.com", "Metz");
            Doctor DElodieMartin1 = new Doctor("Martin", "Élodie", new DateTime(1993, 10, 17), "phoneNumber", "email@email.com", "Brest");
            Doctor DRomainLefebvre1 = new Doctor("Lefebvre", "Romain", new DateTime(1988, 3, 6), "phoneNumber", "email@email.com", "Limoges");
            Doctor DSarahLeroy1 = new Doctor("Leroy", "Sarah", new DateTime(1994, 6, 20), "phoneNumber", "email@email.com", "Amiens");
            Doctor DMaximeDupont1 = new Doctor("Dupont", "Maxime", new DateTime(1986, 11, 28), "phoneNumber", "email@email.com", "Perpignan");
            Doctor DLauraMorel1 = new Doctor("Morel", "Laura", new DateTime(1997, 4, 2), "phoneNumber", "email@email.com", "Rouen");

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
            //Patient PLucieMartin1 = new Patient("Martin", "Lucie", new DateTime(1998, 2, 12), "phoneNumber", "email@email.com", "Lyon");
            //Patient PMathieuDubois1 = new Patient("Dubois", "Mathieu", new DateTime(2002, 5, 7), "phoneNumber", "email@email.com", "Paris");
            //Patient PClaraLeroy1 = new Patient("Leroy", "Clara", new DateTime(1995, 9, 21), "phoneNumber", "email@email.com", "Bordeaux");
            //Patient PAntoineLefevre1 = new Patient("Lefèvre", "Antoine", new DateTime(2001, 3, 14), "phoneNumber", "email@email.com", "Nantes");
            //Patient PJulieMoreau1 = new Patient("Moreau", "Julie", new DateTime(1997, 8, 18), "phoneNumber", "email@email.com", "Toulouse");

            // Old patients
            Patient PJeanneDupont1 = new Patient("Dupont", "Jeanne", new DateTime(1954, 1, 4), "phoneNumber", "email@email.com", "Marseille");
            Patient PJeanneDupont2 = new Patient("Dupont", "Jeanne", new DateTime(1954, 1, 4), "phoneNumber", "email@email.com", "Marseille");
            Patient PJeanneDupont3 = new Patient("Dupont", "Jeanne", new DateTime(1954, 1, 4), "phoneNumber", "email@email.com", "Marseille");
            Patient PPierreDurand1 = new Patient("Durand", "Pierre", new DateTime(1962, 10, 9), "phoneNumber", "email@email.com", "Strasbourg");
            Patient PPierreDurand2 = new Patient("Durand", "Pierre", new DateTime(1962, 10, 9), "phoneNumber", "email@email.com", "Strasbourg");
            Patient PPierreDurand3 = new Patient("Durand", "Pierre", new DateTime(1962, 10, 9), "phoneNumber", "email@email.com", "Strasbourg");
            Patient PMarieBernard1 = new Patient("Bernard", "Marie", new DateTime(1957, 4, 15), "phoneNumber", "email@email.com", "Lille");
            Patient PMarieBernard2 = new Patient("Bernard", "Marie", new DateTime(1957, 4, 15), "phoneNumber", "email@email.com", "Lille");
            Patient PMarieBernard3 = new Patient("Bernard", "Marie", new DateTime(1957, 4, 15), "phoneNumber", "email@email.com", "Lille");
            Patient PJacquesPetit1 = new Patient("Petit", "Jacques", new DateTime(1965, 7, 22), "phoneNumber", "email@email.com", "Nice");
            Patient PJacquesPetit2 = new Patient("Petit", "Jacques", new DateTime(1965, 7, 22), "phoneNumber", "email@email.com", "Nice");
            Patient PJacquesPetit3 = new Patient("Petit", "Jacques", new DateTime(1965, 7, 22), "phoneNumber", "email@email.com", "Nice");
            Patient PSophieLemaire1 = new Patient("Lemaire", "Sophie", new DateTime(1959, 12, 27), "phoneNumber", "email@email.com", "Rennes");
            Patient PSophieLemaire2 = new Patient("Lemaire", "Sophie", new DateTime(1959, 12, 27), "phoneNumber", "email@email.com", "Rennes");
            Patient PSophieLemaire3 = new Patient("Lemaire", "Sophie", new DateTime(1959, 12, 27), "phoneNumber", "email@email.com", "Rennes");
            Patient PDanielleRobert1 = new Patient("Robert", "Danielle", new DateTime(1956, 6, 3), "phoneNumber", "email@email.com", "Montpellier");
            Patient PDanielleRobert2 = new Patient("Robert", "Danielle", new DateTime(1956, 6, 3), "phoneNumber", "email@email.com", "Montpellier");
            Patient PDanielleRobert3 = new Patient("Robert", "Danielle", new DateTime(1956, 6, 3), "phoneNumber", "email@email.com", "Montpellier");
            Patient PMichelLacroix1 = new Patient("Lacroix", "Michel", new DateTime(1963, 11, 11), "phoneNumber", "email@email.com", "Reims");
            Patient PMichelLacroix2 = new Patient("Lacroix", "Michel", new DateTime(1963, 11, 11), "phoneNumber", "email@email.com", "Reims");
            Patient PMichelLacroix3 = new Patient("Lacroix", "Michel", new DateTime(1963, 11, 11), "phoneNumber", "email@email.com", "Reims");
            Patient PNathalieSimon1 = new Patient("Simon", "Nathalie", new DateTime(1958, 2, 19), "phoneNumber", "email@email.com", "Dijon");
            Patient PNathalieSimon2 = new Patient("Simon", "Nathalie", new DateTime(1958, 2, 19), "phoneNumber", "email@email.com", "Dijon");
            Patient PNathalieSimon3 = new Patient("Simon", "Nathalie", new DateTime(1958, 2, 19), "phoneNumber", "email@email.com", "Dijon");
            Patient PBernardMorel1 = new Patient("Morel", "Bernard", new DateTime(1967, 8, 25), "phoneNumber", "email@email.com", "Tours");
            Patient PBernardMorel2 = new Patient("Morel", "Bernard", new DateTime(1967, 8, 25), "phoneNumber", "email@email.com", "Tours");
            Patient PBernardMorel3 = new Patient("Morel", "Bernard", new DateTime(1967, 8, 25), "phoneNumber", "email@email.com", "Tours");
            Patient PIsabelleGirard1 = new Patient("Girard", "Isabelle", new DateTime(1960, 3, 30), "phoneNumber", "email@email.com", "Grenoble");
            Patient PIsabelleGirard2 = new Patient("Girard", "Isabelle", new DateTime(1960, 3, 30), "phoneNumber", "email@email.com", "Grenoble");
            Patient PIsabelleGirard3 = new Patient("Girard", "Isabelle", new DateTime(1960, 3, 30), "phoneNumber", "email@email.com", "Grenoble");

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
            hospital3.AddPatient(PIsabelleGirard3);

            // Patients' medical files
            MedicalFile FJeanneDupont1 = new MedicalFile(PJeanneDupont1);
            MedicalFile FJeanneDupont2 = new MedicalFile(PJeanneDupont2);
            MedicalFile FJeanneDupont3 = new MedicalFile(PJeanneDupont3);
            MedicalFile FPierreDurand1 = new MedicalFile(PPierreDurand1);
            MedicalFile FPierreDurand2 = new MedicalFile(PPierreDurand2);
            MedicalFile FPierreDurand3 = new MedicalFile(PPierreDurand3);
            MedicalFile FMarieBernard1 = new MedicalFile(PMarieBernard1);
            MedicalFile FMarieBernard2 = new MedicalFile(PMarieBernard2);
            MedicalFile FMarieBernard3 = new MedicalFile(PMarieBernard3);
            MedicalFile FJacquesPetit1 = new MedicalFile(PJacquesPetit1);
            MedicalFile FJacquesPetit2 = new MedicalFile(PJacquesPetit2);
            MedicalFile FJacquesPetit3 = new MedicalFile(PJacquesPetit3);
            MedicalFile FSophieLemaire1 = new MedicalFile(PSophieLemaire1);
            MedicalFile FSophieLemaire2 = new MedicalFile(PSophieLemaire2);
            MedicalFile FSophieLemaire3 = new MedicalFile(PSophieLemaire3);
            MedicalFile FDanielleRobert1 = new MedicalFile(PDanielleRobert1);
            MedicalFile FDanielleRobert2 = new MedicalFile(PDanielleRobert2);
            MedicalFile FDanielleRobert3 = new MedicalFile(PDanielleRobert3);
            MedicalFile FMichelLacroix1 = new MedicalFile(PMichelLacroix1);
            MedicalFile FMichelLacroix2 = new MedicalFile(PMichelLacroix2);
            MedicalFile FMichelLacroix3 = new MedicalFile(PMichelLacroix3);
            MedicalFile FNathalieSimon1 = new MedicalFile(PNathalieSimon1);
            MedicalFile FNathalieSimon2 = new MedicalFile(PNathalieSimon2);
            MedicalFile FNathalieSimon3 = new MedicalFile(PNathalieSimon3);
            MedicalFile FBernardMorel1 = new MedicalFile(PBernardMorel1);
            MedicalFile FBernardMorel2 = new MedicalFile(PBernardMorel2);
            MedicalFile FBernardMorel3 = new MedicalFile(PBernardMorel3);
            MedicalFile FIsabelleGirard1 = new MedicalFile(PIsabelleGirard1);
            MedicalFile FIsabelleGirard2 = new MedicalFile(PIsabelleGirard2);
            MedicalFile FIsabelleGirard3 = new MedicalFile(PIsabelleGirard3);

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
            hospital3.AddFile(FIsabelleGirard3);

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
            FIsabelleGirard3.AddDoctorInCharge(DLauraMorel1);

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


            DataManager<BreastCancerData, BreastCancerMap> dataManager = new DataManager<BreastCancerData, BreastCancerMap>("BreastCancer");
            Console.WriteLine("Breast Cancer train count: " + dataManager.GetTrainData().Count);
            Console.WriteLine("Breast Cancer test count: " + dataManager.GetTestData().Count);
            Console.WriteLine("Breast Cancer samples count: " + dataManager.GetSamplesData().Count);
            Console.WriteLine();

            List<string[]> values = new List<string[]>();
            foreach (BreastCancerData data in dataManager.GetSamplesData())
            {
                values.Add(data.Values());
            }
            List<string> labels = new List<string>(dataManager.GetSamplesData()[0].Labels());

            Console.WriteLine("Labels: " + string.Join(", ", labels));
            Console.WriteLine("Most common result: " + Metrics.MostCommonResult(values));
            Console.WriteLine("Is discretizable (index=0): " + Metrics.IsDiscretizable(values, 0));
            Console.WriteLine("Is discretizable (result): " + Metrics.IsDiscretizable(values, labels.Count - 1));
            Console.WriteLine("Different values (result): " + string.Join(", ", Metrics.DifferentValues(values, labels.Count - 1)));
            Console.WriteLine("Subset discrete (result, True): " + Metrics.SubsetDiscrete(values, labels.Count - 1, "True").Count);
            Console.WriteLine("Subset higher than pivot (index=0, value=12.5): " + Metrics.SubsetPivot(values, 0, 12.5).Count);
            Console.WriteLine("Gain ratio (index=0): " + Metrics.GainRatioPivot(values, 0, out double pivot) + ", " + pivot);
            Console.WriteLine();
            Console.WriteLine();

            DecisionTree decisionTree = new DecisionTree(IllnessTypes.BreastCancer);
            Console.WriteLine("Best label: " + decisionTree.BestLabel(values, labels, out double pivotBest) + ", pivot = " + pivotBest);
            Console.WriteLine();

            Console.WriteLine("Labels: " + string.Join(", ", labels));
            Console.WriteLine("Values[0]: " + string.Join(", ", values[0]));
            Console.WriteLine("Remove PerimeterWorst (2)");
            int indexToRemove = labels.FindIndex(label => label.Equals("PerimeterWorst"));
            labels.RemoveAt(indexToRemove);
            for (int i = 0; i < values.Count; i++)
            {
                string[] value = values[i];
                string[] strings = new string[value.Length - 1];
                for (int j = 0; j < value.Length; j++)
                {
                    if (j < indexToRemove) strings[j] = value[j];
                    else if (j > indexToRemove) strings[j - 1] = value[j];
                }
                values[i] = strings;
            }
            Console.WriteLine("Labels: " + string.Join(", ", labels));
            Console.WriteLine("Values[0]: " + string.Join(", ", values[0]));
            Console.WriteLine();
            Console.WriteLine();

            Node nodeOutlook = new Node("Outlook");
            Node nodeHumidity = new Node("Humidity");
            Node nodeWind = new Node("Wind");
            Node nodeYes = new Node("Result", "Yes");
            Node nodeNo = new Node("Result", "No");
            nodeOutlook.AddChild("Sunny", nodeHumidity);
            nodeOutlook.AddChild("Overcast", nodeYes);
            nodeOutlook.AddChild("Rain", nodeWind);
            nodeHumidity.AddChild("High", nodeNo);
            nodeHumidity.AddChild("Normal", nodeYes);
            nodeWind.AddChild("Strong", nodeNo);
            nodeWind.AddChild("Weak", nodeYes);
            Console.WriteLine(nodeOutlook.ToString());
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
