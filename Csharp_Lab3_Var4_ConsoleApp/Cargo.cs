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
        public float Density { get; set; }
    }
}
