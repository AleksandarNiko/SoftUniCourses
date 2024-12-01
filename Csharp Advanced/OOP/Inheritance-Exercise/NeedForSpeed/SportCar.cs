using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class SportCar:Car
    {
        private const double DefaultCarFuelConsumption = 10;
        public override double FuelConsumption => DefaultCarFuelConsumption;
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }
    }
}
