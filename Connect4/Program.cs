using System;

namespace Connect4
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            do
            {
                game.playerInput();
                Console.Clear();
                game.updateGameboard(game.inputRow);
                game.turn++;
                game.PrintGameBoard();
                GameRules.winChecker(game);

            } while (!game.gameOver);
            Console.WriteLine("Thanks for Playing!");
        }
    }
}
