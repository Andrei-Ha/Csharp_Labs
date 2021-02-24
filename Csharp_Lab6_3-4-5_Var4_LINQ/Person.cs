using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Lab6_3_4_5_Var4_LINQ
{
    class Person
    {
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public Company Company { get; set; }
        // конструкторы
        public Person() : this("noname", new Company("noname",1900)) { }
        public Person(string name, Company company) : this(name, 1900, "noposition", 0, company) { }
        public Person(string name, int year, string position, int salary, Company company)
        {
            Name = name;
            YearOfBirth = year;
            Position = position;
            Salary = salary;
            Company = company;
        }
        public void Info()
        {
            Console.WriteLine($"Name:{Name} Company:{Company.Name}");
        }
    }

}
