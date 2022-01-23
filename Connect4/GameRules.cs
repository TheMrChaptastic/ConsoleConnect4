using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    static class GameRules
    {
        public static void winChecker(Game game)
        {
            var gameboard = game.gameboard;
            var cVar = "";
            var count = 0;
            var x = 0;
            var y = 0;
            //Check Horizontal -
            for (int i = 0; i < gameboard.GetLength(0); i++)
            {
                for (int u = 0; u < gameboard.GetLength(1); u++)
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
                        game.GameOver(cVar);
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
                        game.GameOver(cVar);
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
                            game.GameOver(cVar);
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
                            game.GameOver(cVar);
                        }
                        x++;
                        y--;
                        checks++;
                    }
                }
                count = 0;
            }
            //End line checks and check turns to see if can continue filling board
            if (game.turn >= 43)
            {
                game.GameOver("draw");
            }
        }
    }
}
