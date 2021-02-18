using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csharp_Lab4_Var4_ConsoleApp
{
    public class Train : Land
    {
        public Train(int maxspeed, int passengers, string typeEngine) : base(maxspeed, passengers, typeEngine) { }
        public override void Move()
        {
            Console.WriteLine("Я еду по железной дороге");
        }
    }
}