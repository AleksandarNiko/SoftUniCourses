using System;

namespace _11._Refactor_Volume_of_Pyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            double length = double.Parse(Console.ReadLine());
           
            double width = double.Parse(Console.ReadLine());
            
            double h = double.Parse(Console.ReadLine());
            double v = 0;
            double s = length * width;
            v = (s * h) / 3;
            Console.WriteLine($"Length: Width: Height: Pyramid Volume: {v:f2}");
            
        }
    }
}