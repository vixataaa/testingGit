using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBouncing
{
    public class Matrix
    {
        public char[,] coordinateSystem { get; set; }

        public Matrix(int rows, int cols)
        {
            this.coordinateSystem = new char[rows, cols];
            FillCoordinateSystem();
        }

        private void FillCoordinateSystem()
        {
            for (int i = 0; i < this.coordinateSystem.GetLength(0); i++)
            {
                for (int j = 0; j < this.coordinateSystem.GetLength(1); j++)
                {
                    this.coordinateSystem[i, j] = '.';
                }
            }
        }
        
        public void Draw()
        {
            for (int i = 0; i < this.coordinateSystem.GetLength(0); i++)
            {
                for (int j = 0; j < this.coordinateSystem.GetLength(1); j++)
                {
                    Console.Write(this.coordinateSystem[i, j]);
                }
                Console.WriteLine();
            }
        }


    }
}
