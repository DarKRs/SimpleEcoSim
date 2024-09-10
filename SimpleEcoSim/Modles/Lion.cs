using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcoSim.Modles
{
    internal class Lion : Entity, IMovable
    {
        public Lion()
        {
            Sign = 'L';
            Speed = 1;
        }

        public Lion(Point position)
        {
            Sign = 'L';
            pos = position;
            Speed = 2;
        }

        public void Move(Point direction)
        {
            pos = new Point(pos.X + direction.X, pos.Y + direction.Y);
        }
    }
}
