using SimpleEcoSim.Modles;
using SimpleEcoSim.Services;
using System;
using System.Drawing;

namespace SimpleEcoSim
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.Clear();
            ConsoleService.Init();
            AnimalService animalService = new AnimalService(10, 25, 0);
            do
            {
                while (!Console.KeyAvailable)
                {
                    ConsoleService.DrawAll(animalService.GetItems());
                    Thread.Sleep(1000);
                    animalService.AddPlant(1);
                    Thread.Sleep(1000);
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Q);
        }





    }
}