using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    class Boat : Vehicle
    {
        public double Length { get; set; }

        public Boat(double length = 0.0, string regNr = "XXXXXX", string maker = "Unknown", string color = "Unknown", int wheels = 0) : base(regNr, maker, color, wheels)
        {
            Length = length;
        }

        public override string PrintStats()
        {
            return base.PrintStats() + $"\nLength: {Length}";
        }
    }
}
