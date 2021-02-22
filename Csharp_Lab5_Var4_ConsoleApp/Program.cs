using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Lab5_Var4_ConsoleApp
{
    class Program
    {
        // именованный итератор (5 задание). Арифмитическая прогрессия с шагом 13
        static public IEnumerable MyIterator(int start,int end)
        {
            for(int i = start; i <= end; i++)
            {
                yield return (i-1) * 13;
            }
        }

        static void Main(string[] args)
        {
             
            Console.WriteLine("2. Коллизия имен\n");
            Scanner scanjet = new Scanner("HPScanJet_2400");
            scanjet.Scan("В целом, конечно, консультация с широким активом однозначно...");
            scanjet.Message();
            Console.WriteLine("Cодержимое буфера:\n" + scanjet.Buffer + "\n");
            Console.WriteLine("***");
            Printer hplaserjet = new Printer("HPLaserJet_1160");
            hplaserjet.Buffer = "Hello world";
            hplaserjet.Print();
            hplaserjet.Message();
            Console.WriteLine("вызовем явно реализованный метод интерфейса IPrinting");
            ((IPrinting)hplaserjet).Message();
            Console.WriteLine("***");
            Multifunction canon410 = new Multifunction("CanonMF410");
            canon410.Copy("Lorem ipsum dolor sit amet, consectetur adipiscing elit...");
            canon410.Message();
            Console.WriteLine("Вызовем переименованные методы (кастинг + обертывание):");
            canon410.ScanMessage();
            canon410.PrintMessage();
            Console.WriteLine("***");
            Console.WriteLine("3. Работа с массивом"); 
            //инициализируем массив элементов типа IPrinter
            IPrinting[] devices = new IPrinting[]
            {
                new Printer("Kyocera","qwerty"),
                new Multifunction("Xerox", "yesterday"),
                new Printer("Samsung","good morning"),
                new Printer("Epson","bye"),
                new Multifunction("Canon", "togetho")
            };
            Console.WriteLine("для всех элементов, поддерживающих интерфейс IScanning вызовем метод Scan()\n");
            foreach (IPrinting device in devices)
                if (device is IScanning)
                {
                    IScanning scanner = (IScanning)device;
                    scanner.Scan("Hello, I can scan");
                    Console.WriteLine($"Содержимое буффера устройства {scanner.Name}:" + scanner.Buffer);
                    scanner.Message();
                }

            Console.WriteLine("4. Использование стандартных интерфейсов");
            Console.WriteLine("\nМассив до сортировки:");
            foreach (IPrinting dev in devices)
                ((Printer)dev).Info();
            Array.Sort(devices); // отсортируем наш массив по имени
            Console.WriteLine("\nМассив после сортировки:");
            foreach (IPrinting dev in devices)
                ((Printer)dev).Info();

            Printer[] printers = new Printer[5];
            for (int i = 0; i < devices.Length; i++)
                printers[i] = (Printer)devices[i];
            Console.WriteLine("\nОтсортируем используя компараторы.");
            Array.Sort(printers, new ComparerByPrinterBuffer());
            Console.WriteLine("\nМассив после сортировки по содержимому буфера:");
            foreach (Printer printer in printers)
                printer.Info();
            Array.Sort(printers,new ComparerByPrinterName()); // отсортируем наш массив по имени
            Console.WriteLine("\nМассив после сортировки по имени:");
            foreach (Printer printer in printers)
                printer.Info();
            Console.WriteLine("\n 5. создать класс с именованным итератором, который принимает 2 аргумента – start и end.");
            Console.WriteLine("Вариант 4. Вывод арифмитической прогрессии от start до end с шагом 13.");
            Console.WriteLine("Введите пределы.");
            Console.WriteLine("start = ");
            int start = int.Parse(Console.ReadLine());
            Console.WriteLine("end = ");
            int end = int.Parse(Console.ReadLine());
            Console.WriteLine("Прогрессия:");
            foreach (int a in MyIterator(start, end))
            {
                Console.WriteLine("\n"+ a.ToString());
            }
            Console.ReadKey();
        }
    }
}
