using System;

namespace FootballKit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double shirtPrice=double.Parse(Console.ReadLine());
            double priceToScore=double.Parse(Console.ReadLine());
            double shorts = 0.75 * shirtPrice;
            double socks = 0.20 * shorts;
            double shoes = 2 * (shirtPrice + shorts);
            double totalPrice = shirtPrice + shorts + socks + shoes;
            double totalPriceWithDiscount = totalPrice - 0.15 * totalPrice;
            if (totalPriceWithDiscount >=priceToScore)
            {
                Console.WriteLine("Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {totalPriceWithDiscount:f2} lv.");
            }
            else if(totalPriceWithDiscount < priceToScore) 
            {
                Console.WriteLine("No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {priceToScore-totalPriceWithDiscount:f2} lv. more.");
            }
        }
    }
}
