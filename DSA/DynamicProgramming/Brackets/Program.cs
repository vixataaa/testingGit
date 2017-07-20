using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brackets
{
    class Program
    {
        static int count = 0;

        static void Main()
        {
            string input = Console.ReadLine();

            var arr = input.ToCharArray();

            int openingCount = 0;
            int closingCount = 0;

            foreach (var ch in arr)
            {
                if(ch == '(')
                {
                    closingCount++;
                }

                if(ch == ')')
                {
                    openingCount++;
                }
            }

            //Console.WriteLine(openingCount + " " + closingCount);
            GenerateCombinations(arr, 0, arr.Length / 2, openingCount, closingCount);
            Console.WriteLine(count);
        }

        static void GenerateCombinations(char[] initial, int position, int n, int opening, int closing)
        {
            if(closing == n)
            {
                //Console.WriteLine(string.Join("", initial));
                count++;
                return;
            }
            else if (initial[position] == '(')
            {
                GenerateCombinations(initial, position + 1, n, opening + 1, closing);
            }
            else if (initial[position] == ')')
            {
                GenerateCombinations(initial, position + 1, n, opening, closing + 1);
            }
            else
            {
                if(opening > closing)
                {
                    //initial[position] = ')';
                    GenerateCombinations(initial, position + 1, n, opening, closing + 1);
                }

                if(opening < n)
                {
                    //initial[position] = '(';
                    GenerateCombinations(initial, position + 1, n, opening + 1, closing);
                }
            }
        }
    }
}
