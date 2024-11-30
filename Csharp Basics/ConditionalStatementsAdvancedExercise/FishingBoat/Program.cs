using System;
using System.Globalization;
using System.IO.Enumeration;

namespace FishingBoat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int budget=int.Parse(Console.ReadLine());
            string season=Console.ReadLine();
            int fishers=int.Parse(Console.ReadLine());
            double rent = 0;
            if(season=="Spring")
            {
                rent = 3000;
            }
            else if(season=="Summer"|| season == "Autumn")
            {
                rent = 4200;
            }
            else if(season=="Winter")
            {
                rent = 2600;
            }
            if (fishers <= 6)
            {
                rent = rent - 0.10 * rent;
            }
            else if (fishers >= 7 && fishers <= 11)
            {
                rent = rent - 0.15 * rent;
            }
            else if (fishers >= 12)
                {
                rent = rent - 0.25 * rent;
            }
            if (fishers % 2 == 0 && season != "Autumn")
            {
                rent = rent - 0.05 * rent;
            }

            if (budget >= rent)
            {
                Console.WriteLine($"Yes! You have {budget - rent:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {rent-budget:f2} leva.");
            }
        }
    }
}
