using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    class GarageHandler
    {
        private Dictionary<int, Garage<Vehicle>> Garages { get; set; }

        public UI UI { get; set; }

        public GarageHandler() => Garages = new Dictionary<int, Garage<Vehicle>>();

        public string SortedString { get; set; }

        public bool CheckGarages()
        {
            if(Garages != null){
                return true;
            }
            else
            {
                return false;
            }
        }

        public void StartUI()
        {
            UI = new UI();
            while (true)
            {
                ShowGarages();
                StartOptions();
            }
        }

        public void ShowGarages()
        {
            UI.Clear();
            UI.MSG("These are the current Garages.");
            StringBuilder gargString = new StringBuilder();
            int counter = 1;

            foreach (KeyValuePair<int, Garage<Vehicle>> g in GetGarages())
            {
                gargString.Append($"\n{counter}. {g.Value.Name} {g.Value.Occupancy}/{g.Value.Capacity}");
                counter++;
            }
            UI.MSG(gargString.ToString());
            return;
        }
        public void StartOptions()
        {
            UI.MSG("Press 'e' to enter a Garage." +
                    "\nPress 'a' to add a Garage." +
                    "\nPress 'q' to quit.");
            bool running = true;
            while (running)
            {
                char key = UI.AskForKey();
                switch (key)
                {
                    case 'e':
                        UI.MSG("\nType the number of the Garage you'd wish to enter.");
                        EnterGarage();
                        running = false;
                        break;
                    case 'a':
                        AddGarage();
                        running = false;
                        break;
                    case 'q': System.Environment.Exit(1); break;
                    default:
                        UI.MSG($"{key} is an invalid input, try again.");
                        break;
                }
            }
        }


        public Dictionary<int, Garage<Vehicle>> GetGarages()
        {
            return Garages;
        }

        public void RemoveGarage(Garage<Vehicle> garage)
        {
            foreach (KeyValuePair<int, Garage<Vehicle>> g in Garages)
            {
                if (garage == g.Value)
                {
                    Garages.Remove(g.Key);
                }
            }
        }

        public void ShowGarage(Garage<Vehicle> garage)
        {
            bool running = true;
            while (running)
            {
                UI.Clear();
                UI.MSG($"This is the garage {garage.Name} with the capacity {garage.Occupancy}/{garage.Capacity}");
                if (garage.Occupancy == 0)
                {
                    UI.MSG("There are no vehicles in the garage.");
                }
                else if (garage.Occupancy != 0)
                {
                    foreach (var v in garage)
                    {
                        if (garage.Sorted)
                        {
                            if(garage.GetSortedVehicle(v, SortedString) != null)
                            {
                                UI.MSG($"{garage.GetParkingSpot(v)}. {v.Color} {v.Maker} with the regno '{v.RegNr}'");
                            }
                        }
                        else
                        {
                            UI.MSG($"{garage.GetParkingSpot(v)}. {v.Color} {v.Maker} with the regno '{v.RegNr}'");
                        }
                    }
                }
                UI.MSG("Press 'a' to park a vehicle" +
                        "\nPress 'r' to remove a vehicle" +
                        "\nPress 's' to sort garage" +
                        "\nPress 'd' to delete the garage" +
                        "\nPress 'b' to go back/de-sort" +
                        "\nPress 'q' to quit.");
                running = GarageOptions(garage);
            }
        }

        public bool GarageOptions(Garage<Vehicle> garage)
        {
            while (true)
            {
                char key = UI.AskForKey();
                switch (key)
                {
                    case 'a':
                        if (garage.Occupancy < garage.Capacity)
                        {
                            AddVehicleToGarage(garage);
                            return true;
                        }
                        else
                        {
                            UI.MSG("The Garage is full.");
                        }
                        return true;
                    case 'd':
                        RemoveGarage(garage);
                        return false;
                    case 's':
                        SortedString = UI.AskForString();
                        garage.Sorted = true;
                        return true;
                    case 'r':
                        if (garage.Occupancy != 0)
                        {
                            RemoveVehicleFromGarage(garage);
                        }
                        return true;
                    case 'b':
                        if (garage.Sorted)
                        {
                            garage.Sorted = false;
                            SortedString = "";
                            return true;
                        }
                        return false;
                    case 'q':
                        System.Environment.Exit(1);
                        return false;
                    default:
                        UI.MSG($"{key} is an invalid input, try again.");
                        return true;
                }
            }
        }

        public void AddGarage()
        {
            UI.MSG("\nHow many parking spots does it contain?");
            bool running = true;
            int cap = 0;
            while (running)
            {
                int input = UI.AskForInt();
                if (input > 0 && input < 100)
                {
                    cap = input;
                    running = false;
                }
                else
                {
                    UI.MSG("Invalid number, must be between 1 - 99");
                }
            }

            UI.MSG("What would you like to name the garage?");
            string name = UI.AskForString();

            Garages.Add(Garages.Count + 1, new Garage<Vehicle>(name, cap));
        }

        public void EnterGarage()
        {
            int input = UI.AskForInt();
            foreach (KeyValuePair<int, Garage<Vehicle>> g in Garages)
            {
                if (input == g.Key)
                {
                    g.Value.parkedEvent += UI.VE;
                    ShowGarage(g.Value);
                }
                else { UI.MSG("That garage does not exist."); }
            }
        }

        public void RemoveVehicleFromGarage(Garage<Vehicle> garage)
        {
            int input = UI.AskForInt();
            try
            {
                garage.RemoveVehicleFromGarage(input - 1);
            }
            catch(Exception e)
            {
                UI.MSG($"The vehicle in spot {input} does not exist.");
                Console.Read();
            }
        }

        public Vehicle AskTypeOfVehicle()
        {
            UI.Clear();
            UI.MSG("Available vehicles types: Boat, Bus, Car, Motorcycle, Airplane." +
                    "Type the type that you want.");
            while (true)
            {
                string key = UI.AskForString().ToLower();
                switch (key)
                {
                    case "boat":
                        Boat boat = new Boat();
                        UI.MSG("How long is the boat?");
                        boat.Length = UI.AskForDouble();
                        return boat;
                    case "bus":
                        Bus bus = new Bus();
                        UI.MSG("How many seats does the bus have?");
                        bus.Seats = UI.AskForInt();
                        return bus;
                    case "car":
                        Car car = new Car();
                        UI.MSG("What type of fuel does the car require?");
                        car.FuelType = UI.AskForString();
                        return car;
                    case "motorcycle":
                        Motorcycle mc = new Motorcycle();
                        UI.MSG("How large is the cylinder volume?");
                        mc.CylinderVolume = UI.AskForDouble();
                        return mc;
                    case "airplane":
                        Airplane ap = new Airplane();
                        UI.MSG("How many engines does the plane have?");
                        ap.Engines = UI.AskForInt();
                        return ap;
                    default:
                        UI.MSG($"{key} is an invalid input, try again.");
                        break;
                }
            }
        }

        public void AddVehicleToGarage(Garage<Vehicle> garage)
        {
            var v = AskTypeOfVehicle();
            UI.MSG("Registration/Serialnumber: ");
            v.RegNr = UI.AskForString();
            UI.MSG("Vehicle maker: ");
            v.Maker = UI.AskForString();
            UI.MSG("Vehicle Color: ");
            v.Color = UI.AskForString();
            garage.AddVehicleToGarage(v);
        }

    }
}
