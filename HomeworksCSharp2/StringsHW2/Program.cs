using System;
//using System.Collections.Generic;
//using System.Text;
using System.Text.RegularExpressions;

// && a.IndexOf("a>", endIndex) != -1

namespace StringsHW2
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string converted = Regex.Replace(input, "(.)\\1{1,}", "$1");

            Console.WriteLine(converted);

        }
    }
}


