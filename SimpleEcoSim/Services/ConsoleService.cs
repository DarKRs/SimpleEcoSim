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
        const int BufferWidth = 120;
        const int BufferHeight = 40;
        public const int WindowWidth = 120;
        public const int WindowHeight = 40;

        static char[,] buffer;
        static HashSet<Rectangle> dirtyRectangles = new HashSet<Rectangle>();

        public static void Init()
        {
            SetConsoleSize();
            InitializeBuffer();
            RenderBuffer();
        }

        public static void DrawAll(List<Entity> items)
        {
            ClearDirtyRect();
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
                // Заполняем очищенные области символом ' '
                for (int y = rect.Y; y < rect.Bottom; y++)
                {
                    for (int x = rect.X; x < rect.Right; x++)
                    {
                        buffer[x, y] = ' ';
                    }
                }
            }
            dirtyRectangles.Clear();
        }

        static void RenderNew()
        {
            var sb = new StringBuilder();
            for (int y = 0; y < WindowHeight; y++)
            {
                for (int x = 0; x < WindowWidth; x++)
                {
                    sb.Append(buffer[x, y]);
                }
                sb.AppendLine();
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(sb.ToString());
        }

        static void RenderBuffer()
        {
            var sb = new StringBuilder();
            for (int y = 0; y < WindowHeight; y++)
            {
                for (int x = 0; x < WindowWidth; x++)
                {
                    sb.Append(buffer[x, y]);
                }
                sb.AppendLine();
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(sb.ToString());
        }

        static void InitializeBuffer()
        {
            buffer = new char[WindowWidth, WindowHeight];
            for (int i = 0; i < WindowWidth; i++)
            {
                for (int j = 0; j < WindowHeight; j++)
                {
                    buffer[i, j] = ' ';
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
