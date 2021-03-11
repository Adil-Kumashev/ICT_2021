using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnakeGame
{
    class Food : GameObject
    {
        Wall wall = new Wall('#', ConsoleColor.Red, @"C:\Users\Adil\source\repos\Week4\ConsoleSnakeGame\Map.txt");
        Snake snake = new Snake('@', ConsoleColor.White);
        Random rnd = new Random();
        public Food(char sign, ConsoleColor color) : base(sign, color)
        {
            Point location = new Point { X = rnd.Next(1, Game.Width), Y = rnd.Next(1, Game.Height) };
            body.Add(location);
            Draw();
        }
        public void Generate()
        {
             case1:
                body[0].X = rnd.Next(1, 99);
                body[0].Y = rnd.Next(1, 29);
                Point point = new Point { X = body[0].X, Y = body[0].Y };

            bool flag = wall.IsHit(point) && snake.IsHit(point);
            if (flag == false)
            {
                Draw();
            }
            else
            {
                goto case1;
            }
        }
    }
}
