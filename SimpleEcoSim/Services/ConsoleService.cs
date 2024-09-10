using SimpleEcoSim.Modles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcoSim.Services
{
    internal static class ConsoleService
    {
        // Установка размеров буфера и окна
        const int BufferWidth = 120;
        const int BufferHeight = 40;
        public const int WindowWidth = 120;
        public const int WindowHeight = 40;

        static List<Rectangle> dirtyRectangles = new List<Rectangle>();
        static char[,] buffer;



        public static void Init()
        {
            SetConsoleSize();
            InitializeBuffer();
            RenderBuffer();
        }

        public static void DrawAll(List<Entity> items)
        {
            ClearDirtyRect();
            InitializeBuffer();
            foreach (Entity item in items)
            {
                buffer[item.pos.X, item.pos.Y] = item.Sign;
                dirtyRectangles.Add(new Rectangle(item.pos.X, item.pos.Y, 1, 1));
            }
            RenderNew();
        }


        static void ClearDirtyRect()
        {
            foreach (var rect in dirtyRectangles)
            {
                Console.SetCursorPosition(rect.X, rect.Y);
                Console.Write('.');
            }
        }

        static void RenderNew()
        {
            foreach (var rect in dirtyRectangles)
            {
                Console.SetCursorPosition(rect.X, rect.Y);
                Console.Write(buffer[rect.X, rect.Y]);
            }
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



            try
            {
                Console.SetBufferSize(
                    Math.Min(BufferWidth, maxBufferWidth),
                    Math.Min(BufferHeight, maxBufferHeight)
                );

                Console.SetWindowSize(
                    Math.Min(WindowWidth, maxWindowWidth),
                    Math.Min(WindowHeight, maxWindowHeight)
                );
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error setting console size: {ex.Message}");
            }
        }

    }
}
