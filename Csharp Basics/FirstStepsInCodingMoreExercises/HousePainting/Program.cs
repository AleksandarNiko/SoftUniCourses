using System;

namespace HousePainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            double frontWallArea = x * x - 1.2 * 2;
            double backWall = x * x;
            double sidewall = x * y - 1.5 * 1.5;
            double ceilling = 2 * (x * y) + 2 * (x * h / 2);
            double sum = frontWallArea + backWall + 2 * sidewall;
            double wallPaint = sum / 3.4;
            double ceillingPaint = ceilling / 4.3;
            Console.WriteLine($"{wallPaint:f2}");
            Console.WriteLine($"{ceillingPaint:f2}");
        }
    }
}
