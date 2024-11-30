using System;

namespace Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget=double.Parse(Console.ReadLine());
            int videocards=int.Parse(Console.ReadLine());
            int processors=int.Parse(Console.ReadLine());
            int ram=int.Parse(Console.ReadLine());
            double priceVideocards = videocards * 250;
            double priceProcessors =0.35 * priceVideocards;
            double totalPriceProcessors=processors * priceProcessors;
            double priceRam =0.10 * priceVideocards;
            double totalPriceRam=ram * priceRam;
            double totalPrice=totalPriceRam+priceVideocards+totalPriceProcessors;
            if(videocards>processors)
            {
                totalPrice = totalPrice - 0.15 * totalPrice;
            }
            if(totalPrice <=budget)
            {
                Console.WriteLine($"You have {budget-totalPrice:f2} leva left!");
            }
            else if(totalPrice >budget) 
            {
                 Console.WriteLine($"Not enough money! You need {totalPrice-budget:f2} leva more!");
            }
        }
    }
}
