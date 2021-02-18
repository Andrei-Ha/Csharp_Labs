using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csharp_Lab4_Var4_ConsoleApp
{
    public class Bus : Land
    {
        public string Model { get; set; }
        public Bus(string model, int maxspeed, int passenger, string typeEngine) : base(maxspeed, passenger, typeEngine)
        {
            Model = model;
        }
        public override void Move() // реализация абстрактного метода базового класса Transport
        {
            Console.WriteLine("Я еду по автодороге");
        }
        public new void DisplayType() // скрываем метод родительского класса Land
        {
            Console.WriteLine($"Я являюсь автобусом {Model}");
        }
        public override string Info() // переопределение метода абстрактного родительского класса Bus
        {
            return $"Название модели:{Model};" + base.Info();
        }
    }
}