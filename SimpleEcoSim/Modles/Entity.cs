using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcoSim.Modles
{
    abstract class Entity
    {
        public string Sign { get; set; }
        public Tuple<int, int> pos { get; set; }

        public void Draw()
        {
            Console.CursorLeft = pos.Item1;
            Console.CursorTop = pos.Item2;
            Console.Write(Sign);
        }

    }
}
