using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp_Lab5_Var4_ConsoleApp;

namespace Csharp_Lab6_2_Var4_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Printer> queue = new Queue<Printer>();
            queue.Enqueue(new Printer("Canon"));
            queue.Enqueue(new Multifunction("Xerox"));
            queue.Enqueue(new Multifunction("Samsung"));
            queue.Enqueue(new Printer("Epson"));
            queue.Enqueue(new Multifunction("Kyocera"));
            queue.Enqueue(new Multifunction("Xerox"));
            queue.Enqueue(new Printer("HPLaserJet"));
            while (true)
            {
                Console.WriteLine("****************************");
                Console.WriteLine("*     Главное меню         *");
                Console.WriteLine("****************************");
                Console.WriteLine("1 – просмотр коллекции");
                Console.WriteLine("2 – добавление элемента в конец очереди");
                Console.WriteLine("3 – просмотр первого элемента в очереди");
                Console.WriteLine("4 – извлечение первого элемента из очереди");
                Console.WriteLine("5 – количество элементов в очереди");
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
                    case 1: method1(queue); break;
                    case 2: method2(queue); break;
                    case 3: method3(queue); break;
                    case 4: method4(queue); break;
                    case 5: method5(queue); break;
                    default: return;
                }

            }
        }
        static void method1(Queue<Printer> printers) // просмотр коллекции
        {
            Console.WriteLine("просмотр коллекции\n----------------------");
            foreach (Printer printer in printers)
                printer.Info();
            Console.ReadKey();
        }
        static void method2(Queue<Printer> printers) 
        {
            Console.WriteLine("добавление элемента в конец очереди\n----------------------");
            Console.WriteLine("Выберите какой элемент вы хотите добавить! 1- Принтер; 2 - МФУ");
            int otvet;
            if (Int32.TryParse(Console.ReadLine(), out otvet)) { }
            if (otvet < 1 || otvet > 2)
            {
                Console.WriteLine("Выбор элемента неверный!");
                return;
            }
            Console.WriteLine("Название:");
            string name = Console.ReadLine();
            Console.WriteLine("Содержимое буфера:");
            string buffer = Console.ReadLine();
            switch (otvet)
            {
                case 1:
                    printers.Enqueue(new Printer(name, buffer));
                    break;
                case 2:
                    printers.Enqueue(new Multifunction(name, buffer));
                    break;
                default:
                    return;
            }
            Console.WriteLine($"элемент с именем {name} добавлен в конец очереди!");
            Console.ReadKey();
        }
        static void method3(Queue<Printer> printers) 
        {
            Console.WriteLine("просмотр первого элемента в очереди\n----------------------");
            Console.Write("первый элемент - ");
            printers.Peek().Info();
            Console.ReadKey();
        }
        static void method4(Queue<Printer> printers) 
        {
            Console.WriteLine("извлечение первого элемента из очереди\n----------------------");
            Console.Write("извлекли первый элемент - ");
            printers.Dequeue().Info();
            Console.ReadKey();
        }
        static void method5(Queue<Printer> printers)
        {
            Console.WriteLine("количество элементов в очереди\n----------------------");
            Console.Write("количество = "+ printers.Count);
            Console.ReadKey();
        }

    }
}
