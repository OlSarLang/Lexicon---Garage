using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    class UI
    {
        public UI()
        {
        }

        public void Clear()
        {
            Console.Clear();
        }

        public char AskForKey()
        {
            char key = Console.ReadKey().KeyChar;
            return key;
        }

        public int AskForInt()
        {
            int val;
            string input = Console.ReadLine();
            while (!int.TryParse(input, out val))
            {
                MSG("Invalid numerical input, try again.");
                input = Console.ReadLine();
            }
            return val;
        }

        public double AskForDouble()
        {
            double val;
            string input = Console.ReadLine();
            while (!double.TryParse(input, out val))
            {
                MSG("Invalid numerical input, try again.");
                input = Console.ReadLine();
            }
            return val;
        }

        public string AskForString()
        {
            string input = "";
            bool running = true;
            while (running)
            {
                string str = Console.ReadLine();
                if(str != "")
                {
                    input = str;
                    running = false;
                }
                else
                {
                    MSG("INVALID INPUT");
                }
            }
            return input;
        }

        public void MSG(string error)
        {
            Console.WriteLine(error);
        }

        public void VE(object sender, VehicleEventArgs ve)
        {
            MSG(ve.Vehicle.PrintStats());
            Console.Read();
        }
    }
}
