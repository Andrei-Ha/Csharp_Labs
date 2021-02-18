using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csharp_Lab4_Var4_ConsoleApp
{
    public class Plane : Air
    {
        public Plane(int maxspeed, int passengers) : base(maxspeed, passengers) { }
    }
}