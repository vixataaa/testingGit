using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int volumeChangesCount = int.Parse(Console.ReadLine());
            var volumeChanges = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int initialVolume = int.Parse(Console.ReadLine());
            int maxVolume = int.Parse(Console.ReadLine());

            bool[,] sums = new bool[volumeChangesCount + 1, maxVolume + 1];

            sums[0, initialVolume] = true;

            for (int i = 1; i <= volumeChangesCount; i++)
            {
                for (int j = 0; j <= maxVolume; j++)
                {
                    if(sums[i - 1, j])
                    {
                        int change = volumeChanges[i - 1];

                        if(j - change >= 0)
                        {
                            sums[i, j - change] = true;
                        }

                        if(j + change <= maxVolume)
                        {
                            sums[i, j + change] = true;
                        }
                    }
                }
            }
            
            for (int i = maxVolume; i >= 0; i--)
            {
                if(sums[volumeChangesCount, i])
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine(-1);
        }
    }
}
