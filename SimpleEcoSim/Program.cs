using SimpleEcoSim.Modles;
using System;

namespace SimpleEcoSim
{
    internal class Program
    {
        static char[,] buffer;

        static void Main(string[] args)
        {
            List<Entity> items = new List<Entity>();
            SetConsoleSize();
            InitializeBuffer();
            Random rnd = new Random();
            for(int i = 0; i < rnd.Next(20); i++)
            {
                items.Add(new Plant(Tuple.Create(rnd.Next(120), rnd.Next(40))));
            }
            do
            {
                while (!Console.KeyAvailable)
                {
                    DrawAll(items);
                    Thread.Sleep(1000);
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Q);
        }

        static void DrawAll(List<Entity> items) {
            InitializeBuffer();
            foreach (Entity item in items)
            {
                buffer[item.pos.Item1, item.pos.Item2] = item.Sign;
            }
            RenderBuffer();
        }

        static void RenderBuffer()
        {
            for (int y = 0; y < Console.WindowHeight; y++)
            {
                for (int x = 0; x < Console.WindowWidth; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(buffer[x, y]);
                }
            }
        }


        static void InitializeBuffer()
        {
            buffer = new char[Console.WindowWidth, Console.WindowHeight];
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                for (int j = 0; j < Console.WindowHeight; j++)
                {
                    buffer[i, j] = '.';
                }
            }
        }



        static void SetConsoleSize()
        {
            var currentBufferSize = Console.BufferWidth;
            var currentWindowSize = Console.WindowWidth;

            const int maxBufferWidth = 8191;
            const int maxBufferHeight = 30000;
            const int maxWindowWidth = 8191;
            const int maxWindowHeight = 30000;

            // Установка размеров буфера и окна
            int newBufferWidth = 120; 
            int newBufferHeight = 40;
            int newWindowWidth = 120;
            int newWindowHeight = 40;

            try
            {
                Console.SetBufferSize(
                    Math.Min(newBufferWidth, maxBufferWidth),
                    Math.Min(newBufferHeight, maxBufferHeight)
                );

                Console.SetWindowSize(
                    Math.Min(newWindowWidth, maxWindowWidth),
                    Math.Min(newWindowHeight, maxWindowHeight)
                );
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error setting console size: {ex.Message}");
            }
        }
    }
}