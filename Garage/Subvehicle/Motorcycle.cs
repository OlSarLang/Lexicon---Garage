using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    class Motorcycle : Vehicle
    {
        public double CylinderVolume { get; set; }

        public Motorcycle(double cylinderVolume = 0.0, string regNr = "XXXXXX", string maker = "Unknown", string color = "Unknown", int wheels = 2) : base(regNr, maker, color, wheels)
        {
            CylinderVolume = cylinderVolume;
        }

        public override string PrintStats()
        {
            return base.PrintStats() + $"\nCylinder volume: {CylinderVolume}";
        }
    }
}
