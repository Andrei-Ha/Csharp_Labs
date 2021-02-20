using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csharp_Lab5_Var4_ConsoleApp
{
    public class Multifunction : Printer, IScanning
    {
        public Multifunction() : this("noname") { }
        public Multifunction(string name) : base(name) { }
        public void Scan(string str)
        {
            Buffer = $"(отсканировано на МФУ) {str}";
        }
        public void Copy(string str)
        {
            Scan(str);
            Print();
        }
        public override void Message()
        {
            Console.WriteLine("Копия готова!");
        }
    }
}