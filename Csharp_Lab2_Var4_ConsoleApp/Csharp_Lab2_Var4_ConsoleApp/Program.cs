using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Lab2_Var4_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Quadratic first = new Quadratic(5, 3, 7);
            Console.WriteLine(first.ViewAndSolution());
            Quadratic second = new Quadratic(1, -6, 9);
            Console.WriteLine(second.ViewAndSolution());
            Quadratic third = new Quadratic(1, -8, 12);
            Console.WriteLine(third.ViewAndSolution());
            Console.ReadKey();
        }
    }
}
