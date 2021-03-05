using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab9_Var4_Multithreading
{
    class Program
    {
        const int edge = 30;
        static int i = 0;
        static object oLock = new object();
        static void Main(string[] args)
        {

            Parallel.Invoke(EvenSeq, OddSeq, FibonachiSeq);
            Console.ReadLine();
        }
        static void EvenSeq()
        {
            lock (oLock)
            {
                for (i = 1; i <= edge; i++)
                    if (i % 2 == 0)
                        Console.WriteLine(Thread.CurrentThread.Name + ": " + i);
            }
        }
        static void OddSeq()
        {
            lock (oLock)
            {
                for (i = 1; i <= edge; i++)
                    if (i % 2 != 0)
                        Console.WriteLine(Thread.CurrentThread.Name + ": " + i);
            }
        }
        static void FibonachiSeq()
        {
            lock (oLock)
            {
                int a = 1, b = 1, c;
                Console.WriteLine(Thread.CurrentThread.Name + "_1: 1\n" + Thread.CurrentThread.Name + "_2: 1");
                for (i = 3; i <= edge; i++)
                {
                    c = a + b;
                    Console.WriteLine(Thread.CurrentThread.Name + $"_{i}: " + c);
                    a = b;
                    b = c;
                }
            }
        }
    }
}
