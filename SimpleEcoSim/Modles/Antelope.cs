using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcoSim.Modles
{
    internal class Antelope :Entity, IMovable
    {
        public Antelope()
        {
            Sign = 'A';
            Speed = 2;
        }

        public Antelope(Point position)
        {
            Sign = 'A';
            pos = position;
            Speed = 2;
        }

        public void Move(Point direction)
        {
            pos = new Point(pos.X + direction.X, pos.Y + direction.Y);
        }
    }
}
