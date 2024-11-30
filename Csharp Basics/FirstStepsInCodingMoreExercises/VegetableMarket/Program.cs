using System;

namespace VegetableMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceVegetables=double.Parse(Console.ReadLine());
            double priceFruits=double.Parse(Console.ReadLine());
            int vegetablesCount=int.Parse(Console.ReadLine());
            int fruitsCount=int.Parse(Console.ReadLine());
            double sumVegetables = priceVegetables * vegetablesCount;
            double sumFruits = priceFruits * fruitsCount;
            double sum = sumVegetables + sumFruits;
            Console.WriteLine($"{sum/1.94:f2}");
        }
    }
}
