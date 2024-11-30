using System;

namespace Courier_Express
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tegloPratka = double.Parse(Console.ReadLine());
            string usluga = Console.ReadLine();
            int distanceInKm = int.Parse(Console.ReadLine());
            double priceForDistance = 0;
            double totalPrice = 0;
            double nadcenka = 0;
            switch (usluga)
            {
                case "standard":
                    if (tegloPratka < 1)
                    {
                        priceForDistance += 0.03;
                    }
                    else if (tegloPratka >= 1 && tegloPratka < 10)
                    {
                        priceForDistance += 0.05;
                    }
                    else if (tegloPratka >= 10 && tegloPratka < 40)
                    {
                        priceForDistance += 0.10;
                    }
                    else if (tegloPratka >= 40 && tegloPratka < 90)
                    {
                        priceForDistance += 0.15;
                    }
                    else if (tegloPratka >= 90 && tegloPratka < 150)
                    {
                        priceForDistance += 0.20;
                    }
                    totalPrice = distanceInKm * priceForDistance;
                    break;
                case "express":
                    if (tegloPratka < 1)
                    {
                        priceForDistance += tegloPratka * (0.8 * 0.03);
                        nadcenka=distanceInKm * 0.03;
                    }
                    else if (tegloPratka >= 1 && tegloPratka < 10)
                    {
                        priceForDistance += tegloPratka * (0.4 * 0.05);
                        nadcenka = distanceInKm * 0.05;
                    }
                    else if (tegloPratka >= 10 && tegloPratka < 40)
                    {
                        priceForDistance += tegloPratka * (0.05 * 0.10);
                        nadcenka = distanceInKm * 0.10;
                    }
                    else if (tegloPratka >= 40 && tegloPratka < 90)
                    {
                        priceForDistance += tegloPratka * (0.02 * 0.15);
                        nadcenka = distanceInKm * 0.15;
                    }
                    else if (tegloPratka >= 90 && tegloPratka < 150)
                    {
                        priceForDistance += tegloPratka * (0.01 * 0.20);
                        nadcenka = distanceInKm * 0.20;
                    }
                    totalPrice = distanceInKm * priceForDistance+nadcenka;
                    break;

            }
            Console.WriteLine($"The delivery of your shipment with weight of {tegloPratka:f3} kg. would cost {totalPrice:f2} lv.");


        }
    }
}
