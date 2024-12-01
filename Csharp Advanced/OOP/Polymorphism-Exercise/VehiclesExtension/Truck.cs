using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesExtension
{
    public class Truck:Vehicle
    {
        private const double truckConsumption = 1.6;

        public Truck(double fuel, double consumption, double tankCapacity)
        {
            FuelQuantity = fuel > tankCapacity ? 0 : fuel;
            ConsumprionPerKm = consumption + truckConsumption;
            TankCapacity = tankCapacity;
        }

        public override void Drive(double distance)
        {
            double consumedFuel = distance * ConsumprionPerKm;
            if (FuelQuantity - consumedFuel >= 0)
            {
                Console.WriteLine($"Truck travelled {distance} km");
                FuelQuantity -= consumedFuel;
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else if (FuelQuantity + liters > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            double fuelToAdd = (liters * 95) / 100.0;
            FuelQuantity += fuelToAdd;
        }
    }
}
