using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    internal class RaceMotorcycle:Motorcycle
    {
        private const double DefaultCarFuelConsumption = 8;
        public override double FuelConsumption => DefaultCarFuelConsumption;

        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
            
        }
    }
}
