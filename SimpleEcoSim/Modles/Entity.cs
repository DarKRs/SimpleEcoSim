using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcoSim.Modles
{
    public abstract class Entity
    {
        public char Sign { get; set; }
        public Point pos { get; set; }

        public int Speed { get; set; }

        public void Draw()
        {
            Console.CursorLeft = pos.X;
            Console.CursorTop = pos.Y;
            Console.Write(Sign);
        }

    }
}
