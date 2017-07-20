using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsWithDuplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 2;
            int n = 3;

            CombinationsWithDuplicates(0, k, n, "");
        }

        static void CombinationsWithDuplicates(int depth, int k, int n, string combination)
        {
            if(depth == k)
            {
                Console.WriteLine(combination);
                return;
            }

            for(int i = 0; i <= n; i++)
            {
                CombinationsWithDuplicates(depth + 1, k, n, combination + i);
            }
        }
    }
}
