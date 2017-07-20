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
            int askedCount = int.Parse(Console.ReadLine());

            int[] answers = new int[askedCount];

            for (int i = 0; i < askedCount; i++)
            {
                int answer = int.Parse(Console.ReadLine());
                answers[i] = answer;
            }

            
        }
    }
}
