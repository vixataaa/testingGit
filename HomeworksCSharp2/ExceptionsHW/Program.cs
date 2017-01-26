using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {


        // INPUT
        string word = Console.ReadLine();
        int multiplier = word.Length;

        int N = int.Parse(Console.ReadLine());
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < N; i++)
        {

            sb.Append(Console.ReadLine());
            sb.Append(" ");
        }
        string text = sb.ToString();
        // </>INPUT


        string pattern = @".*([A-Z]{1}.+" + word + @"[^\.!]*[\.|!]){1}.*";
        string sentence = "";

        //BGCODER - RUNTIME ERROR

        Match match = Regex.Match(text, pattern, RegexOptions.CultureInvariant);

        if (match.Success)
        {

            sentence = match.Groups[1].Value;

        }
        //BGCODER - RUNTIME ERROR

        //********************************razkomentiran kod po vreme na izpit****************************************************

        ////IMAME SENTENCE

        //int wordPosition = sentence.IndexOf(word);
        //string typeCode = "";

        ////find end
        //if (sentence[sentence.Length-1]=='.')
        //{
        //    typeCode = "Statement";
        //}
        //else
        //{
        //    typeCode = "Exclamation";
        //}

        //Console.WriteLine(typeCode);
        //Console.WriteLine(sentence);
        //find beginning




        //Console.WriteLine(text);
        //Console.WriteLine(wordPosition);

        //***************************************************razkomentiran kod po vreme na izpit***************************************************

        //->>> KOD SLED IZPIT

        int wordPosition = sentence.IndexOf(word);
        string resultString = "";

        //find end
        if (sentence[sentence.Length - 1] == '.')
        {
            resultString = sentence.Substring(wordPosition + word.Length);
        }
        else
        {
            resultString = sentence.Substring(0, wordPosition);
        }

        int weight = word.Length;
        int result = 0;

        for (int i = 0; i < resultString.Length - 1; i++)
        {

            if (resultString[i] != ' ')
            {
                result += weight * resultString[i];
            }
        }

        Console.WriteLine(result);

    }
}