using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp_Lab5_Var4_ConsoleApp; // добавим ссылку на предыдущюю лабу

namespace Csharp_Lab6_Var4_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList()
            {
                new Printer("Canon"),
                new Multifunction("Xerox","xxx"),
                new Multifunction("Samsung","sss"),
                new Printer("Epson"),
                new Multifunction("Kyocera","kkk"),
                new Printer("Xerox","XOX"),
                new Printer("HPLaserJet")
            };
            while (true)
            {
                Console.WriteLine("****************************");
                Console.WriteLine("*     Главное меню         *");
                Console.WriteLine("****************************");
                Console.WriteLine("1 – просмотр коллекции");
                Console.WriteLine("2 – добавление элемента");
                Console.WriteLine("3 – добавление элемента по указанному индексу");
                Console.WriteLine("4 – нахождение элемента с начала коллекции");
                Console.WriteLine("5 – нахождение элемента с конца коллекции");
                Console.WriteLine("6 – удаление элемента по индексу");
                Console.WriteLine("7 – удаление элемента по значению");
                Console.WriteLine("8 – реверс коллекции");
                Console.WriteLine("9 – сортировка");
                Console.WriteLine("10 – выполнение методов всех объектов, поддерживающих интерфейс IScanning");
                Console.WriteLine("0 – выход");
                Console.WriteLine("****************************");
                int otvet;
                if (!Int32.TryParse(Console.ReadLine(), out otvet))
                {
                    Console.WriteLine("Введите верное значение! Выход - 0");
                    continue;
                }
                switch (otvet)
                {
                    case 1: method1(arrayList); break;
                    case 2: method2(arrayList); break;
                    case 3: method3(arrayList); break;
                    case 4: method4(arrayList); break;
                    case 5: method5(arrayList); break;
                    case 6: method6(arrayList); break;
                    case 7: method7(arrayList); break;
                    case 8: method8(arrayList); break;
                    case 9: method9(arrayList); break;
                    case 10: method10(arrayList); break;
                    default: return;
                }

            }
        }
        static void method1(ArrayList arrayList) // просмотр коллекции
        {
            Console.WriteLine("просмотр коллекции\n----------------------");
            for(int i =0;i<arrayList.Count;i++)
            {
                Console.Write($"{i} "); // вывод индекса элемента
                (arrayList[i] as Printer)?.Info();
            }
            Console.ReadKey();
        }
        static void DataEl(out string name,out string buffer)
        {
            Console.WriteLine("Название:");
            name = Console.ReadLine();
            Console.WriteLine("Содержимое буфера:");
            buffer = Console.ReadLine();
        }
        static void method2(ArrayList arrayList)
        {
            Console.WriteLine("добавление элемента\n----------------------");
            Console.WriteLine("Выберите какой элемент вы хотите добавить! 1- Принтер; 2 - МФУ");
            int otvet;
            if (Int32.TryParse(Console.ReadLine(), out otvet)) { }
            if (otvet < 1 || otvet > 2)
            {
                Console.WriteLine("Выбор элемента неверный!");
                return;
            }
            string name, buffer;
            DataEl(out name,out buffer);
            switch (otvet){
                case 1:
                    arrayList.Add(new Printer(name, buffer));
                    break;
                case 2:
                    arrayList.Add(new Multifunction(name, buffer));
                    break;
                default:return;
            }
            Console.WriteLine("элемент добавлен!");
            Console.ReadKey();
        }
        static void method3(ArrayList arrayList)
        {
            Console.WriteLine("добавление элемента по указанному индексу\n----------------------");
            Console.WriteLine("введите индекс:");
            int idx;
            if(Int32.TryParse(Console.ReadLine(),out idx)) { }
            if(idx<0 || idx > arrayList.Count)
            {
                Console.WriteLine("Неверный индекс!");
                return;
            }
            Console.WriteLine("Выберите какой элемент вы хотите добавить! 1- Принтер; 2 - МФУ");
            int otvet;
            if (Int32.TryParse(Console.ReadLine(), out otvet)) { }
            if (otvet < 1 || otvet > 2)
            {
                Console.WriteLine("Выбор элемента неверный!");
                return;
            }
            string name, buffer;
            DataEl(out name, out buffer);
            switch (otvet)
            {
                case 1:
                    arrayList.Insert(idx,new Printer(name, buffer));
                    break;
                case 2:
                    arrayList.Insert(idx,new Multifunction(name, buffer));
                    break;
                default: return;
            }
            Console.WriteLine($"элемент добавлен по индексу {idx}!");
            Console.ReadKey();

        }
        static void method4(ArrayList arrayList)
        {
            Console.WriteLine("нахождение элемента с начала коллекции\n----------------------");
            Console.WriteLine("Name=");
            string name = Console.ReadLine();
            int idx = arrayList.IndexOf(new Printer(name));
            if (idx < 0)
                Console.WriteLine($"элемент с именем {name} не найден!");
            else
                Console.WriteLine($"первый элемент с начала коллекции с именем {name} имеет индекс {idx}!");
            Console.ReadKey();
        }
        static void method5(ArrayList arrayList)
        {
            Console.WriteLine("нахождение элемента с конца коллекции\n----------------------");
            Console.WriteLine("Name=");
            string name = Console.ReadLine();
            int idx = arrayList.LastIndexOf(new Printer(name));
            if (idx < 0)
                Console.WriteLine($"элемент с именем {name} не найден!");
            else
                Console.WriteLine($"первый элемент с конца коллекции с именем {name} имеет индекс {idx}!");
            Console.ReadKey();
        }
        static void method6(ArrayList arrayList)
        {
            Console.WriteLine("удаление элемента по индексу\n----------------------");
            Console.WriteLine("введите индекс:");
            int idx;
            if (Int32.TryParse(Console.ReadLine(), out idx)) { }
            if (idx < 0 || idx > arrayList.Count)
            {
                Console.WriteLine("Неверный индекс!");
                return;
            }
            arrayList.RemoveAt(idx);
            Console.WriteLine($"элемент по индексу {idx} удален!");
            Console.ReadKey();
        }
        static void method7(ArrayList arrayList)
        {
            Console.WriteLine("удаление элемента по значению\n----------------------");
            Console.WriteLine("Name:");
            string name;
            name = Console.ReadLine();
            Printer printer = new Printer(name);
            if (arrayList.IndexOf(printer) == -1)
            {
                Console.WriteLine("элемент с таким именем  не найден!");
                return;
            }
            arrayList.Remove(printer);
            Console.WriteLine($"элемент с именем {name} удален!");
            Console.ReadKey();
        }
        static void method8(ArrayList arrayList)
        {
            Console.WriteLine("реверс коллекции\n----------------------");
            arrayList.Reverse();
            Console.WriteLine("успех!");
            Console.ReadKey();
        }
        static void method9(ArrayList arrayList)
        {
            Console.WriteLine("сортировка\n----------------------");
            arrayList.Sort();
            Console.WriteLine("успех!");
            Console.ReadKey();
        }
        static void method10(ArrayList arrayList)
        {
            Console.WriteLine("выполнение методов всех объектов, поддерживающих интерфейс IScanning\n----------------------");
            foreach(object obj in arrayList)
            {
                if(obj is IScanning)
                {
                    Console.WriteLine(obj);
                    (obj as IScanning).Scan("string");
                }
            }
            Console.ReadKey();
        }
    }
}
