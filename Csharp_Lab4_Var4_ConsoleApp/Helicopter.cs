using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csharp_Lab4_Var4_ConsoleApp
{
    public class Helicopter : Air
    {
        public Helicopter(int maxspeed, int passengers) : base(maxspeed, passengers) { }
        // public override void Move() { }; Нельзя перегрузить метод Move т.к. он "запечатан"
    }
}