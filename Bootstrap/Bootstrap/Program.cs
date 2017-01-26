using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Bootstrap
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter filename to fill or end if you dont wish to fill");
            string input = Console.ReadLine();

            Random rnd = new Random();

            // Generate random sequences
            while (input != "end")
            {
                Console.WriteLine("Enter number of samples");
                int sampleCount = int.Parse(Console.ReadLine());

                Console.WriteLine(@"Enter range in the format 'x-y' (inclusive)");
                var range = Console.ReadLine().Split('-').Select(x => int.Parse(x)).ToArray();

                StreamWriter writer = new StreamWriter(input);

                using (writer)
                {
                    for (int i = 0; i < sampleCount; i++)
                    {
                        if (i == sampleCount - 1)
                        {
                            writer.Write("{0}", rnd.Next(range[0], range[1] + 1));
                            break;
                        }
                        writer.Write("{0},", rnd.Next(range[0], range[1] + 1));
                    }
                }

                Console.WriteLine("Enter filename to fill or end if you dont wish to fill");
                input = Console.ReadLine();
            }


            Console.WriteLine("Filename to load content from:");
            input = Console.ReadLine();

            StreamReader reader = new StreamReader(input);

            var data = new List<int>();

            using (reader)
            {
                string[] tmp = reader.ReadToEnd().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in tmp)
                {
                    data.Add(int.Parse(item));
                }            
            }


            // Bootstrap?

            List<List<int>> resamples = new List<List<int>>();

            Console.WriteLine("Enter number of resamples:");
            int resamplesCount = int.Parse(Console.ReadLine());

            for(int i = 0; i < resamplesCount; i++)
            {
                List<int> tmpList = new List<int>();

                for(int j = 0; j < data.Count; j++)
                {
                    // takes at random from the original
                    tmpList.Add(data[rnd.Next(0, data.Count)]);
                }
                // Resample filled

                resamples.Add(tmpList);
            }

            // mean
            Console.WriteLine("Original sample mean: {0}", Mean(data));
            Console.WriteLine("Bootstrap mean: {0}", BootstrapMean(resamples));
            Console.WriteLine("Bias: {0}", BootstrapMean(resamples) - Mean(data));
            // median   // implement me !!!
            // mode
            Console.WriteLine("Original sample mode: {0}", Mode(data));
            Console.WriteLine("Bootstrap mode: {0}", BootstrapMode(resamples));
            // standard deviation
            Console.WriteLine("Original sample std deviation: {0}", StandardDeviation(data));
            Console.WriteLine("Bootstrap standard error: {0}", BootstrapStandardDeviation(resamples));
            // for both original and bootstrap
        }

        static double Mean(IEnumerable<int> data)
        {
            double sum = 0;

            foreach (var item in data)
            {
                sum += item;
            }

            return sum / data.Count();
        }

        static double BootstrapMean(IEnumerable<IEnumerable<int>> resamples)
        {
            double sum = 0;

            foreach (var item in resamples)
            {
                sum += Mean(item);
            }

            return sum / resamples.Count();
        }

        static int Mode(IList<int> data)
        {
            int mode = 0;
            int maxCount = int.MinValue;

            for (int i = 0; i < data.Count(); i++)
            {
                int count = 0;

                for(int j = 0; j < data.Count(); j++)
                {
                    if(data[i] == data[j])
                    {
                        count++;
                    }
                }

                if(count > maxCount)
                {
                    mode = data[i];
                    maxCount = count;
                }

                count = 0;
            }

            return mode;
        }

        static int BootstrapMode(List<List<int>> resamples)
        {
            var modesOfEachResample = resamples.Select(x => Mode(x)).ToList();

            return Mode(modesOfEachResample);
        }

        static double StandardDeviation(IEnumerable<int> data)
        {
            double sum = 0;
            double mean = Mean(data);

            foreach (var item in data)
            {
                sum += ((item - mean) * (item - mean));
            }

            double result = Math.Sqrt(sum / (data.Count() - 1));

            return result; 
        }

        static double BootstrapStandardDeviation(IEnumerable<IEnumerable<int>> resamples)
        {
            double sum = 0;
            // whole mean of resamples
            double mean = BootstrapMean(resamples);

            // means of each resample
            var resamplesMeans = resamples.Select(x => Mean(x));

            foreach (var item in resamplesMeans)
            {
                sum += ((item - mean) * (item - mean));
            }

            double result = Math.Sqrt(sum / (resamplesMeans.Count() - 1));

            return result;
        }
    }
}
