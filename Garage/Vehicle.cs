using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    class Vehicle
    {

        public int Wheels { get; set; }
        public string Color { get; set; }
        public string Maker { get; set; }
        public string RegNr { get; set; }
        public Vehicle(string regNr, string maker, string color, int wheels) {
            Wheels = wheels;
            Color = color;
            Maker = maker;
            RegNr = regNr;
        }

        public virtual string PrintStats()
        {
            return $"Vehicle added:\n" +
                $"Registration/Serialnumber: {Wheels}\n" +
                $"Manufacturer: {Maker}\n" +
                $"Color: {Color}\n" +
                $"Amount of wheels: {Wheels}";
        }

    }
}
