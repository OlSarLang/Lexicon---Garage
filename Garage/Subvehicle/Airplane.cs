
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    class Airplane : Vehicle
    {

        public int Engines { get; set; }
        public Airplane(int engines = 0, string regNr = "XXXXXX", string maker = "Unknown", string color = "Unknown", int wheels = 0) : base(regNr, maker, color, wheels)
        {
            Engines = engines;
        }

        public override string PrintStats()
        {
            return base.PrintStats() + $"\nAmount of engines: {Engines}";
        }
    }
}
