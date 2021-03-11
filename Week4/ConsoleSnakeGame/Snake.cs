using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleSnakeGame
{
    class Snake : GameObject
    {
        public Point head;

        public int Dx { get; set; }
        public int Dy { get; set; }

        public Snake() : base()
        {

        }

        public Snake(char sign, ConsoleColor color) : base(sign, color)
        {
            this.head = new Point { X = 20, Y = 20 };
            body.Add(head);
            Draw();
        }

        public void Move()
        {
            Clear();

            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }

            body[0].X += Dx;
            body[0].Y += Dy;



            Draw();
        }

        public void ChangeDirection(int dx, int dy)
        {
            Dx = dx;
            Dy = dy;
        }

        public void Increase(Point point)
        {
            body.Add(new Point { X = point.X, Y = point.Y });
        }

        public bool IsHit(Point p)
        {
           for(int i = body.Count - 2; i > 0 ; i--)
            {
                if (body[i].Equals(p))
                {
                    return true;
                }
            }
            return false;
        }

        public void Save(string title)
        {
            using (FileStream fs = new FileStream(title + ".xml", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Snake));
                xs.Serialize(fs, this);
            }
        }

        public static Snake Load(string title)
        {
            Snake res = null;
            using (FileStream fs = new FileStream(title + ".xml", FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Snake));
                res = xs.Deserialize(fs) as Snake;
            }
            return res;
        }
    }
}
