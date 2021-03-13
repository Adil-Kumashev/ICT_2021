using System;


namespace ConsoleSnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\Adil\source\repos\ConsoleSnakeGame\snake_music.wav");
            void PlayAudio()
            {
                player.PlayLooping();
            }

           // PlayAudio();
            Game game = new Game();
            while (game.IsRunning)
            {
                game.KeyPressed(Console.ReadKey(true));
            }
        }
    }
}
