using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Lab1_Var4_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Tanker.Speed = 2.3;
            Tanker NoName = new Tanker();
            Console.WriteLine(NoName.ToString());
            Tanker Avrora = new Tanker("Aurora", 20, new int[] { 30, 10, 5, 17, 10, 10, -23 });
            Console.WriteLine(Avrora.ToString());
            Tanker Titanik = new Tanker("Titanik", 50);
            //Titanik.Tanks = new int[] { 5, 1, 7, 3, 9 };
            Titanik.Tanks = new int[] { 45, 7, 31, 13 };
            Console.WriteLine(Titanik.ToString());
            Console.WriteLine($"Titanik is bigger than Avrora? - {Titanik.IsBiggerThen(Avrora)}");
            Console.WriteLine($"Больше всех загружен: {Tanker.WhoIsBigger(NoName, Titanik, Avrora).name}");
            Console.ReadKey();
        }
    }
}
