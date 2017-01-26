using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem17
{
    class Program
    {
        static string[] GenerateRandomStringArray(int count)
        {
            var result = new string[count];

            Random rnd = new Random();

            string symbols = "abcdefghijklmnopqrstuvwxyz0123456789";
            //Console.WriteLine(symbols.Length);

            for(int i = 0; i < count; i++)
            {
                result[i] = ""; 

                int randomLength = rnd.Next(1, 30);

                for(int j = 0; j < randomLength; j++)
                {
                    result[i] += symbols[rnd.Next(0, symbols.Length - 1)];
                }
            }

            return result;
        }

        static void Main()
        {
            var stringArray = GenerateRandomStringArray(20);

            var longestString = from text in stringArray
                                where text.Length == stringArray.Max(x => x.Length)
                                select text;

            int longestLength = 0;

            foreach (var text in longestString)
            {
                Console.WriteLine("Longest string(s): {0}", text);
                longestLength = text.Length;
            }

            Console.WriteLine("With length(s): {0}", longestLength);
        }
    }
}
