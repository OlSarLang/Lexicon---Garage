using System;

namespace Garage
{
    internal class VehicleEventArgs : EventArgs
    {
        public Vehicle Vehicle { get; set; }
    }
}