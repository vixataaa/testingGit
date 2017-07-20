using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretLanguage
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            int wordCount = int.Parse(Console.ReadLine());

            var words = Console.ReadLine().Split(new char[] { ' ', ',', '\"' }, StringSplitOptions.RemoveEmptyEntries);

            var sortedWords = words.Select(w => GetSortedString(w)).ToArray();

            var minimumCounts = new int[message.Length + 1].Select(x => 2000000).ToArray();
            minimumCounts[0] = 0;

            for (int i = 0; i < message.Length; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    if (i + 1 >= words[j].Length)
                    {
                        string subMessage = message.Substring(i - words[j].Length + 1, words[j].Length);
                        string sortedSubMessage = GetSortedString(subMessage);

                        if (sortedSubMessage == sortedWords[j])
                        {
                            int cost = GetCost(subMessage, words[j]);

                            minimumCounts[i + 1] = Math.Min(minimumCounts[i + 1], minimumCounts[i + 1 - words[j].Length] + cost);
                        }
                    }
                }
            }

            Console.WriteLine(minimumCounts[message.Length] != 2000000
                ? minimumCounts[message.Length]
                : -1);
        }

        static string GetSortedString(string str)
        {
            return new string(str.OrderBy(x => x).ToArray());
        }

        static int GetCost(string first, string second)
        {
            int result = 0;

            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    ++result;
                }
            }

            return result;
        }
    }
}
