using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcoSim.Modles
{
    internal class Plant : Entity
    {
        public Plant() {
            Sign = '*';
            Speed = 0;
        }

        public Plant(Point position) {
            Sign = '*';
            pos = position;
            Speed = 0;
        }



    }
}
