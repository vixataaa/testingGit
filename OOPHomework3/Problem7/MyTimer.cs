using System;
using System.Threading;

namespace Problem7
{
    static class Timer
    {
        private delegate void Del();

        public static void Execute(int interval)
        {
            while (!Console.KeyAvailable)
            {
                Del del = PrintMethod1;
                del += PrintMethod2;
                del += PrintDateTime;

                del.Invoke();

                Thread.Sleep(interval);

                Execute(interval);
            }//until key-press
        }

        private static void PrintMethod1()
        {
            Console.WriteLine("Method1");
        }

        private static void PrintMethod2()
        {
            Console.WriteLine("Method2");
        }

        private static void PrintDateTime()
        {
            Console.WriteLine($"Executed at {DateTime.Now.ToString()}");
            Console.WriteLine("Press a key to stop program execution");

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
