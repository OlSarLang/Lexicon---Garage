using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    class Bus : Vehicle
    {
        public int Seats { get; set; }

        public Bus(int seats = 0, string regNr = "XXXXXX", string maker = "Unknown", string color = "Unknown", int wheels = 4) : base(regNr, maker, color, wheels)
        {
            Seats = seats;
        }

        public override string PrintStats()
        {
            return base.PrintStats() + $"\nSeats: {Seats}";
        }
    }
}
