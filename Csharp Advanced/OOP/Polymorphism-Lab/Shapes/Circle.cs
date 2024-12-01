using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle:Shape
    {
        public double Radius { get;private  set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculatePerimeter() => 2 * Math.PI * Radius;
        public override double CalculateArea()=> Math.PI * (Radius * Radius);

        public override string Draw()
        {
            return base.Draw()+ "Circle";
        }
    }
}
