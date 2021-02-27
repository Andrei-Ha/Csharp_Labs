using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_3_Var4
{
    class Program
    {
        //Проект3
        public static void f1(ref StringBuilder builder)
        {
            Console.WriteLine("Введите строку:");
            builder = new StringBuilder(Console.ReadLine());
            Console.WriteLine("Задайте емкость буфера:");
            int capacity;
            if (!Int32.TryParse(Console.ReadLine(), out capacity))
                return;
            builder.EnsureCapacity(capacity);
        }
        public static void f2(ref StringBuilder builder)
        {
            Console.WriteLine(builder + "\nемкость буфера:" + builder.Capacity);
            Console.WriteLine("----------------------------------------------------");
        }
        public static void f3(ref StringBuilder b)
        {
            Console.WriteLine("Вставить символ \"*\" после символа:");
            char ch;
            if(!char.TryParse(Console.ReadLine(),out ch))
            {
                Console.WriteLine("Неверный символ!");
                return;
            }
            b.Replace(ch.ToString(), ch + "*");
        }
        public static void f4(ref StringBuilder b)
        {
            Console.WriteLine("Заменить символ:");
            char ch1;
            if (!char.TryParse(Console.ReadLine(), out ch1))
            {
                Console.WriteLine("Неверный символ!");
                return;
            }
            char ch2;
            if (!char.TryParse(Console.ReadLine(), out ch2))
            {
                Console.WriteLine("Неверный символ!");
                return;
            }
            b.Replace(ch1, ch2);
        }
        public static void f5(ref StringBuilder b)
        {
            Console.WriteLine("Удалить все вхождения подстроки:");
            b.Replace(Console.ReadLine(),"");
        }
        static void Main(string[] args)
        {
            StringBuilder strBuilder = new StringBuilder(0);
            while (true)
            {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("|               Меню                               |");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("1 – ввод строки с клавиатуры(указывать размер)");
                Console.WriteLine("2 – вывод строки");
                Console.WriteLine("3 – после указанного символа каждый раз вставить *");
                Console.WriteLine("4 – заменить один символ на другой");
                Console.WriteLine("5 – удалить все вхождения указанной подстроки");
                Console.WriteLine("0 - выход");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("текущее значение:");
                f2(ref strBuilder);
                int choise;
                Console.WriteLine("Ваш выбор:");
                if (!Int32.TryParse(Console.ReadLine(), out choise)) {
                    Console.WriteLine("Неверный выбор!");
                    continue;
                }
                switch (choise)
                {
                    case 1: f1(ref strBuilder);break;
                    case 2: f2(ref strBuilder); break;
                    case 3: f3(ref strBuilder); break;
                    case 4: f4(ref strBuilder); break;
                    case 5: f5(ref strBuilder); break;
                    case 6: return;
                    default:return;
                }
            }
        }
    }
}
