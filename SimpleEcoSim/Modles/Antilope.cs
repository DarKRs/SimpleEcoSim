using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcoSim.Modles
{
    internal class Antilope :Entity, IMovable
    {
        public Antilope()
        {
            Sign = 'A';
            Speed = 2;
        }

        public Antilope(Point position)
        {
            Sign = 'A';
            pos = position;
            Speed = 2;
        }

        public void Move(int addX, int addY)
        {
            pos.Offset(addX, addY);
        }
    }
}
