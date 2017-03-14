using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBouncing
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new Matrix(15, 15);
            var ball = new Ball(matrix, 'O');
            ball.xVelocity = 3;
            ball.yVelocity = 2;
            
            while(true)
            {
                Console.Clear();
                ball.Move();
                matrix.Draw();

                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
