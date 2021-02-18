using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csharp_Lab4_Var4_ConsoleApp
{
    public class Water : Transport
    {
        public Water() { }
        public override void Move()
        {
            Console.WriteLine("Я плыву по воде");
        }
    }
}