using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Truck
    {
        public double FuelQuantity { get; private set; }
        private double FuelConsumptionPerKm;

        public Truck(double fuelQuantity, double fuelConsumptionPerKm)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public void Drive(double distance)
        {
            double neededFuel = distance * (FuelConsumptionPerKm + 1.6);

            if (neededFuel <= FuelQuantity)
            {
                FuelQuantity -= neededFuel;
                Console.WriteLine($"Truck travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public void Refuel(double liters)
        {
            FuelQuantity += liters * 0.95;
        }
    }
}
