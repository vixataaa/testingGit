using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MiniExam2._2
{
    class Program
    {
        static double[,] matrix;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            LinkedList<int>[] graph = GenerateGraph(rows, cols);
        }

        private static LinkedList<int>[] GenerateGraph(int rows, int cols)
        {
            int verticesCount = rows * cols;
            var result = new LinkedList<int>[verticesCount];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int currentVertex = cols * i + j;

                    if (result[currentVertex] == null)
                    {
                        result[currentVertex] = new LinkedList<int>();
                    }

                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {

                        }
                        else
                        {

                        }

                    }
                    else
                    {
                        if (j % 2 == 0)
                        {

                        }
                        else
                        {

                        }
                    }

                    result[currentVertex].AddLast(1);
                    Console.WriteLine(currentVertex + " -> " + string.Join(" ", result[currentVertex]));
                }
            }

            return null;
        }
    }
}
