using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Lab5_Var4_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer hplaserjet = new Printer("HPLaserJet_1160");
            hplaserjet.Buffer = "Hello world";
            hplaserjet.Print();

            Scanner scanjet = new Scanner("HPScanJet_2400");
            scanjet.Scan("Lorem ipsum dolor sit amet, consectetur adipiscing elit...");

            Multifunction canon410 = new Multifunction("CanonMF410");
            canon410.Copy("В целом, конечно, консультация с широким активом однозначно...");
            Console.ReadKey();
        }
    }
}
