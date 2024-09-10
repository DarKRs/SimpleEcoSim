using SimpleEcoSim.Modles;
using SimpleEcoSim.Services;
using System;

namespace SimpleEcoSim
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Console.Clear();
            ConsoleService.Init();
            List<Entity> items = new List<Entity>();
            Random rnd = new Random();
            for(int i = 0; i < rnd.Next(20); i++)
            {
                items.Add(new Plant(Tuple.Create(rnd.Next(120), rnd.Next(40))));
            }
            do
            {
                while (!Console.KeyAvailable)
                {
                    ConsoleService.DrawAll(items);
                    Thread.Sleep(1000);
                    items.Add(new Plant(Tuple.Create(rnd.Next(120), rnd.Next(40))));
                    Thread.Sleep(1000);
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Q);
        }





    }
}