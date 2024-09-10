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
            AnimalService animalService = new AnimalService(10, 5, 1);
            MovementService movementService = new MovementService(animalService);
            do
            {
                while (!Console.KeyAvailable)
                {
                    ConsoleService.DrawAll(animalService.Items);
                    movementService.MoveAll();
                    Thread.Sleep(300);
                    if(rnd.Next(100) > 70)
                        animalService.AddItems<Plant>(1);

                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Q);
        }





    }
}