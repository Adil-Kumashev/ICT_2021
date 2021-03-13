﻿using System;
using System.Timers;
using System.Media;

namespace ConsoleSnakeGame
{
    class Game
    {
        int point = 0;
        Timer snakeTimer = new Timer(100);
        Timer gameTimer = new Timer(1000);

        public static int Width { get { return 100; } }
        public static int Height { get { return 30; } }

        Snake snakeObj = new Snake('@', ConsoleColor.White);
        Wall wallObj = new Wall('#', ConsoleColor.Red, @"C:\Users\Adil\source\repos\ConsoleSnakeGame\maps\map1.txt");
        Food foodObj = new Food('*', ConsoleColor.Green);

        public bool IsRunning { get; set; }

        bool pause = false;
        bool nextLevel = true;

        public Game()
        {
            gameTimer.Elapsed += GameTimer_Elapsed;
            gameTimer.Start();
            snakeTimer.Elapsed += Move2;
            snakeTimer.Start();

            pause = false;
            IsRunning = true;
            Console.CursorVisible = false;
            Console.SetWindowSize(Width, Height);
            Console.SetBufferSize(Width, Height);

        }

        bool CheckCollisionFoodWithSnake()
        {
            return snakeObj.body[0].X == foodObj.body[0].X && snakeObj.body[0].Y == foodObj.body[0].Y;
        }

        void Move2(object sender, ElapsedEventArgs e)
        {
            snakeObj.Move();
            if (CheckCollisionFoodWithSnake())
            {
                snakeObj.Increase(snakeObj.body[0]);
                point++;
                foodObj.Generate();
            }
            if (wallObj.IsHit(snakeObj.head))
            {
                IsRunning = false;
                Console.Clear();
                snakeTimer.Stop();
                pause = true;
                Console.WriteLine("Snakes do not eat bricks!!!");
            }
            if (snakeObj.IsHit(snakeObj.head))
            {
                IsRunning = false;
                Console.Clear();
                snakeTimer.Stop();
                pause = true;
                Console.WriteLine("Snakes do not eat themselves!!!");
            }
        }

        DateTime start = DateTime.Now;

        private void GameTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.Title = "Time passed: " + (DateTime.Now - start).Minutes + " MIN. " + (DateTime.Now - start).Seconds + " SEC." + " Current points: " + point;
        }

        public void KeyPressed(ConsoleKeyInfo pressedKey)
        {
            switch (pressedKey.Key)
            {
                case ConsoleKey.UpArrow:
                    if(snakeObj.Dy != 1)
                    {
                        snakeObj.ChangeDirection(0, -1);
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if(snakeObj.Dy != -1)
                    {
                    snakeObj.ChangeDirection(0, 1);
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if(snakeObj.Dx != 1)
                    {
                    snakeObj.ChangeDirection(-1, 0);
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if(snakeObj.Dx != -1)
                    {
                    snakeObj.ChangeDirection(1, 0);
                    }
                    break;
                case ConsoleKey.Escape:
                    Console.Clear();
                    IsRunning = false;
                    break;
                case ConsoleKey.S:
                    snakeObj.Save("snake");
                    break;
                case ConsoleKey.L:
                    snakeTimer.Stop();
                    Console.Clear();
                    foodObj = new Food('*', ConsoleColor.Green);
                    wallObj = new Wall('#', ConsoleColor.Red, @"C:\Users\Adil\source\repos\ConsoleSnakeGame\maps\map1.txt");
                    snakeObj = Snake.Load("snake");
                    snakeTimer.Start();
                    break;
                case ConsoleKey.Spacebar:
                    if (!pause)
                    {
                        snakeTimer.Stop();
                        pause = true;
                    }
                    else
                    {
                        snakeTimer.Start();
                        pause = false;
                    }
                    break;            
            }
            if (snakeObj.body.Count > 3 )
            {
                Console.Clear();
                wallObj = new Wall('#', ConsoleColor.Red, @"C:\Users\Adil\source\repos\ConsoleSnakeGame\maps\map2.txt");
                foodObj = new Food('*', ConsoleColor.Green);
            }
        }
    }
}
