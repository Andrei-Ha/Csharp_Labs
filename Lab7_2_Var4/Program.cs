using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_2_Var4
{
    class Program
    {
        static void Main(string[] args)
        {
            Tbus tbus = new Tbus("Maz 54", 90, 56, "электро");
            Console.WriteLine("Вывод инфо о троллейбусе:");
            tbus.DisplayType();
            tbus.Move();
            Console.WriteLine(tbus.Info());
            Tbus.SaveClass("Tbus.txt");     // сохранили в файл информацию о классе
            Console.WriteLine("Сохранили информацию о классе");
            tbus.SaveObject("tbus.bin");        // сохранили в файл информацию об объекте
            Console.WriteLine("Сохранили информацию об объекте");
            tbus.Model = "Liaz";
            tbus.Seats = 100;             // изменили объект
            Console.WriteLine("Изменили параметры троллейбуса:");
            Console.WriteLine(tbus.Info());                   // вывели информацию о троллейбусе
            tbus = Tbus.LoadObject("tbus.bin"); // прочитали объект
            Console.WriteLine("Прочитали сохраненные значения экземпляра троллейбуса");
            Console.WriteLine(tbus.Info());                   // вывели информацию о троллейбусе
            tbus.Serialize("tbus.dat");
            Console.WriteLine("Сериализовали экземпляр троллейбуса");
            tbus.Model = "Neoplan 3";
            tbus.Seats = 30;             // изменили объект
            Console.WriteLine("Изменили параметры троллейбуса:");
            Console.WriteLine(tbus.Info());                   // вывели информацию о троллейбусе
            tbus = Tbus.Deserialize("tbus.dat");
            Console.WriteLine("Десериализовали экземпляр троллейбуса:");
            Console.WriteLine(tbus.Info());                   // вывели информацию о троллейбусе
            Console.ReadKey();
        }
    }
}
