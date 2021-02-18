using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csharp_Lab4_Var4_ConsoleApp
{
    abstract public class Land : Transport
    {
        public string EngineType { get; set; }
        public Land(int maxspeed, int seats, string engineType) : base(maxspeed, seats)
        {
            EngineType = engineType;
        }
        public override void Move()
        {
            Console.WriteLine("Я еду по земле."); 
        }
        public void DisplayType()
        {
            Console.WriteLine("Я являюсь наземным транспортом");
        }
        public override string Info() // переопределение метода абстрактного родительского класса Transport
        {
            return $"тип двигателя:{EngineType};\n" + base.Info();
        }
    }
}