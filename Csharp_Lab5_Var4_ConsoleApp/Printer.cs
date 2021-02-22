using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csharp_Lab5_Var4_ConsoleApp
{
    public class Printer: IPrinting, IComparable
    {
        public string Name { get; set; }
        public string Buffer { get; set; }
        public Printer() : this("noname", "") { }
        public Printer(string name) : this(name, "") { }
        public Printer(string name, string buffer)
        {
            Name = name;
            Buffer = buffer;
        }
        public void Print()
        {
            Console.WriteLine($"На принтер {Name} отправлена страница:\n\t\"{Buffer}\"");
        }
        public virtual void Message()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Message: страница успешно напечатана!\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        // явное указание интерфейса (кастинг) 
        void IPrinting.Message()
        {
            Console.WriteLine("(кастинг)Message: страница успешно напечатана!\n");
        }
        public int CompareTo(object o)
        {
            return this.Name.CompareTo(((Printer)o).Name);
        }
        public void Info()
        {
            Console.WriteLine($"Название: {Name}; содержимое буфера:{Buffer}");
        }
    }
}