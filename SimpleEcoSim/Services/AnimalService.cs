using SimpleEcoSim.Modles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcoSim.Services
{
    internal class AnimalService
    {
        int maxPlants;
        int maxAntipoles;
        int maxLions;
        List<Entity> items = new List<Entity>();
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
            AddItems<Antilope>(maxAntipoles);
        }

        void AddItems<T>(int count) where T : Entity, new()
        {
            for (int i = 0; i < count; i++)
            {
                items.Add(new T { pos = new Point(rnd.Next(120), rnd.Next(40)) });
            }
        }

        public void AddPlant(int count = 1)
        {
 
        }

        public List<Entity> GetItems()
        {
            return items;
        }
    }
}
