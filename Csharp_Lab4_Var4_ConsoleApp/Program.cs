using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Lab4_Var4_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лайнер:");
            Transport titanik = new CruiseShip(); // создаем новый объект транспорта, который использует конструктор базового класса без параметров
            titanik.Move();
            Console.WriteLine("Информация о titanik - " + titanik.Info());

            Console.WriteLine("\nВертолет:");
            Helicopter mi5 = new Helicopter(300, 15); 
            mi5.Move();
            Console.WriteLine("Информация о mi5 - " + mi5.Info());

            Console.WriteLine("\nПоезд:");
            Land shtadler = new Train(170, 500, "электрический");
            shtadler.Move();
            Console.WriteLine("Информация о shtadler - " + shtadler.Info());
            shtadler.DisplayType();

            Console.WriteLine("\nАвтобус:");
            Transport maz_base = new Bus("МАЗ 2257", 90, 48, "дизельный");
            maz_base.Move();
            Console.WriteLine("Информация о maz_base - " + maz_base.Info() + "\n"); //не смотря на то, что maz_base хранится в переменной типа Transport, для него будет вызываться перегруженый метод класса Bus!
            Land maz = (Land)maz_base;
            maz.DisplayType(); // => наземный транспорт; вызывается DisplayType() для класса Land 
            maz.Move();
            Console.WriteLine("Информация о maz - " + maz.Info() + "\n");
            Bus maz_new = (Bus)maz;
            maz_new.DisplayType(); // => Model:МАЗ 2257; вызывается  DisplayType() для класса Bus, т.к. родительский метод скрыт
            maz_new.IncreaseMaxSpeed(55);
            maz_new.Move();
            Console.WriteLine("Информация о maz_new - " + maz_new.Info() + "\n");
            
            Console.ReadKey();

        }
    }
}
