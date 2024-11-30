using System;
using System.Diagnostics.CodeAnalysis;

namespace Fishland
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceSkumriq = double.Parse(Console.ReadLine());
            double priceCaca = double.Parse(Console.ReadLine());
            double palamud = double.Parse(Console.ReadLine());
            double safrid = double.Parse(Console.ReadLine());
            int midi = int.Parse(Console.ReadLine());
            double pricePalamud = priceSkumriq + 0.6 * priceSkumriq;
            double priceSafrid = priceCaca + 0.8 * priceCaca;
            double priceMidi = 7.50;
            double sum1 = pricePalamud * palamud;
            double sum2 = priceSafrid * safrid;
            double sum3 = priceMidi * midi;
            double result = sum1 + sum2 + sum3;
            Console.WriteLine($"{ result:f2}");
        }
    }
}
