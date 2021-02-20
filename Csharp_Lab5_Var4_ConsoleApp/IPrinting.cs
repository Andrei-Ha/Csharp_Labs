using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csharp_Lab5_Var4_ConsoleApp
{
    public interface IPrinting : IDevice
    {
        void Print();
        void Message();
    }

}