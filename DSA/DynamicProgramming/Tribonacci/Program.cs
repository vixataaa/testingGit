using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tribonacci
{
    class Program
    {
        static long[] sequence;

        static void Main(string[] args)
        {
            var input = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            sequence = new long[input[3] + 1];

            sequence[1] = input[0];
            sequence[2] = input[1];
            sequence[3] = input[2];

            Console.WriteLine(Tribonacci(input[3]));
        }

        static long Tribonacci(int n)
        {
            for (int i = 4; i <= n; i++)
            {
                sequence[i] = sequence[i - 1] + sequence[i - 2] + sequence[i - 3];
            }

            return sequence[n];
        }
    }
}
