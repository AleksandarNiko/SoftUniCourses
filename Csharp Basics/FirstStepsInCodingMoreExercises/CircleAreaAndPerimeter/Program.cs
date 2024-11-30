using System;

namespace CircleAreaAndPerimeter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double r=double.Parse(Console.ReadLine());
            double area=(r*r*Math.PI);
            double parametar = (2 * Math.PI * r);
            Console.WriteLine($"{area:f2}");
            Console.WriteLine($"{parametar:f2}");
        }
    }
}
