using System;

namespace Connect4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] gameboard = new string[6, 7];
            bool gameOver = false;
            int turn = 0;
            int inputRow;
            int turnSpotX = 0;
            int turnSpotY = 0;
            var x = 0;
            var y = 0;

            if (turn == 0)
            {
                newGame();
            }

            
            do
            {
                inputRow = playerInput();
                Console.Clear();
                updateGameboard(inputRow);
                turn++;
                PrintGameBoard();
                winChecker();

            } while (gameOver != true);

            void PrintGameBoard()
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

            void newGame()
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

            int playerInput()
            {
                Console.Write("Enter Row: ");
                int returnLine = 0;
                bool isNumber = false;
                string input = Console.ReadLine();

                if (input == "new game")
                {
                    newGame();
                }

                try
                {
                    isNumber = Int32.TryParse(input, out returnLine);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Please use a number");
                }

                if (isNumber != true)
                {
                    return playerInput();
                }

                if (returnLine >= 1 && returnLine <= 7)
                {
                    return returnLine - 1;
                }
                else
                {
                    Console.WriteLine("Please enter number -> 1-7");
                    returnLine = playerInput();
                }
                return returnLine;
            }

            void updateGameboard(int x)
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
                            gameboard[i,x] = gameboard[i,x].Replace("X","B");
                            turnSpotX = x;
                            turnSpotY = i;
                        }
                        else
                        {
                            gameboard[i,x] = gameboard[i, x].Replace("X","R");
                            turnSpotX = x;
                            turnSpotY = i;
                        }
                        break;
                    }
                }
            }

            void winChecker()
            {
                var cVar = "";
                var count = 0;

                //Check Horizontal -
                for(int i = 0; i < gameboard.GetLength(0); i++)
                {
                    for(int u = 0; u < gameboard.GetLength(1); u++)
                    {
                        if (gameboard[i, u] == cVar && gameboard[i, u] != "X")
                        {
                            count++;
                        }
                        else
                        {
                            cVar = gameboard[i, u];
                            count = 1;
                        }

                        if (count == 4)
                        {
                            //Console.WriteLine("Hor: " + u + "-" + i);
                            GameOver(cVar);
                        }
                    }
                    count = 0;
                }
                //Check Vertical |
                for (int u = 0; u < gameboard.GetLength(1); u++)
                {
                    for (int i = 0; i < gameboard.GetLength(0); i++)
                    {
                        if (gameboard[i, u] == cVar && gameboard[i, u] != "X")
                        {
                            count++;
                        }
                        else
                        {
                            cVar = gameboard[i, u];
                            count = 1;
                        }

                        if (count == 4)
                        {
                            //Console.WriteLine("Vert: " + u + "-" + i);
                            GameOver(cVar);
                        }
                    }
                    count = 0;
                }

                //Check Diagonal /\
                for (int u = 0; u < 4; u++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        cVar = "X";
                        x = i;
                        y = u;
                        var checks = 0;
                        while (checks < 4)
                        {
                            if (gameboard[x, y] == cVar && gameboard[x, y] != "X")
                            {
                                count++;
                            }
                            else
                            {
                                cVar = gameboard[x, y];
                                count = 1;
                            }

                            if (count == 4)
                            {
                                //Console.WriteLine("Dia: " + x + "-" + y);
                                GameOver(cVar);
                            }

                            x++;
                            y++;
                            checks++;
                        }
                    }
                    count = 0;
                }

                for (int u = 6; u > 2; u--)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        cVar = "X";
                        x = i;
                        y = u;
                        var checks = 0;
                        while (checks < 4)
                        {
                            if (gameboard[x, y] == cVar && gameboard[x, y] != "X")
                            {
                                count++;
                            }
                            else
                            {
                                cVar = gameboard[x, y];
                                count = 1;
                            }

                            if (count == 4)
                            {
                                //Console.WriteLine("Dia: " + x + "-" + y);
                                GameOver(cVar);
                            }
                            x++;
                            y--;
                            checks++;
                        }
                    }
                    count = 0;
                }

                if (turn >= 43)
                {
                    GameOver("draw");
                }

            }

            void GameOver(string c)
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
}
