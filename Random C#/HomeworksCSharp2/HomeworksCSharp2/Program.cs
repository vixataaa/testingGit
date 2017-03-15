using System;
using System.Text;
using System.Numerics;

namespace HomeworksCSharp2
{
    class Program
    {
        static void swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        static int MaxInArr(int[] arr, int endIndex)
        {
            int max = int.MinValue;
            int index = 0;

            for(int i = 0; i <= endIndex; i++)
            {
                if(arr[i] > max)
                {
                    max = arr[i];
                    index = i;
                }
            }

            return index;
        }

        static void sortArr(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                swap(ref arr[arr.Length - 1 - i], ref arr[MaxInArr(arr, arr.Length - 1 - i)]);
            }
        }

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            sortArr(arr);

            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                if(i < arr.Length - 1)
                {
                    Console.Write(" ");
                }
            }
        }
    }
}
