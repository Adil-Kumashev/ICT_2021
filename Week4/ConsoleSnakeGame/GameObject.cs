using System;
using System.Collections.Generic;

namespace ConsoleSnakeGame
{
    abstract class GameObject
    {
        protected char sign;
        protected ConsoleColor color;
        public List<Point> body;

        public GameObject(char sign, ConsoleColor color)
        {
            this.sign = sign;
            this.color = color;
            this.body = new List<Point>();
        }

        public GameObject()
        {

        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            for(int i = 0; i < body.Count; ++i)
            {
                Console.SetCursorPosition(body[i].X, body[i].Y);
                Console.Write(sign);
            }
        }

        public void Clear()
        {
            for(int i = 0; i < body.Count; ++i)
            {
                Console.SetCursorPosition(body[i].X, body[i].Y);
                Console.Write(' ');
            }
        }
    }
}
