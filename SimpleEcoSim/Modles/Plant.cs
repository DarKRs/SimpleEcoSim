using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcoSim.Modles
{
    internal class Plant : Entity
    {
        public Plant(Tuple<int,int> position) {
            Sign = "*";
            pos = position;
        }



    }
}
