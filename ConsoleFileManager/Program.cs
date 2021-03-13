using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ConsoleFileManager
{

    class Layer
    {
        public DirectoryInfo dir
        {
            get;
            set;
        }
        public int pos
        {
            get;
            set;
        }
        public List<FileSystemInfo> content
        {
            get;
            set;
        }

        public Layer(DirectoryInfo dir, int pos)
        {
            this.dir = dir;
            this.pos = pos;
            this.content = new List<FileSystemInfo>();

            content.AddRange(this.dir.GetDirectories());
            content.AddRange(this.dir.GetFiles());
        }
        private static string Indent(int len) { return new string('\t', Math.Max(len, 0)); }

        public void PrintInfo()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            int cnt = 0;

            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                if (cnt == pos)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else Console.BackgroundColor = ConsoleColor.Black;

                Console.WriteLine(d.Name);
                cnt++;
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            foreach (FileInfo f in dir.GetFiles())
            {
                if (cnt == pos)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else Console.BackgroundColor = ConsoleColor.Black;

                FileInfo curFileInfo = new FileInfo(f.FullName);
                string indentForRender = Indent(5 - ((int)(f.Name.Length / 8)));
                string fileSize = indentForRender + "<DIR>";
                if (curFileInfo.Exists) fileSize = "\t" +  indentForRender + curFileInfo.Length.ToString() + " bytes";
                Console.WriteLine(f.Name + fileSize);

                cnt++;
            }
        }

        public FileSystemInfo GetCurrentObject()
        {
            return content[pos];
        }

        public void SetNewPosition(int d)
        {
            if (d > 0)
            {
                pos++;
            }
            else
            {
                pos--;
            }

            if (pos >= content.Count)
            {
                pos = 0;
            }
            else if (pos < 0)
            {
                pos = content.Count - 1;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            F3();
        }

        private static void F3()
        {

            Stack<Layer> history = new Stack<Layer>();
            history.Push(new Layer(new DirectoryInfo(@"C:\Users\Adil\Desktop"), 0));

            bool escape = false;
            char simbol;

            while (!escape)
            {
                Console.Clear();

                history.Peek().PrintInfo();
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);

                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        if (history.Peek().GetCurrentObject().GetType() == typeof(DirectoryInfo))
                        {
                            history.Push(new Layer(history.Peek().GetCurrentObject() as DirectoryInfo, 0));
                        }
                        else if (history.Peek().GetCurrentObject().GetType() == typeof(FileInfo))
                        {
                            string fs = history.Peek().GetCurrentObject().FullName;

                            Process.Start(new ProcessStartInfo(fs) { UseShellExecute = true });
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        history.Peek().SetNewPosition(-1);
                        break;
                    case ConsoleKey.DownArrow:
                        history.Peek().SetNewPosition(1);
                        break;
                    case ConsoleKey.Escape:
                        escape = true;
                        break;
                    case ConsoleKey.Tab:
                        history.Pop();
                        break;
                    case ConsoleKey.Backspace:
                        string fileToDelete = history.Peek().GetCurrentObject().FullName;
                        Console.WriteLine("Are you sure, that you want to delete this file? y/n");
                        simbol = (char)Console.Read();
                        if(simbol == 'y')
                        {
                            File.Delete(fileToDelete);
                            Console.WriteLine("${fileToDelete } is deleted");
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else if (simbol == 'n')
                        {
                            Console.WriteLine("Operation canceled");
                        }
                        else
                        {
                            continue;
                        }
                        break;
                }
            }
        }
    }
}
