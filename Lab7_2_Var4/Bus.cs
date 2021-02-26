using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp_Lab4_Var4_ConsoleApp;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab7_2_Var4
{
    // класс троллейбус наследуется от класса наземного транспорта из лабы №4
    [Serializable]
    public class Tbus : Land
    {
        public string Model { get; set; }
        public Tbus(string model, int maxspeed, int passenger, string typeEngine) : base(maxspeed, passenger, typeEngine)
        {
            Model = model;
        }
        public override void Move() // реализация абстрактного метода базового класса Transport
        {
            Console.WriteLine("Я еду по автодороге");
        }
        public new void DisplayType() // скрываем метод родительского класса Land
        {
            Console.WriteLine($"Я являюсь троллейбусом {Model}");
        }
        public override string Info() // переопределение метода абстрактного родительского класса Bus
        {
            return $"Название модели:{Model};" + base.Info();
        }
        //Добавьте статический метод, который запишет в текстовый файл всю информацию о типе вашего класса (рефлексия). Имя файла – параметр метода.
        public static void SaveClass(string filename)
        {
            Type t = typeof(Tbus);
            StreamWriter f = new StreamWriter(filename);
            f.WriteLine("Полное имя класса:" + t.FullName);
            if (t.IsAbstract) f.WriteLine("Абстрактный класс");
            if (t.IsClass) f.WriteLine("Обычный класс");
            if (t.IsInterface) f.WriteLine("Интерфейс");
            if (t.IsEnum) f.WriteLine("Перечисление");
            if (t.IsSealed) f.WriteLine("Закрыт для наследования");
            f.WriteLine("Базовый класс - " + t.BaseType);
            FieldInfo[] fields = t.GetFields();
            if (fields.Count() > 0)
                f.WriteLine("*** Поля класса: ***");
            foreach (var field in fields)
            {
                f.WriteLine(field);
            }
            PropertyInfo[] properties = t.GetProperties();
            if (properties.Count() > 0)
                f.WriteLine("*** Свойства класса: ***");
            foreach (var property in properties)
            {
                f.WriteLine(property);
            }
            MethodInfo[] methods = t.GetMethods();
            if (methods.Count() > 0)
                f.WriteLine("*** Методы класса: ***");
            foreach (var method in methods)
            {
                f.WriteLine(method);
            }
            f.Close();

        }
        // Добавьте экземплярный метод, который будет сохранять в бинарный файл всю информацию о текущем объекте. Имя файла – параметр метода.
        public void SaveObject(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(this.Model);
            bw.Write(this.MaxSpeed);
            bw.Write(this.Seats);
            bw.Write(this.EngineType);
            fs.Close();

        }
        // Метод, который будет читать информацию из бинарного файла и возвращать готовый объект. Имя файла – параметр метода.
        public static Tbus LoadObject(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            string model = br.ReadString();
            int speed = br.ReadInt32();
            int seats = br.ReadInt32();
            string engineType = br.ReadString();
            fs.Close();
            return new Tbus(model, speed, seats, engineType);

        }
        // Добавьте методы, которые сериализуют и десериализуют объекты вашего класса. Имя файла – параметр метода.
        public void Serialize(string filename)
        {
            Stream fs = new FileStream(filename, FileMode.Create);
            BinaryFormatter fmt = new BinaryFormatter();
            fmt.Serialize(fs, this);
            fs.Close();

        }
        public static Tbus Deserialize(string filename)
        {
            Stream fs = new FileStream(filename, FileMode.Open);
            BinaryFormatter fmt = new BinaryFormatter();
            Tbus tbus = (Tbus)fmt.Deserialize(fs);
            fs.Close();
            return tbus;

        }

    }
}
