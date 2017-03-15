using System;
using System.Text;
using System.Collections.Generic;

namespace CSharp2Classes
{
    class Program
    {
        static List<int> IndexesTag1(string a)
        {
            var indexes = new List<int>();

            int index = a.Length - 1;

            while(a.LastIndexOf("<upcase>", index) != -1)
            {
                indexes.Add(a.LastIndexOf("<upcase>", index));
                index = a.LastIndexOf("<upcase>", index) - 1;
            }

            return indexes;
        }

        static List<int> IndexesTag2(string a)
        {
            var indexes = new List<int>();

            int index = a.Length - 1;

            while (a.LastIndexOf("</upcase>", index) != -1)
            {
                indexes.Add(a.LastIndexOf("</upcase>", index));
                index = a.LastIndexOf("</upcase>", index) - 1;
            }

            return indexes;
        }

        static string UpperCase(string a)
        {
            List<int> indexes1 = IndexesTag1(a);
            List<int> indexes2 = IndexesTag2(a);

            StringBuilder tmp = new StringBuilder(a);

            for(int i = 0; i < indexes1.Count; i++)
            {
                int startIndex = indexes1[i];
                int length = indexes2[i] - indexes1[i] + 9;

                string oldSubstr = a.Substring(startIndex, length);
                string newSubstr = a.Substring(startIndex + 8, length - 17);

                tmp.Replace(oldSubstr, newSubstr.ToUpper());
            }

            return tmp.ToString();
        }

        static void Main()
        {
            string input = Console.ReadLine();

            Console.WriteLine(UpperCase(input));
        }
    }
}
