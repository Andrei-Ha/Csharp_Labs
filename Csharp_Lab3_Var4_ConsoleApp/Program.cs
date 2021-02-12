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
            Cargo cargoOil = new Cargo("Сырая нефть", TypeCargo.oil);
            Cargo cargoGas = new Cargo("Природный газ", TypeCargo.gas);
            cargoGas.Info();
            Tanker tankerPobeda = new Tanker("Победа", 1000, TypeCargo.oil);
            tankerPobeda.Info();
            Tanker tankerSibir = new Tanker("Сибирь", 800, TypeCargo.gas);
            tankerSibir.Info();
            Tanker tankerDerbent = new Tanker("Дербент", 1500, TypeCargo.chemical);
            tankerDerbent.Info();
            Port portBaltiiskii = new Port("Балтийский", 4);
            portBaltiiskii.Info();
            Console.WriteLine("попытка загрузить в море");
            tankerSibir.TakeCargo(cargoOil); 
            // Швартовка
            portBaltiiskii.MoorToTerminal(tankerSibir);
            portBaltiiskii.Info();
            tankerSibir.Info();
            Console.WriteLine("попытка загрузить не подходящим типом груза");
            tankerSibir.TakeCargo(cargoOil);
            Console.WriteLine("погрузка газа");
            tankerSibir.TakeCargo(cargoGas);
            // Швартовка
            tankerDerbent.MoorRequest(portBaltiiskii);
            portBaltiiskii.Info();
            tankerDerbent.Info();
            tankerSibir.LeavePort(); // можно и так: portBaltiiskii.ReleaseTerminal(tankerSibir)
            portBaltiiskii.Info();
            tankerSibir.Info();
            tankerPobeda.MoorRequest(portBaltiiskii);
            portBaltiiskii.Info();
            Console.WriteLine("погрузка нефти");
            tankerPobeda.TakeCargo(cargoOil);
            portBaltiiskii.ReleaseTerminal(tankerPobeda); // освобождаем терминал
            tankerPobeda.Info();

            Port portChernomorskii = new Port("Черноморский", 2);
            portChernomorskii.MoorToTerminal(tankerPobeda);
            portChernomorskii.Info();
            tankerPobeda.Info();
            tankerPobeda.UnloadCargo();
            tankerPobeda.LeavePort();
            tankerPobeda.Info();

            Console.ReadLine();
        }
    }
}
