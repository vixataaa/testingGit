using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNestedLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            NNestedLoops(0, 3, "");
        }

        static void NNestedLoops(int start, int n, string combination)
        {
            if(start == n)
            {
                Console.WriteLine(combination);
                return;
            }

            for (int i = 0; i < n; i++)
            {
                NNestedLoops(start + 1, n, combination + (i + 1));
            }
        }
    }
}
