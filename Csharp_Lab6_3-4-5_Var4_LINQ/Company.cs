using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Lab6_3_4_5_Var4_LINQ
{
    class Company
    {
        public string Name { get; set; }
        public int YearOfFoundation { get; set; }
        public Company(string name, int year)
        {
            Name = name;
            YearOfFoundation = year;
        }
    }
}
