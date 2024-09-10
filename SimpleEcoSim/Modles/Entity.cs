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
        Tuple<int, int> pos { get; set; }

    }
}
