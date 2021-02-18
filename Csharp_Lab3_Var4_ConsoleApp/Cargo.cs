using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Lab3_Var4_ConsoleApp
{
    enum TypeCargo : int
    {
        oil,
        gas,
        chemical
    }
    class Cargo
    {
        public string Name { get; set; }
        public double Density { get; set; }
        public TypeCargo Type { get; }

        public Cargo(string name, TypeCargo type) : this(name, 1, type) { }
        public Cargo(string name, double density, TypeCargo type)
        {
            Name = name;
            Density = density;
            Type = type;
        }
        public void Info()
        {
            Console.WriteLine($" {Name} {Density} {Type}");
        }
    }
}
