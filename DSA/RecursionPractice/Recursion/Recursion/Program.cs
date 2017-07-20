using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    class Program
    {
        public static void Main()
        {
            int k = 2;
            int n = 2;

            //NNestedLoops(k, "", n);
            //CombinationsWithDuplicates(k, n);
            //CombinationsWithoutDuplicates(k, n);
            PermutationsNoDuplicates(3);

        }

        static void NNestedLoops(int n, string combination, int loopDepth)
        {
            if (n == 0)
            {
                Console.WriteLine(combination);
                return;
            }

            for (int i = 1; i <= loopDepth; i++)
            {
                NNestedLoops(n - 1, combination + i + " ", loopDepth);
            }
        }

        static void CombinationsWithDuplicates(int k, int n)
        {
            CombinationsWithDuplicates(1, 0, k, n, "");
        }

        static void CombinationsWithDuplicates(int startValue, int depth, int k, int n, string combination)
        {
            if (depth == k)
            {
                Console.WriteLine(combination);
                return;
            }

            for (int i = startValue; i <= n; i++)
            {
                CombinationsWithDuplicates(i, depth + 1, k, n, combination + i + " ");
            }
        }

        static void CombinationsWithoutDuplicates(int k, int n)
        {
            CombinationsWithoutDuplicates(1, 0, k, n, "");
        }

        static void CombinationsWithoutDuplicates(int startValue, int depth, int k, int n, string combination)
        {
            if (depth == k)
            {
                Console.WriteLine(combination);
                return;
            }

            for (int i = startValue; i <= n; i++)
            {
                CombinationsWithoutDuplicates(i + 1, depth + 1, k, n, combination + i + " ");
            }
        }

        static void PermutationsNoDuplicates(int n)
        {
            var permutation = new int[n];
            var used = new bool[n];
            PermutationsNoDuplicates(0, n, permutation, used);
        }

        static void PermutationsNoDuplicates(int startValue, int n, int[] permutation, bool[] used)
        {
            if (startValue == n)
            {
                Console.WriteLine(string.Join(" ", permutation));
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if(used[i])
                {
                    continue;
                }

                permutation[startValue] = i + 1;
                used[i] = true;
                PermutationsNoDuplicates(startValue + 1, n, permutation, used);
                used[i] = false;
            }
        }
    }
}
