using Mediag.DiagnosticDecision;
using Mediag.Medical;
using System;

namespace Mediag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital1 = new Hospital("Hôpital général de Montréal", "Montréal");
            Hospital hospital2 = new Hospital("Hôpital Charles-Le Moyne", "Greenfield Park");
            Hospital hospital3 = new Hospital("Hôtel-Dieu d'Arthabaska", "Victoriaville");
            Hospital hospital4 = new Hospital("Hôpital Honoré-Mercier", "Saint-Hyacinthe");
            Hospital hospital5 = new Hospital("Hôpital Brome-Missisquoi-Perkins (BMP)", "Cowansville");
            Hospital hospital6 = new Hospital("Centre gériatrique Maimonides Donald Berman", "Côte-Saint-Luc");
            Hospital hospital7 = new Hospital("Hôppital de Granby", "Granby");
            Hospital hospital8 = new Hospital("Hôpital Sainte-Anne-de-Beaupré", "Beaupré");
            Hospital hospital9 = new Hospital("Centre hospitalier de l'Université de Montréal (CHUM)", "Montréal");
            Hospital hospital10 = new Hospital("Hôpital de La Malbaie", "La Malbaie");

            Console.WriteLine(hospital1.ToString());
            Console.WriteLine(hospital2.ToString());
            Console.WriteLine(hospital3.ToString());
            Console.WriteLine(hospital4.ToString());
            Console.WriteLine(hospital5.ToString());
            Console.WriteLine(hospital6.ToString());
            Console.WriteLine(hospital7.ToString());
            Console.WriteLine(hospital8.ToString());
            Console.WriteLine(hospital9.ToString());
            Console.WriteLine(hospital10.ToString());
            Console.WriteLine();


            DecisionTree decisionTree = new DecisionTree();
            Console.WriteLine(decisionTree.ToString());
        }
    }
}
