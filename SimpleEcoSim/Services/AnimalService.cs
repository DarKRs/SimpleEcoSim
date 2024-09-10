using SimpleEcoSim.Modles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcoSim.Services
{
    public class AnimalService
    {
        int maxPlants;
        int maxAntipoles;
        int maxLions;
        public HashSet<Point> occupiedPositions = new HashSet<Point>();
        public List<Entity> Items = new List<Entity>();
        Random rnd = new Random();

        public AnimalService(int plants, int antilopes, int lions) {
            maxPlants = plants;
            maxAntipoles = antilopes;
            maxLions = lions;
            Init();
        }


        private void Init()
        {
            AddItems<Plant>(maxPlants);
            AddItems<Antelope>(maxAntipoles);
            AddItems<Lion>(maxAntipoles);
        }

        public void AddItems<T>(int count = 1) where T : Entity, new()
        {
            for (int i = 0; i < count; i++)
            {
                Point freePosition = FindFreePosition(); 
                occupiedPositions.Add(freePosition);    
                Items.Add(new T { pos = freePosition });
            }
        }



        Point FindFreePosition()
        {
            Point newPosition;
            int maxAttempts = 10; // Лимит попыток, чтобы избежать бесконечных циклов
            int attempts = 0;

            do
            {
                newPosition = new Point(rnd.Next(ConsoleService.WindowWidth), rnd.Next(ConsoleService.WindowHeight));
                attempts++;
            }
            while (occupiedPositions.Contains(newPosition) && attempts < maxAttempts);

            if (attempts >= maxAttempts)
            {
                throw new InvalidOperationException("Не удалось найти свободное место");
            }

            return newPosition;
        }
    }
}
