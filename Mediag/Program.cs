﻿using Mediag.DiagnosticDecision;
using Mediag.Medical;
using System;

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

            // Young patients
            //Patient PLucieMartin1 = new Patient("Martin", "Lucie", new DateTime(1998, 2, 12), "phoneNumber", "email@email.com", "Lyon");
            //Patient PMathieuDubois1 = new Patient("Dubois", "Mathieu", new DateTime(2002, 5, 7), "phoneNumber", "email@email.com", "Paris");
            //Patient PClaraLeroy1 = new Patient("Leroy", "Clara", new DateTime(1995, 9, 21), "phoneNumber", "email@email.com", "Bordeaux");
            //Patient PAntoineLefevre1 = new Patient("Lefèvre", "Antoine", new DateTime(2001, 3, 14), "phoneNumber", "email@email.com", "Nantes");
            //Patient PJulieMoreau1 = new Patient("Moreau", "Julie", new DateTime(1997, 8, 18), "phoneNumber", "email@email.com", "Toulouse");

            // Old patients
            Patient PJeanneDupont1 = new Patient("Dupont", "Jeanne", new DateTime(1954, 1, 4), "phoneNumber", "email@email.com", "Marseille");
            Patient PPierreDurand1 = new Patient("Durand", "Pierre", new DateTime(1962, 10, 9), "phoneNumber", "email@email.com", "Strasbourg");
            Patient PMarieBernard1 = new Patient("Bernard", "Marie", new DateTime(1957, 4, 15), "phoneNumber", "email@email.com", "Lille");
            Patient PJacquesPetit1 = new Patient("Petit", "Jacques", new DateTime(1965, 7, 22), "phoneNumber", "email@email.com", "Nice");
            Patient PSophieLemaire1 = new Patient("Lemaire", "Sophie", new DateTime(1959, 12, 27), "phoneNumber", "email@email.com", "Rennes");
            Patient PDanielleRobert1 = new Patient("Robert", "Danielle", new DateTime(1956, 6, 3), "phoneNumber", "email@email.com", "Montpellier");
            Patient PMichelLacroix1 = new Patient("Lacroix", "Michel", new DateTime(1963, 11, 11), "phoneNumber", "email@email.com", "Reims");
            Patient PNathalieSimon1 = new Patient("Simon", "Nathalie", new DateTime(1958, 2, 19), "phoneNumber", "email@email.com", "Dijon");
            Patient PBernardMorel1 = new Patient("Morel", "Bernard", new DateTime(1967, 8, 25), "phoneNumber", "email@email.com", "Tours");
            Patient PIsabelleGirard1 = new Patient("Girard", "Isabelle", new DateTime(1960, 3, 30), "phoneNumber", "email@email.com", "Grenoble");

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


            // Display some fake data
            Console.WriteLine("Some hospitals:");
            Console.WriteLine(hospital1.ToString());
            Console.WriteLine(hospital2.ToString());
            Console.WriteLine(hospital3.ToString());
            Console.WriteLine();
            Console.WriteLine("Some patients:");
            Console.WriteLine(PJeanneDupont1.ToString());
            Console.WriteLine(PPierreDurand1.ToString());
            Console.WriteLine(PMarieBernard1.ToString());
            Console.WriteLine();
            Console.WriteLine("Some doctors:");
            Console.WriteLine(DThomasRichard1.ToString());
            Console.WriteLine(DAnneMarieLeroux1.ToString());
            Console.WriteLine(DSebastienRoux1.ToString());
            Console.WriteLine();


            //DecisionTree decisionTree = new DecisionTree();
            //Console.WriteLine(decisionTree.ToString());
        }
    }
}
