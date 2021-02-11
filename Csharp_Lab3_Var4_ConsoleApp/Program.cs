using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Lab3_Var4_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Tanker tankerPobeda = new Tanker("Победа", 1000, TypeCargo.oil);
            tankerPobeda.Info();
            Tanker tankerSibir = new Tanker("Сибирь", 800, TypeCargo.gas);
            tankerSibir.Info();
            Tanker tankerDerbent = new Tanker("Дербент", 1500, TypeCargo.chemical);
            tankerDerbent.Info();
            Port portBaltiiskii = new Port("Балтийский", 4);
            portBaltiiskii.Info();
            // Швартовка
            portBaltiiskii.MoorToTerminal(tankerSibir);
            portBaltiiskii.Info();
            tankerSibir.ToString();
            // Швартовка
            tankerDerbent.MoorRequest(portBaltiiskii);
            portBaltiiskii.Info();
            tankerDerbent.Info();
            tankerSibir.LeavePort(); // можно и так: portBaltiiskii.ReleaseTerminal(tankerSibir)
            portBaltiiskii.Info();
            tankerSibir.Info();
            tankerPobeda.MoorRequest(portBaltiiskii);
            portBaltiiskii.Info();
            tankerPobeda.Info();

            Console.ReadLine();
        }
    }
}
