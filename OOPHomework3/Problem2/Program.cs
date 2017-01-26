using System;
using System.Collections.Generic;

namespace Problem2
{
    class Program
    {
        static void Main()
        {
            List<double> list = new List<double>();

            for (int i = 8; i < 10; i++)
            {
                list.Add(i);
            }
            //list.Add(0.1);

            Console.WriteLine("Sum: {0}", list.Sum());
            Console.WriteLine("Product: {0}", list.Product());
            Console.WriteLine("Min: {0}", list.Min());
            Console.WriteLine("Max: {0}", list.Max());
            Console.WriteLine("Average: {0}", list.Average());


        }
    }
}
