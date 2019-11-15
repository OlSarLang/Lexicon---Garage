using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    class Car : Vehicle
    {
        public string FuelType { get; set; }

        public Car(string fuelType = "Unknown", string regNr = "XXXXXX", string maker = "Unknown", string color = "Unknown", int wheels = 4) : base(regNr, maker, color, wheels)
        {
            FuelType = fuelType;
        }

        public override string PrintStats()
        {
            return base.PrintStats() + $"\nFuel type: {FuelType}";
        }
    }
}
