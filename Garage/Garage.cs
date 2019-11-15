using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage
{
    class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] Vehicles { get; set; }

        public int Capacity { get; set; }
        public int Occupancy { get; set; }
        public bool Sorted { get; set; }

        public string Name { get; set; }

        public event EventHandler<VehicleEventArgs> parkedEvent;

        public Garage(string name, int capacity)
        {
            Vehicles = new T[capacity];
            Name = name;
            Capacity = capacity;
            Occupancy = 0;

            foreach (var item in this)
            {
                Occupancy++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T v in Vehicles)
            {
                if(v != null)
                {
                    yield return v;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Vehicle GetSortedVehicle (Vehicle v, string s)
        {
                if(v.Color.ToLower() == s.ToLower())
                {
                    Sorted = true;
                    return v;
                }
                else if(v.Maker.ToLower() == s.ToLower())
                {
                    Sorted = true;
                    return v;
                }
                else if(v.RegNr.ToLower() == s.ToLower())
                {
                    Sorted = true;
                    return v;
                }
            else
            {
                return null;
            }

        }

        public int GetParkingSpot(Vehicle v)
        {
            return Array.IndexOf(Vehicles, v) + 1;
        }
        public void RemoveVehicleFromGarage(int v)
        {
            Vehicles[v] = null;
            Occupancy--;
        }
        public void AddVehicleToGarage(T v)
        {
            foreach(T e in Vehicles){
                if (e == null)
                {
                    var index = Array.IndexOf(Vehicles, e);
                    Vehicles[index] = v;
                    Occupancy++;
                    break;
                }
            }
            parkedEvent?.Invoke(this, new VehicleEventArgs() { Vehicle = v });
        }
    }
}
