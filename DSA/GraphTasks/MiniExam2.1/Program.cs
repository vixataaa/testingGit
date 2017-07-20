using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.BinaryTree
{
    class Program
    {
        static void Main()
        {
            var multiplier = ulong.Parse(Console.ReadLine());

            var numbersToCheck = Console.ReadLine().Split(' ').Select(ulong.Parse).ToArray();

            var results = new LinkedList<int>();

            for (int i = 0; i < numbersToCheck.Length; i++)
            {
                var state = GetNumberState(multiplier, numbersToCheck[i]);
                results.AddLast(state);
            }

            Console.WriteLine(string.Join(" ", results));
        }

        static int GetNumberState(ulong multiplier, ulong numberToCheck)
        {
            int[] reminders = new int[] { 0, 0, 0, 0 };

            ulong current = 0;

            while (numberToCheck != 0)
            {
                current = numberToCheck % multiplier;
                numberToCheck /= multiplier;

                if (current < 3)
                {
                    reminders[current]++;
                }
                else
                {
                    reminders[3]++;
                }
            }

            if (reminders[3] > 0)
            {
                return 0;
            }

            if (reminders[1] == 1 && reminders[2] > 0)
            {
                return 1;
            }

            if (reminders[1] == 2 && reminders[2] == 0)
            {
                return 1;
            }

            return 0;
        }
    }
}