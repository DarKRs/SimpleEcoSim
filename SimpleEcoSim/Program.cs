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
            AnimalService animalService = new AnimalService(10, 15, 5);
            MovementService movementService = new MovementService(animalService);
            do
            {
                while (!Console.KeyAvailable)
                {
                    ConsoleService.DrawAll(animalService.Items);
                    movementService.MoveAll();
                    Thread.Sleep(1000);
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Q);
        }





    }
}