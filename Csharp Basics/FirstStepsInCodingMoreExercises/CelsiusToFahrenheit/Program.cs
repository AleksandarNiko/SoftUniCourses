using System;

namespace CelsiusToFahrenheit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double C = double.Parse(Console.ReadLine());
            Console.WriteLine($"{C * 9 / 5 + 32:f2}");
        }
    }
}
