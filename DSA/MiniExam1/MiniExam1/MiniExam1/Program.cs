using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniExam1
{
    class Program
    {
        static int[] count = new int[10];

        static void Main()
        {
            var variations = Console.ReadLine();


            foreach (var variation in GetVariations(2, variations))
            {
                Console.WriteLine(string.Join(" ", variation));
            }

            Console.WriteLine(count);
            //PrintVariations(3, 2, new int[] { 4, 5, 6 });
        }

        static void PrintVariations(int n, int k, int[] variation)
        {
            var used = new bool[n];
            PrintPermutations(0, variation, used);
        }

        static void PrintPermutations(int i, int[] permutation, bool[] used)
        {
            int n = used.Length;
            int k = permutation.Length;

            if (i == k)
            {
                Console.WriteLine(string.Join(" ", permutation));
                int index = CalculateResult(permutation[0], permutation[1]);
                count[index]++;
                return;
            }

            for (int j = 0; j < n; ++j)
            {
                if (used[j])
                {
                    continue;
                }

                permutation[i] = j + 1;
                used[j] = true;
                PrintPermutations(i + 1, permutation, used);
                used[j] = false; // important
            }
        }

        static int CalculateResult(int a, int b)
        {
            return (a + b) * (a ^ b) % 10;
        }
        public static List<List<int>> GetVariations<T>(int k, List<int> elements)
        {
            List<List<int>> result = new List<List<int>>();
            if (k == 1)
            {
                result.AddRange(elements.Select(element => new List<T>() { element }));
            }
            else
            {
                foreach (T element in elements)
                {
                    List<T> subelements = elements.Where(e => !e.Equals(element)).ToList();
                    List<List<T>> subvariations = GetVariations(k - 1, subelements);
                    foreach (List<T> subvariation in subvariations)
                    {
                        subvariation.Add(element);
                        result.Add(subvariation);
                    }
                }
            }

            return result;
        }
    }
}
