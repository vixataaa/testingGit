using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitar
{
    class Program
    {
        const int MIN_VOLUME = 0;
        static int maxVolume;

        static int maxSum = -1;

        static int callCount = 0;

        static void Main(string[] args)
        {
            int volumeChangesCount = int.Parse(Console.ReadLine());
            var volumeChanges = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int initialVolume = int.Parse(Console.ReadLine());
            maxVolume = int.Parse(Console.ReadLine());


            PrintCombs(volumeChanges, 0, 1, initialVolume);
            Console.WriteLine(maxSum);
            Console.WriteLine(callCount);
        }

        static void PrintCombs(int[] volumeChanges, int position, int multiplier, int sum)
        {
            ++callCount;
            if(sum < MIN_VOLUME || sum > maxVolume)
            {
                return;
            }

            if (position == volumeChanges.Length)
            {
                maxSum = Math.Max(sum, maxSum);
                return;
            }

            PrintCombs(volumeChanges, position + 1, 1, sum + (multiplier * volumeChanges[position]));
            PrintCombs(volumeChanges, position + 1, -1, sum + (-1 * multiplier * volumeChanges[position]));
        }
    }
}
