using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double consumprionPerKm;
        private double tankCapacity;

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }

        public double ConsumprionPerKm
        {
            get { return consumprionPerKm; }
            set { consumprionPerKm = value; }
        }

        public double TankCapacity
        {
            get { return tankCapacity; }
            set
            { tankCapacity = value; }
        }


        public abstract void Drive(double distance);
        public abstract void Refuel(double liters);
    }
}
