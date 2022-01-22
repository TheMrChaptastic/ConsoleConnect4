using System;

namespace Connect4
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.newGame();
            do
            {
                var inputRow = game.playerInput();
                Console.Clear();
                game.updateGameboard(inputRow);
                game.turn++;
                game.PrintGameBoard();
                GameRules.winChecker(game);

            } while (!game.gameOver);
        }
    }
}
