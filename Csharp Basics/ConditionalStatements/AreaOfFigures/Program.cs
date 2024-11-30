using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace AreaOfFigures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "George";
            name[2] = "m";
            Console.WriteLine(name[2]);
            string type = Console.ReadLine();
            if (type == "square")
            {
                double a = double.Parse(Console.ReadLine());
                double area = a * a;
                Console.WriteLine($"{area:F3}");
            }
            else if (type =="rectangle")
            {
                double sideA = double.Parse(Console.ReadLine());
                double sideB =double.Parse(Console.ReadLine());
                double areas = sideA*sideB;
                Console.WriteLine($"{areas:F3}");
            }
            else if(type =="circle")
            {
                double radius = double.Parse(Console.ReadLine());
                double Area = Math.PI * Math.Pow(radius,2);
                Console.WriteLine($"{Area:F3}");
            }
            else if (type =="triangle")
            {
                double side1 = double.Parse(Console.ReadLine());
                double high = double.Parse(Console.ReadLine());
                double areA = (side1 * high) / 2;
                Console.WriteLine($"{areA:F3}");
            }
        }

    }
}
