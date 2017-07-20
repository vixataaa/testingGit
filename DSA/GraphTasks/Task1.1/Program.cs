using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var verticesEdges = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int vertices = verticesEdges[0];
            int edges = verticesEdges[1];

            int[,] matrix = new int[vertices, vertices];

            for (int i = 0; i < edges; i++)
            {
                var edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                int x = edge[0] - 1;
                int y = edge[1] - 1;

                matrix[x, y]++;
                matrix[y, x]++;
            }

            Console.WriteLine(vertices);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == matrix.GetLength(1) - 1)
                    {
                        Console.Write(matrix[i, j]);
                    }
                    else
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
