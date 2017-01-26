using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    class Program
    {
        static void Extract(string a, string word)
        {
            int dotIndex = 0;

            Regex rgx = new Regex(@"[^a-zA-Z]" + word + "[^a-zA-Z]");

            while (a.IndexOf('.', dotIndex) != -1)
            {
                string sentence = a.Substring(dotIndex, a.IndexOf('.', dotIndex) - dotIndex + 1);

                if (rgx.IsMatch(sentence))
                {
                    Console.Write(sentence.Trim() + " ");
                }

                dotIndex = a.IndexOf('.', dotIndex) + 1;
            }
        }



        static void Main()
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            string[] sentences = text.Split('.');

            StringBuilder tmp = new StringBuilder();        //get splitters     
            StringBuilder result = new StringBuilder();

            foreach (var sentence in sentences)
            {
                tmp.Clear();

                for (int i = 0; i < sentence.Length; i++)
                {
                    if (!char.IsLetter(sentence[i]))
                    {
                        tmp.Append(sentence[i]);
                    }
                }

                char[] separators = tmp.ToString().ToCharArray();
                string[] words = sentence.Split(separators, StringSplitOptions.RemoveEmptyEntries);


                if (Array.IndexOf(words, word) != -1)
                {
                    result.Append(sentence.Trim() + ". ");
                }
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }
}
