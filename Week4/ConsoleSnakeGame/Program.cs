using System;

namespace ConsoleSnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            while (game.IsRunning)
            {
                game.KeyPressed(Console.ReadKey());
            }
        }
    }
}
