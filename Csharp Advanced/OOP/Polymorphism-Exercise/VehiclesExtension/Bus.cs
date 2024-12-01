using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesExtension
{
    public class Bus:Vehicle
    {
        public Bus(double fuel, double consumption, double tankCapacity)
        {
            FuelQuantity = fuel > tankCapacity ? 0 : fuel;
            ConsumprionPerKm = consumption;
            this.TankCapacity = tankCapacity;
        }

        public override void Drive(double distance)
        {
            double consumedFuel = distance * (ConsumprionPerKm+1.4); 
            if (FuelQuantity  >= consumedFuel)
            {
                FuelQuantity -= consumedFuel;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }

        public void DriveEmpty(double distance)
        {
            double consumedFuel = distance * ConsumprionPerKm; 
            if (FuelQuantity - consumedFuel >= 0)
            {
                FuelQuantity -= consumedFuel;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }
        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else if (FuelQuantity + liters > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            FuelQuantity += liters;
        }
    }
}
