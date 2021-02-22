using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Lab5_Var4_ConsoleApp
{
    class ComparerByPrinterName:IComparer<Printer>
    {
        public int Compare(Printer p1, Printer p2)
        {
            return p1.Name.CompareTo(p2.Name);
        }

    }
    class ComparerByPrinterBuffer:IComparer<Printer>
    {
        public int Compare(Printer p1, Printer p2)
        {
            return p1.Buffer.CompareTo(p2.Buffer);
        }
    }
}
