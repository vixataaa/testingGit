using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            int generations = int.Parse(Console.ReadLine());
            var rowsCols = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];

            var matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }

            int aliveCount = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i][j] == 1)
                    {
                        aliveCount++;
                    }
                }
            }

            Console.WriteLine(aliveCount);
        }

        static int[][] GenerateNew(int[][] initial, int rows, int cols)
        {
            var result = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                result[i] = new int[cols];

                for (int j = 0; j < cols; j++)
                {
                    int aliveCount = GetAliveCount(rows, cols, i, j, initial);

                    if (initial[i][j] == 1)
                    {
                        if (aliveCount == 2 || aliveCount == 3)
                        {
                            result[i][j] = 1;
                        }
                        else if (aliveCount < 2)
                        {
                            result[i][j] = 0;
                        }
                        else
                        {
                            result[i][j] = 0;
                        }
                    }
                    else
                    {
                        if (aliveCount == 3)
                        {
                            result[i][j] = 1;
                        }
                        else
                        {
                            result[i][j] = 0;
                        }

                    }
                }
            }

            return result;
        }

        static int GetAliveCount(int rows, int cols, int row, int col, int[][] matrix)
        {
            int result = 0;

            if (row > 0)
            {
                result += 1 & matrix[row - 1][col];

                if (col > 0)
                {
                    result += 1 & matrix[row - 1][col - 1];
                }

                if (col < cols - 1)
                {
                    result += 1 & matrix[row - 1][col + 1];
                }
            }

            if (row < rows - 1)
            {
                result += 1 & matrix[row + 1][col];

                if (col > 0)
                {
                    result += 1 & matrix[row + 1][col - 1];
                }

                if (col < cols - 1)
                {
                    result += 1 & matrix[row + 1][col + 1];
                }
            }

            if (col > 0)
            {
                result += 1 & matrix[row][col - 1];
            }

            if (col < cols - 1)
            {
                result += 1 & matrix[row][col + 1];
            }

            return result;
        }

        static string PrintMatrix(int[][] matrix, int rows, int cols)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if(matrix[i][j] == 1)
                    {
                        result.Append("*");
                    }
                    else
                    {
                        result.Append(" ");
                    }
                }
                result.AppendLine();
            }

            return result.ToString();
        }
    }
}