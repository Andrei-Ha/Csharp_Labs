using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csharp_Lab5_Var4_ConsoleApp
{
    public class Multifunction : Printer, IScanning
    {
        public Multifunction() : this("noname") { }
        public Multifunction(string name) : base(name) { }
        public Multifunction(string name, string buffer) : base(name)
        {
            Buffer = buffer;
        }
        public void Scan(string str)
        {
            Console.WriteLine("Сканирование...");
            Buffer = str;
        }
        public void Copy(string str)
        {
            Console.WriteLine("Получено задание на копирование...");
            Scan(str);
            ((IScanning)this).Message();
            Print();
            ((IPrinting)this).Message();
        }

        public override void Message() // Склеивание. перегружаем метод родительского класса Printer
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("(склеивание)Message: Копия готова!\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        // явное указание интерфейса (кастинг) 
        void IScanning.Message() {
            Console.WriteLine("(кастинг)Message: страница отсканирована!\n");
        }
        // применим обертывание
        public void ScanMessage()
        {
            ((IScanning)this).Message();
        }
        public void PrintMessage()
        {
            ((IPrinting)this).Message();
        }
    }
}