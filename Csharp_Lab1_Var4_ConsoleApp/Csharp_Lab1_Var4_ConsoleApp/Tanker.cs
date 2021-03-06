using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Lab1_Var4_ConsoleApp
{
    class Tanker
    {
        // fields
        public readonly string name; // Название танкера
        private int volume; // Объём танка
        private static double speed = 1; // скорость заполнения танков одинакова для всего класса
        private int[] tanks; // массив заполненности танков
        
        // properties
        public int Volume
        {
            get { return volume; }
            set { volume = Math.Abs(value); }
        }
        public static double Speed
        {
            get { return speed; }
            set { speed = Math.Abs(value); }
        }
        public int[] Tanks
        {
            get { return tanks; }
            set
            {
                int length = value.Length;
                if (length % 2 != 0) length--; // делаем массив четным обрезая последний элемент
                tanks = new int[length];
                for(int i =0; i<length; i++)  // проверка массива. заполненность не может быть отрицательной либо больше объёма танка
                {
                    tanks[i] = value[i] > volume ? volume : Math.Abs(value[i]);
                }
            }
        }

        // constructors
        public Tanker() : this("No_name_Tanker") { }
        public Tanker(string name) : this(name, 10) { }
        public Tanker(string name, int volume):this(name,volume,new int [] { 0, 0 }) { }
        public Tanker(string name, int volume, int[] tanks) {
            this.name = name;
            this.Volume = volume;
            this.Tanks = tanks;
        }

        // methods
        public override string ToString()
        {
            string arr = "["; // создание строки массива танков
            foreach (int tank in tanks)
            {
                arr += tank + ",";
            }
            arr = arr.Remove(arr.Length - 1) + "]";
            string str = $"танкер {name} | объём одного танка:{volume} | заполненность танков: {arr} | скорость заполнения: {speed}\n" +
                $"время наполнения: {this.FillingTime()}";
            if (!this.IsStable())
                str += "\n !!! один из бортов перегружен, есть вероятность опрокидывания!!!";
            return str + "\n----------------------------------------------------------";
        }
        public int FullVolume() // Полный объём всех танков
        {
            return this.volume * tanks.Length;
        }
        public double FillingTime() // время заполнения танкера
        {
            int free_volume = 0;
            foreach(int vol in tanks)
            {
                free_volume += this.volume - vol;
            }
            return free_volume / speed;
        }
        public bool IsStable() // определяем устойчивость танкера от переворачивания
        {
            int left_fill = 0, right_fill = 0;
            for(int i = 0; i < tanks.Length; i++)
            {
                if (i % 2 == 0)
                    left_fill += tanks[i]; // загрузка левого борта (нечетные танки)
                else
                    right_fill += tanks[i]; // загрузка правого борта (четные)
            }
            return Math.Abs(left_fill - right_fill) <= (left_fill+right_fill) / 2 ;
        }
        public bool IsBiggerThen(Tanker tanker)// метод возвращающий true, если текущий танкер больше загружен
        {
            return this.tanks.Sum() > tanker.tanks.Sum();
        }
        public static Tanker WhoIsBigger(Tanker t1, Tanker t2, Tanker t3) // возвращает танкер с наибольшей загрузкой
        {
            return new Tanker[] { t1, t2, t3 }.OrderBy(t => t.tanks.Sum()).Last();
        }
    }
}
