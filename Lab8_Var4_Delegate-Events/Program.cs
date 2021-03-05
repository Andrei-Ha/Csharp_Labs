using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_Var4_Delegate_Events
{
    class Program
    {
        static void DispMessage()
        {
            Console.WriteLine(" я - статический метод из класса Program");
        }
        static int MultipleFullnes(int f, int k)
        {
            return f * k;
        }
        static void Main(string[] args)
        {
            // 1. делегат без параметров
            // создадим экземпляр танкера
            Tanker myTanker = new Tanker("Победа", 100, new int[] { 50, 50, 70, 70, 100, 100 });
            // делегат принимает статический метод
            VoidDelegate vDelFromStatic = DispMessage;
            myTanker.RegisterVoidDelegate(vDelFromStatic);
            myTanker.RunVoidDelegate();
            // анонимный делегат делегат
            VoidDelegate vDelFromAnonimous = delegate
            {
                Console.WriteLine(" я - анонимный делегат");
            };
            myTanker.RegisterVoidDelegate(vDelFromAnonimous);
            myTanker.RunVoidDelegate();
            // лямбда-выражение
            VoidDelegate vDelFromLambda = () => Console.WriteLine(" я - лямбда выражение");
            myTanker.RegisterVoidDelegate(vDelFromLambda);
            myTanker.RunVoidDelegate();
            // создадим групповой делегат
            VoidDelegate vDelFromGroup = vDelFromStatic;
            vDelFromGroup += vDelFromAnonimous;
            vDelFromGroup += vDelFromLambda;
            // зарегистрируем групповой делегат
            myTanker.RegisterVoidDelegate(vDelFromGroup);
            Console.WriteLine("Выполним групповой делегат:");
            myTanker.RunVoidDelegate();
            // создадим еще один экземпляр танкера
            Tanker newTanker = new Tanker();
            newTanker.RegisterVoidDelegate(vDelFromStatic);
            myTanker.RegisterVoidDelegate(vDelFromStatic);
            // сравним поля делегатов наших экземпляров
            Console.WriteLine("сравним поля делегатов наших экземпляров");
            myTanker.RunVoidDelegate();
            newTanker.RunVoidDelegate();
            if(myTanker.IsSameVoidDelegate(newTanker))
                Console.WriteLine("делегаты равны ");
            else
                Console.WriteLine("делегаты не равны");
            Console.WriteLine("Еще раз сравним поля делегатов наших экземпляров");
            myTanker.RegisterVoidDelegate(vDelFromLambda);
            newTanker.RegisterVoidDelegate(() => Console.WriteLine(" я - лямбда выражение"));
            myTanker.RunVoidDelegate();
            newTanker.RunVoidDelegate();
            if (myTanker.IsSameVoidDelegate(newTanker))
                Console.WriteLine("делегаты равны ");
            else
                Console.WriteLine("делегаты не равны");
            Console.WriteLine("не смотря на то что результат выполнения одинаков, делегаты не равны !!!");
            // 2. делегат с параметрами
            Console.WriteLine("\tИнфо о танкере до изменения загрузки правого борта(четные танки):");
            Console.WriteLine(myTanker.ToString());
            myTanker.RegisterParamDelegate((f, k) => f + k);
            Console.WriteLine("Добавим к каждому четному танку значение: -40");
            myTanker.LoadingStarboard(-40);
            Console.WriteLine("\tИнфо о танкере после загрузки правого борта(четные танки):");
            Console.WriteLine(myTanker.ToString());
            myTanker.RegisterParamDelegate(MultipleFullnes);
            Console.WriteLine(" умножим заполненный объем каждого четного танка в 3 раза ");
            myTanker.LoadingStarboard(3);
            Console.WriteLine("\tИнфо о танкере после загрузки правого борта(четные танки):");
            Console.WriteLine(myTanker.ToString());
            // 3. события

            // Подпишем методы обработчиков на событие возможного переворота танкера
            EventHandler1 eventHandler1 = new EventHandler1();
            myTanker.RolloverMayOccur += eventHandler1.DisplayRedMessage; // экземплярный метод
            myTanker.RolloverMayOccur += EventHandler2.DisplayGreenMessage; // статический метод
            myTanker.RolloverMayOccur += delegate (string p)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Анонимный делегат: " + p);
                Console.ResetColor();
            };
            myTanker.RolloverMayOccur += (k) =>
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Лямбда: " + k);
                Console.ResetColor();
            };
            Console.WriteLine("* * *\nспециально уменьшим загрузку правого борта, чтобы вызвать событие возможного опрокидывания танкера\n* * *");
            myTanker.RegisterParamDelegate((f,k) => f - k);
            myTanker.LoadingStarboard(60);
            Console.WriteLine(myTanker.ToString());
            Console.ReadLine();
        }
    }
}
