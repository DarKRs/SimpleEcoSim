using SimpleEcoSim.Modles;
using System;

namespace SimpleEcoSim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Entity> items = new List<Entity>();
            SetConsoleSize();
            Random rnd = new Random();
            while(Console.ReadKey().Key != ConsoleKey.Q)
            {
                items.Add(new Plant(Tuple.Create(rnd.Next(800), rnd.Next(600))));
                DrawAll(items);

            }
        }

        static void DrawAll(List<Entity> items) {
            foreach (Entity item in items)
            {
                item.Draw();
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
            int newBufferWidth = 900; 
            int newBufferHeight = 700;
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