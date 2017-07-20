using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCS
{
    class Program
    {
        static int[,] matrix;

        static int LCS(int firstIndex, int secondIndex, string first, string second, int depth)
        {
            if (firstIndex < 0 || secondIndex < 0)
            {
                return 0;
            }


            if (matrix[firstIndex, secondIndex] != -1)
            {
                return matrix[firstIndex, secondIndex];
            }


            if (first[firstIndex] == second[secondIndex])
            {
                matrix[firstIndex, secondIndex] = LCS(firstIndex - 1, secondIndex - 1, first, second, depth + 1) + 1;
                return matrix[firstIndex, secondIndex];
            }

            var l1 = LCS(firstIndex - 1, secondIndex, first, second, depth + 1);
            var l2 = LCS(firstIndex, secondIndex - 1, first, second, depth + 1);

            matrix[firstIndex, secondIndex] = Math.Max(l1, l2);


            return matrix[firstIndex, secondIndex];
        }

        static int LCSDynamic(string first, string second)
        {
            var matrix = new int[first.Length + 1, second.Length + 1];

            for (int i = 1; i <= first.Length; i++)
            {
                for (int j = 1; j <= second.Length; j++)
                {
                    matrix[i, j] = first[i - 1] == second[j - 1]
                        ? matrix[i - 1, j - 1] + 1
                        : Math.Max(matrix[i - 1, j], matrix[i, j - 1]);
                }
            }

            return matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
        }

        static void Main(string[] args)
        {
            // 15 * 4 = 60
            string a = "abcdabcdabcdabcdabcdabcdabcdabcdabcdabcdabcdabcdabcdabcdabcd";
            string b = "abcdabcdabcdabcdabcfdabcdabcdabcdabcdabcdabcdabcdabcdabcdabcd";

            Console.WriteLine(LCSDynamic(a, b));

            //matrix = new int[a.Length, b.Length];

            //for (int i = 0; i < a.Length; i++)
            //{
            //    for (int j = 0; j < b.Length; j++)
            //    {
            //        matrix[i, j] = -1;
            //    }
            //}

            //Console.WriteLine(LCS(a.Length - 1, b.Length - 1, a, b, 0));


        }
    }
}
