using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_Var4_Delegate_Events
{
    class EventHandler1
    {
        public void DisplayRedMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Экземплярный метод: " + message);
            Console.ResetColor();
        }
    }
    class EventHandler2
    {
        public static void DisplayGreenMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Статический метод: " + message);
            Console.ResetColor();
        }
    }
}
