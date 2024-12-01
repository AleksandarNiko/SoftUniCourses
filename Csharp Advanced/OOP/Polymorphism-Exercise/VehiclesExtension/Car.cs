using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesExtension
{
    public class Car:Vehicle
    {
        private const double carConsumption = 0.9;

        public Car(double fuel, double consumption, double tankCapacity)
        {
            FuelQuantity = fuel > tankCapacity ? 0 : fuel;
            ConsumprionPerKm = consumption + carConsumption;
            TankCapacity = tankCapacity;
        }

        public override void Drive(double distance)
        {
            double consumedFuel = distance * ConsumprionPerKm;
            if (this.FuelQuantity - consumedFuel >= 0)
            {
                Console.WriteLine($"Car travelled {distance} km");
                this.FuelQuantity -= consumedFuel;
            }
            else
            {
                Console.WriteLine("Car needs refueling");
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
           FuelQuantity += liters;
        }


    }
}
