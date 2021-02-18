using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csharp_Lab4_Var4_ConsoleApp
{
    abstract public class Air : Transport
    {
        public Air( int maxspeed, int passengers): base(maxspeed, passengers) { }
        public override sealed void Move() // перегружаем метод и закрываем его для дальнейшего наследования
        {
            Console.WriteLine("Я лечу над землей");
        }
    }
}