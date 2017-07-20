using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var digits = new int[10];

            getDigit(input, digits);

            Console.WriteLine(string.Join(" ", digits));
        }

        public static void getDigit(string str, int[] digits)
        {
            if (str.Length == 1)
            {
                digits[int.Parse(str)] += 1;
            }

            for (int i = 0; i < str.Length - 1; i++)
            {
                int a = int.Parse(str[i].ToString());
                int b = int.Parse(str[i + 1].ToString());
                
                var d = (a + b) * (a ^ b) % 10;

                getDigit(str.Substring(0, i) + d + str.Substring(i + 2), digits);
            }
        }
    }
}
