using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab7_1_Var4_Files
{
    class Program
    {
        static void CurrentDirDispl(DirectoryInfo curr)
        {
            Console.WriteLine($"-  -  -\nТекущая директория: \"{curr.FullName}\"\n-  -  -");
        }
        static void f1(ref DirectoryInfo d)
        {// установить текущий диск/каталог
            CurrentDirDispl(d);
            Console.WriteLine("---\nУстановите текущий диск/каталог:");
            string path = Console.ReadLine();
            DirectoryInfo newDirect = new DirectoryInfo(path);
            if (newDirect.Exists)
            {
                d = newDirect;
                CurrentDirDispl(d);
            }
            else
                Console.WriteLine("Вы ввели не верный путь!");
            Console.ReadKey();
        }
        static void f2(DirectoryInfo d)
        {// вывод списка всех каталогов в текущем (пронумерованный)
            CurrentDirDispl(d);
            Console.WriteLine("---\nвывод списка всех каталогов в текущем (пронумерованный):");
            int i = 0;
            foreach (DirectoryInfo directory in d.GetDirectories())
            {
                Console.WriteLine(i + ".) " + directory.Name);
                i++;
            }
            Console.ReadKey();
        }
        static void f3(DirectoryInfo d)
        {// вывод списка всех файлов в текущем каталоге (пронумерованнный)
            CurrentDirDispl(d);
            Console.WriteLine("---\nвывод списка всех файлов в текущем каталоге (пронумерованный):");
            int i = 0;
            foreach (FileInfo file in d.GetFiles())
            {
                Console.WriteLine(i + ".) " + file.Name);
                i++;
            }
            Console.ReadKey();
        }
        static void f4(DirectoryInfo d)
        {// вывод на экран содержимого указанного текстового файла (по номеру)
            CurrentDirDispl(d);
            f3(d);
            Console.WriteLine("---\nВведите номер файла:");
            int index;
            if (!Int32.TryParse(Console.ReadLine(), out index))
            {
                Console.WriteLine("Индекс неверен!");
                return;
            }
            FileInfo[] files = d.GetFiles();
            if (files[index].Extension != ".txt")
            {
                Console.WriteLine("Это не текстовый файл!");
                return;
            }
            StreamReader sr = new StreamReader(files[index].FullName);
            string str = sr.ReadToEnd();
            Console.WriteLine("содержимое файла:" + str);
            sr.Close();
            Console.ReadLine();
        }
        static void f5(DirectoryInfo d)
        {// создание каталога в текущем
            CurrentDirDispl(d);
            Console.WriteLine("---\nсоздание каталога в текущем");
            Console.WriteLine("Введите имя нового каталога:");
            string newFolder = Console.ReadLine();
            try
            {
                d.CreateSubdirectory(newFolder);
                Console.WriteLine($"Каталог с именем \"{newFolder}\" успешно создан!");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
        static void f6(DirectoryInfo d)
        {// удаление каталога по номеру, если он пустой
            CurrentDirDispl(d);
            f2(d);
            Console.WriteLine("---\nудаление каталога по номеру, если он пустой");
            Console.WriteLine("Введите имя номер каталога:");
            int index;
            if(!Int32.TryParse(Console.ReadLine(), out index))
            {
                Console.WriteLine("Индекс неверен!");
                return;
            }
            DirectoryInfo dirToDel = d.GetDirectories()[index];
            try
            {
                dirToDel.Delete();
                Console.WriteLine($"Пустой каталог \"{dirToDel.Name}\" удален!");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
        static void f7(DirectoryInfo d)
        {// удаление файлов с указанными номерами
            CurrentDirDispl(d);
            f3(d);
            Console.WriteLine("---\nудаление файлов с указанными номерами");
            Console.WriteLine("Введите номера первого и последнего файлов из диапазона для удаления:");
            int index1, index2;
            if(!Int32.TryParse(Console.ReadLine(),out index1) || !Int32.TryParse(Console.ReadLine(), out index2))
            {
                Console.WriteLine("неверные индексы!");
                return;
            }
            FileInfo[] files = d.GetFiles();
            if (index1 > index2 || index2 >= files.Length)
            {
                Console.WriteLine("неверные номера файлов");
                return;
            }
            for (int i = index1; i <= index2; i++)
                files[i].Delete();
            Console.WriteLine(index2 - index1 + 1 + " файлов удалено");
            Console.ReadKey();
            f3(d);
        }
        static void f8(DirectoryInfo d)
        {// вывод списка всех файлов с указанной датой создания (ищет в текущем каталоге и подкаталогах)
            CurrentDirDispl(d);
            Console.WriteLine("---\nвывод списка всех файлов с указанной датой создания (ищет в текущем каталоге и подкаталогах)");
            Console.WriteLine("Введите дату для поиска в формате dd.mm.yyyy :");
            string date = Console.ReadLine();
            DateTime dt;
            while (!DateTime.TryParseExact(date, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                Console.WriteLine("Неверный формат даты, попробуйте еще раз!");
                date = Console.ReadLine();
            }
            int i = 0;
            foreach(FileInfo file in d.GetFiles("*", SearchOption.AllDirectories))
            {
                if (file.CreationTime.Date == dt.Date)
                {
                    Console.WriteLine(file.FullName + "   " + file.CreationTime);
                    i++;
                }
            }
            if(i==0)
                Console.WriteLine("файлы с датой создания {0} не найдены",dt.ToString("dd.MM.yyyy"));
            Console.ReadKey();
        }
        static void f9(DirectoryInfo d)
        {// вывод списка всех текстовых файлов, в которых содержится указанный текст (ищет в текущем каталоге и подкаталогах)
            CurrentDirDispl(d);
            Console.WriteLine("---\nвывод списка всех текстовых файлов, в которых содержится указанный текст (ищет в текущем каталоге и подкаталогах))");
            Console.WriteLine("Введите текст для поиска в файлах");
            string str = Console.ReadLine();
            FileInfo[] files = d.GetFiles("*", SearchOption.AllDirectories);
            int i = 0;
            StreamReader sr;
            foreach (FileInfo x in files)
            {
                if (x.Extension != ".txt") continue;
                sr = new StreamReader(x.FullName);
                string buf = sr.ReadToEnd();
                sr.Close();
                if (buf.Contains(str))
                    Console.WriteLine(++i + ")" + x.DirectoryName + "\\" + x.Name);
            }
            if (i == 0)
                Console.WriteLine("файлы с текстом \"{0}\" не найдены", str);
            Console.ReadKey();
        }
        static void Main()
        {
            DirectoryInfo dir = new DirectoryInfo(@"D:\!!!!!");         // текущий каталог
            try
            {
                while (true)
                {
                    CurrentDirDispl(dir);
                    Console.WriteLine("****************************************************");
                    Console.WriteLine("*             Главное меню                         *");
                    Console.WriteLine("****************************************************");
                    Console.WriteLine("1 – установить текущий диск/каталог");
                    Console.WriteLine("2 – вывод списка всех каталогов в текущем");
                    Console.WriteLine("3 – вывод списка всех файлов в текущем каталоге");
                    Console.WriteLine("4 – вывод на экран содержимого указанного файла ");
                    Console.WriteLine("5 – создание каталога в текущем");
                    Console.WriteLine("6 – удаление каталога по номеру, если он пустой");
                    Console.WriteLine("7 – удаление файлов с указанными номерами");
                    Console.WriteLine("8 – вывод списка всех файлов с указанной датой создания");
                    Console.WriteLine("9 – вывод списка всех текстовых файлов, в которых текст");
                    Console.WriteLine("0 – выход");
                    Console.WriteLine("****************************************************");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            f1(ref dir);
                            break;
                        case 2:
                            f2(dir);
                            break;
                        case 3:
                            f3(dir);
                            break;
                        case 4:
                            f4(dir);
                            break;
                        case 5:
                            f5(dir);
                            break;
                        case 6:
                            f6(dir);
                            break;
                        case 7:
                            f7(dir);
                            break;
                        case 8:
                            f8(dir);
                            break;
                        case 9:
                            f9(dir);
                            break;
                        case 0: return;
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Неверное имя файла");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Неверное имя каталога");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка " + e.Message);
            }
        }

    }
}
