using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle:Shape
    {
        public double Length { get;private  set; }
        public double Width { get;private set; }

        public Rectangle(double length,double width)
        {
            Length = length;
            Width = width;
        }

        public override double CalculatePerimeter() => (Length + Width) * 2;
        public override double CalculateArea() => Length * Width;

        public override string Draw()
        {
            return base.Draw()+ "Rectangle";
        }
    }
}
