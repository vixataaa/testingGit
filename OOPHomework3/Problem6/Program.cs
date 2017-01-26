using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem6
{
    class Program
    {
        static void Main()
        {
            int[] numbers = new int[1000];
            
            for(int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i + 1;
            }

            var divisibleBy7and3 = from number in numbers
                                   where (number % 3 == 0 && number % 7 == 0)
                                   select number;

            Console.WriteLine("Divisible by 7 and 3");
            Console.WriteLine(String.Join(" ", divisibleBy7and3));
        }
    }
}
