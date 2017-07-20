using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();

            ulong patternCount = 1;

            for (int i = 0; i < pattern.Length; i++)
            {
                if(pattern[i] == '*')
                {
                    patternCount <<= 1;
                }
            }

            Console.WriteLine(patternCount);
        }
    }
}
