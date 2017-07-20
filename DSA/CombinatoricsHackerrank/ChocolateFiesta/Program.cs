using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateFiesta
{
    class Program
    {
        static int evenCombinations = 0;

        static void Main(string[] args)
        {
            // https://www.hackerrank.com/challenges/a-chocolate-fiesta/problem
            // TODO: optimize to only count instead of listing all subsets..

            int setSize = int.Parse(Console.ReadLine());
            var setMembers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();


            GetEvenSubsets(setMembers, 0, 0);
            Console.WriteLine(evenCombinations);
        }

        static void GetEvenSubsets(int[] set, int subsetSum, int depth)
        {
            int n = set.Length;

            if (depth == n)
            {
                if(subsetSum != 0 && subsetSum % 2 == 0)
                {
                    evenCombinations++;
                }
                return;
            }

            GetEvenSubsets(set, subsetSum, depth + 1);
            GetEvenSubsets(set, subsetSum + set[depth], depth + 1);
        }
    }
}