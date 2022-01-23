using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    public class Game
    {
        public Game()
        {
            newGame();
        }
        public string[,] gameboard = new string[6, 7];
        public bool gameOver { get; set; } = false;
        public int turn { get; set; } = 0;
        public int inputRow { get; set; }
        public int turnSpotX { get; set; } = 0;
        public int turnSpotY { get; set; } = 0;
        public void PrintGameBoard()
        {
            Console.WriteLine("Player 1 = R | Player 2 = B");
            Console.WriteLine("1  2  3  4  5  6  7");
            for (int i = 0; i < gameboard.GetLength(0); i++)
            {
                for (int u = 0; u < gameboard.GetLength(1); u++)
                {
                    Console.Write(gameboard[i, u] + "  ");
                }
                Console.Write("\n");
            }
            if (turn % 2 == 0)
            {
                Console.WriteLine("Player 2(Blue) Turn " + turn);
            }
            else
            {
                Console.WriteLine("Player 1(Red) Turn " + turn);
            }
        }
        public void newGame()
        {
            for (int i = 0; i < gameboard.GetLength(0); i++)
            {
                for (int u = 0; u < gameboard.GetLength(1); u++)
                {
                    gameboard[i, u] = "X";
                }
            }
            Console.Clear();
            turn = 1;
            Console.WriteLine("New Game Created");
            Console.WriteLine("Player 1 = R | Player 2 = B");
            Console.WriteLine("1  2  3  4  5  6  7");
            for (int i = 0; i < gameboard.GetLength(0); i++)
            {
                for (int u = 0; u < gameboard.GetLength(1); u++)
                {
                    Console.Write(gameboard[i, u] + "  ");
                }
                Console.Write("\n");
            }
            if (turn % 2 == 0)
            {
                Console.WriteLine("Player 2(Blue) Turn " + turn);
            }
            else
            {
                Console.WriteLine("Player 1(Red) Turn " + turn);
            }
        }
        public void playerInput()
        {
            int returnLine = 0;
            bool isNumber = false;
            string input = "";
            inputRow = 0;

            while (!isNumber)
            {
                Console.Write("Enter Row: ");
                input = Console.ReadLine();
                isNumber = Int32.TryParse(input, out returnLine);
                if (returnLine > 7 || returnLine < 1)
                {
                    isNumber = false;
                }
            }
            inputRow = returnLine - 1;
        }
        public void updateGameboard(int x)
        {
            for (int i = 5; i >= 0; i--)
            {
                if (i == 0 && gameboard[i, x] != "X")
                {
                    turn--;
                }

                if (gameboard[i, x] == "X")
                {
                    if (turn % 2 == 0)
                    {
                        gameboard[i, x] = gameboard[i, x].Replace("X", "B");
                        turnSpotX = x;
                        turnSpotY = i;
                    }
                    else
                    {
                        gameboard[i, x] = gameboard[i, x].Replace("X", "R");
                        turnSpotX = x;
                        turnSpotY = i;
                    }
                    break;
                }
            }
        }
        public void GameOver(string c)
        {
            var newGamePrompt = "";
            if (c == "draw")
            {
                Console.WriteLine($"Game ended in a draw...");
                Console.WriteLine("New game: (Y, N)");
                newGamePrompt = Console.ReadLine();
                if (newGamePrompt.ToLower() == "y")
                {
                    newGame();
                }
                else
                {
                    gameOver = true;
                }
            }
            else if (c == "B")
            {
                Console.WriteLine($"BLUE WINS IN {turn - 1} TURNS!!!");
                Console.WriteLine("New game: (Y, N)");
                newGamePrompt = Console.ReadLine();
                if (newGamePrompt.ToLower() == "y")
                {
                    newGame();
                }
                else
                {
                    gameOver = true;
                }
            }
            else
            {
                Console.WriteLine($"RED WINS IN {turn - 1} TURNS!!!");
                Console.WriteLine("New game: (y, n)");
                newGamePrompt = Console.ReadLine();
                if (newGamePrompt.ToLower() == "y")
                {
                    newGame();
                }
                else
                {
                    gameOver = true;
                }
            }
        }
    }
}
