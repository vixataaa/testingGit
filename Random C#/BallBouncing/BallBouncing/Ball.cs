using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBouncing
{
    public class Ball
    {
        public int xCord { get; set; }
        public int yCord { get; set; }
        public int xVelocity { get; set; }
        public int yVelocity { get; set; }
        public Matrix Matrix { get; set; }
        public char Symbol { get; set; }

        public Ball(Matrix matrix, char ballSymbol)
        {
            this.Matrix = matrix;

            this.xCord = 0;
            this.yCord = 0;

            this.xVelocity = 1;
            this.yVelocity = 1;

            this.Symbol = ballSymbol;
        }

        public void Move()
        {
            int matrixLeftWall = 0;                                                 // row
            int matrixRightWall = this.Matrix.coordinateSystem.GetLength(1) - 1;    // row  
            int matrixTop = 0;                                                      // col
            int matrixBottom = this.Matrix.coordinateSystem.GetLength(0) - 1;       // col
            bool incrementX = true;
            bool incrementY = true;

            this.Matrix.coordinateSystem[this.xCord, this.yCord] = '.';


            if (this.yCord + this.yVelocity <= matrixLeftWall && this.yVelocity < 0)
            {
                this.yVelocity *= -1;
                this.yCord = matrixLeftWall;
                incrementY = false;
            }

            if (this.yCord + this.yVelocity >= matrixRightWall && this.yVelocity > 0)
            {
                this.yVelocity *= -1;
                this.yCord = matrixRightWall;
                incrementY = false;
            }

            if (this.xCord + this.xVelocity <= matrixTop && this.xVelocity < 0)
            {
                this.xVelocity *= -1;
                this.xCord = matrixTop;
                incrementX = false;
            }

            if (this.xCord + this.xVelocity >= matrixBottom && this.xVelocity > 0)
            {
                this.xVelocity *= -1;
                this.xCord = matrixBottom;
                incrementX = false;
            }

            if(incrementX)
            {
                this.xCord += this.xVelocity;
            }

            if(incrementY)
            {
                this.yCord += this.yVelocity;
            }

            //this.xCord += this.xVelocity;
            //this.yCord += this.yVelocity;

            Console.WriteLine(this.xCord + "] -- [" + this.yCord);
            this.Matrix.coordinateSystem[this.xCord, this.yCord] = this.Symbol;
        }
    }
}
