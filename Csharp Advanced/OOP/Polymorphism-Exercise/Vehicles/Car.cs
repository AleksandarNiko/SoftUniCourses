using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Car
    {
        public double FuelQuantity { get; private set; }
        private double FuelConsumptionPerKm;

        public Car(double fuelQuantity, double fuelConsumptionPerKm)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public void Drive(double distance)
        {
            double neededFuel = distance * (FuelConsumptionPerKm + 0.9);

            if (neededFuel <= FuelQuantity)
            {
                FuelQuantity -= neededFuel;
                Console.WriteLine($"Car travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
        }

        public void Refuel(double liters)
        {
            FuelQuantity += liters;
        }
    }
}
