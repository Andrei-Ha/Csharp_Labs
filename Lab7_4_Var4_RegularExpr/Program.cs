using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab7_4_Var4_RegularExpr
{
    class Program
    {
        static void Main(string[] args)
        {
            //4.Проект4(по вариантам)
            //Напишите регулярное выражение и найдите все совпадения в блоке текста.
            //Вывести все найденные совпадение. 4-вариант. Поиск корректного времени 13:45:35 - корректно 99:66:77 - некорректно

            string data = "45:78:99sd dffds gfds12:12:12 ggggsd789:12:80 fsa23:59:59df25:59:59fds fdfsdf 22:60:45ds.kjhj 23:00:0024:00:00";
            while (true)
            {
                Console.WriteLine("---  Поиск корректного времени в формате HH24:MM:SS  ---");
                Console.WriteLine("Блок текста:\n" + data);
                Regex regex = new Regex(@"([01]\d|2[0-3]):[0-5]\d:[0-5]\d");
                MatchCollection matchCollection = regex.Matches(data);
                Console.WriteLine("***\nВсе найденные совпадения корректного времени:");
                foreach (Match m in matchCollection)
                {
                    Console.WriteLine(m.Value);
                }
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("Введите строку для добавления в конец имеющегося блока текста (для выхода - 0):");
                string newstring = Console.ReadLine();
                if (newstring.Length == 1)
                {
                    int quit;
                    if (Int32.TryParse(newstring, out quit))
                        if (quit == 0)
                            return;
                }
                data += newstring;
            }
        }        
    }
}
