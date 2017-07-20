using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSum
{
    class Program
    {
        static long[,] memory;

        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = input[0];
            int n = input[1];

            memory = new long[k + 1, n + 1];

            for (int i = 0; i < memory.GetLength(0); i++)
            {
                for (int j = 0; j < memory.GetLength(1); j++)
                {
                    memory[i, j] = -1;
                }
            }

            Console.WriteLine(SuperSumMemory(k, n));
            //Console.WriteLine(SuperSumNormal(k, n));

        }

        static long SuperSumMemory(int k, int n)
        {
            //Console.WriteLine("K: {0} -- N: {1}", k, n);
            if (k == 0)
            {
                return n;
            }

            if(memory[k, n] != -1)
            {
                return memory[k, n];
            }

            long result = 0;
            for (int i = 1; i <= n; i++)
            {
                var current = SuperSumMemory(k - 1, i);
                memory[k - 1, i] = current;
                result += current;
            }

            return result;
        }

        static long SuperSumNormal(int k, int n)
        {
            //Console.WriteLine("K: {0} -- N: {1}", k, n);
            if (k == 0)
            {
                return n;
            }

            long result = 0;
            for (int i = 1; i <= n; i++)
            {
                result += SuperSumNormal(k - 1, i);
            }

            return result;
        }
    }
}
