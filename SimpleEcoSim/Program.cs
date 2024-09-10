using System;

namespace SimpleEcoSim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(800, 600);
            Random rnd = new Random();
            while(Console.ReadKey().Key != ConsoleKey.Q)
            {
                
                rnd.Next(0,800);
            }
        }
    }
}