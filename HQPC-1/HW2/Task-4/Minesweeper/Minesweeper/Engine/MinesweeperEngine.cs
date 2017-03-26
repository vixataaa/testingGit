using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Models;

namespace Minesweeper.Engine
{
    public class MinesweeperEngine
    {
        private string command;
        private char[,] field;
        private char[,] bombs;
        private int scoreCounter;
        private bool explosionOccured;
        private List<Score> topScorers;
        private bool gameIsOver;
        private int maxMoves;
        private bool playerWon;

        public MinesweeperEngine()
        {
            this.command = string.Empty;
            this.field = this.CreateGameField();
            this.bombs = this.PlaceBombs();
            this.scoreCounter = 0;
            this.explosionOccured = false;
            this.topScorers = new List<Score>(6);
            this.gameIsOver = true;
            this.maxMoves = 35;
            this.playerWon = false;
        }

        public void Start()
        {
            int row = 0;
            int column = 0;

            do
            {
                if (this.gameIsOver)
                {
                    Console.WriteLine(" [top] - shows ranking \n [restart] - restarts game \n [exit] - exits game");
                    this.PrintField(this.field);
                    this.gameIsOver = false;
                }

                Console.Write("Enter [row column]: ");
                this.command = Console.ReadLine().Trim();

                if (this.command.Length >= 3)
                {
                    if (int.TryParse(this.command[0].ToString(), out row) &&
                    int.TryParse(this.command[2].ToString(), out column) &&
                        row <= this.field.GetLength(0) && column <= this.field.GetLength(1))
                    {
                        this.command = "turn";
                    }
                }

                switch (this.command)
                {
                    case "top":
                        this.PrintRanking(this.topScorers);
                        break;
                    case "restart":
                        this.field = this.CreateGameField();
                        this.bombs = this.PlaceBombs();
                        this.PrintField(this.field);
                        this.explosionOccured = false;
                        this.gameIsOver = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (this.bombs[row, column] != '*')
                        {
                            if (this.bombs[row, column] == '-')
                            {
                                this.UpdateField(this.field, this.bombs, row, column);
                                this.scoreCounter++;
                            }

                            if (this.maxMoves == this.scoreCounter)
                            {
                                this.playerWon = true;
                            }
                            else
                            {
                                this.PrintField(this.field);
                            }
                        }
                        else
                        {
                            this.explosionOccured = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nInvalid command\n");
                        break;
                }

                if (this.explosionOccured)
                {
                    this.PrintField(this.bombs);
                    Console.Write("You died with {0} points. Please enter a nickname: ", this.scoreCounter);
                    string playerName = Console.ReadLine();
                    Score playerScore = new Score(playerName, this.scoreCounter);
                    if (this.topScorers.Count < 5)
                    {
                        this.topScorers.Add(playerScore);
                    }
                    else
                    {
                        for (int i = 0; i < this.topScorers.Count; i++)
                        {
                            if (this.topScorers[i].Points < playerScore.Points)
                            {
                                this.topScorers.Insert(i, playerScore);
                                this.topScorers.RemoveAt(this.topScorers.Count - 1);
                                break;
                            }
                        }
                    }

                    this.topScorers.Sort((Score r1, Score r2) => r2.Name.CompareTo(r1.Name));
                    this.topScorers.Sort((Score r1, Score r2) => r2.Points.CompareTo(r1.Points));
                    this.PrintRanking(this.topScorers);

                    this.field = this.CreateGameField();
                    this.bombs = this.PlaceBombs();
                    this.scoreCounter = 0;
                    this.explosionOccured = false;
                    this.gameIsOver = true;
                }

                if (this.playerWon)
                {
                    Console.WriteLine("\nWell done, you have successfully completed the game!");
                    this.PrintField(this.bombs);
                    Console.WriteLine("Please enter your nickname, badka: ");
                    string playerName = Console.ReadLine();
                    Score playerScore = new Score(playerName, this.scoreCounter);
                    this.topScorers.Add(playerScore);
                    this.PrintRanking(this.topScorers);
                    this.field = this.CreateGameField();
                    this.bombs = this.PlaceBombs();
                    this.scoreCounter = 0;
                    this.playerWon = false;
                    this.gameIsOver = true;
                }
            }
            while (this.command != "exit");

            // intentionally left so
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private void PrintRanking(List<Score> scores)
        {
            Console.WriteLine("\nScoreboard:");
            if (scores.Count > 0)
            {
                for (int i = 0; i < scores.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes", i + 1, scores[i].Name, scores[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No one in the rankings yet.\n");
            }
        }

        private void PrintField(char[,] board)
        {
            int rows = board.GetLength(0);
            int colums = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < colums; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private char[,] CreateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private char[,] PlaceBombs()
        {
            int rows = 5;
            int colums = 10;
            char[,] playField = new char[rows, colums];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    playField[i, j] = '-';
                }
            }

            var randomBombsIndexes = new List<int>();

            while (randomBombsIndexes.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!randomBombsIndexes.Contains(randomNumber))
                {
                    randomBombsIndexes.Add(randomNumber);
                }
            }

            foreach (int bombIndex in randomBombsIndexes)
            {
                int column = bombIndex / colums;
                int row = bombIndex % colums;
                if (row == 0 && bombIndex != 0)
                {
                    column--;
                    row = colums;
                }
                else
                {
                    row++;
                }

                playField[column, row - 1] = '*';
            }

            return playField;
        }

        private void UpdateBombsCount(char[,] field)
        {
            int rows = field.GetLength(0);
            int columns = field.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char nearbyBombsCount = this.NearbyBombs(field, i, j);
                        this.field[i, j] = nearbyBombsCount;
                    }
                }
            }
        }

        private char NearbyBombs(char[,] field, int row, int column)
        {
            int count = 0;
            int rows = field.GetLength(0);
            int colums = field.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field[row - 1, column] == '*')
                {
                    count++;
                }
            }

            if (row + 1 < rows)
            {
                if (field[row + 1, column] == '*')
                {
                    count++;
                }
            }

            if (column - 1 >= 0)
            {
                if (field[row, column - 1] == '*')
                {
                    count++;
                }
            }

            if (column + 1 < colums)
            {
                if (field[row, column + 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (field[row - 1, column - 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < colums))
            {
                if (field[row - 1, column + 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                if (field[row + 1, column - 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (column + 1 < colums))
            {
                if (field[row + 1, column + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }

        private void UpdateField(char[,] field, char[,] bombs, int row, int column)
        {
            char nearbyBombsCount = this.NearbyBombs(bombs, row, column);
            this.bombs[row, column] = nearbyBombsCount;
            this.field[row, column] = nearbyBombsCount;
        }
    }
}
