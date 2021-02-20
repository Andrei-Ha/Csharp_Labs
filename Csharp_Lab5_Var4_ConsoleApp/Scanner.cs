using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csharp_Lab5_Var4_ConsoleApp
{
    public class Scanner : IScanning
    {
        public string Name { get; set; }
        public string Buffer { get; set; }
        public Scanner() : this("noname") { }
        public Scanner(string name)
        {
            Name = name;
        }
        public void Scan(string str)
        {
            Console.WriteLine($"сканер {Name} получил команду на сканирование.");
            Buffer = "(отсканировано сканером)" + str;
            Message();
        }
        public void Message()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("страница успешно отсканирована!\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}