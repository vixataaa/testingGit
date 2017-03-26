using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Minesweeper.Engine;
using Minesweeper.Models;

namespace Minesweeper
{
    public class MinesGame
    {
        public static void Main(string[] args)
        {
            var gameEngine = new MinesweeperEngine();
            gameEngine.Start();
        }
    }
}
