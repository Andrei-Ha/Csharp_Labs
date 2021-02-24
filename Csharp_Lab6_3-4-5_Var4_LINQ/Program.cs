using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp_Lab5_Var4_ConsoleApp;

namespace Csharp_Lab6_3_4_5_Var4_LINQ
{
    class Program
    {
        // 3. Обобщенный метод
        static int QuantityNull<T>(T[] array)
        {
            int result = 0;
            foreach (T elem in array)
                if (elem != null)
                    result++;
            return result;
        }
        static void Main(string[] args)
        {
            // 3. Обобщенный метод
            Printer[] printers = new Printer[]
            {
                new Printer("Kyocera","qwerty"),
                null,
                new Multifunction("Xerox", "yesterday"),
                null,
                new Printer("Samsung","good morning"),
                new Printer("Epson","bye"),
                new Multifunction("Canon", "togetho"),
                null
            };
            Console.WriteLine("! обобщенный метод, который получает массив элементов типа Printer и возвращает количество элементов, не равных null");
            Console.WriteLine($"количество элементов массива = {printers.Length} из них {QuantityNull<Printer>(printers)} не равны null\n");

            // 4. LINQ с массивом (4-вариант. Найти среднее значение среди отрицательных чисел.)
            int[] array = new int[30];
            Random random = new Random();
            Console.WriteLine("значения массива:");
            for (int i=0;i<array.Length;i++)
            {
                array[i] = random.Next(-99, 99);
                Console.Write(array[i] + " ");
            }
            var avg = (from a in array where a < 0 select a).Average();
            Console.WriteLine($"\n\n(LINQ)среднее значение среди отрицательных = {avg.ToString()}");
            string average = array.Where(p => (p < 0)).Average().ToString();
            Console.WriteLine($"\n(Метод расширения LINQ)среднее значение среди отрицательных = {average}");
            // 5. LINQ с коллекцией
            // Создайте коллекцию объектов класса Person. Используемые поля – имя, год рождения, должность, оклад, компания (Company). Класс Company содержит название компании и год основания. Получите новую коллекцию - список сотрудников, чье имя начинается с той же буквы, что и их компания. Включает имя сотрудника и имя компании.
            Console.WriteLine("\nLINQ с коллекцией");
            Company Microsoft = new Company("Майкрософт", 1976);
            Company Google = new Company("Гугл", 1998);
            List<Person> people = new List<Person>()
            {
                new Person("Андрей",Microsoft),
                new Person("Михаил",Microsoft),
                new Person("Вячеслав",Microsoft),
                new Person("Григорий",Google),
                new Person("Виктор",Google),
                new Person("Глеб",Google)
            };
            Console.WriteLine("Коллекция people:");
            foreach (Person p in people)
                p.Info();
            var peop = people.Where(p => p.Name.First() == p.Company.Name.First()).Select(o => new { Name = o.Name, Company = o.Company.Name });
            Console.WriteLine("\nНовая коллекция - список сотрудников, чье имя начинается с той же буквы, что и их компания.\nВключает имя сотрудника и имя компании:");
            foreach (var pers in peop)
                Console.WriteLine($"Имя:{pers.Name} Компания:{pers.Company}");
            Console.ReadKey();
        }
    }
}
