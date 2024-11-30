using System;

namespace ToyShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tourprice = double.Parse(Console.ReadLine());
            int puzzels = int.Parse(Console.ReadLine());
            int kukli = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());
            double profit = puzzels * 2.60 + kukli * 3+bears*4.10+minions*8.20+trucks*2;
            int quantity = puzzels + kukli + bears + minions+trucks;
         if(quantity >=50)
            {
                profit = profit - 0.25 * profit;
            }
            profit = profit - 0.1 * profit;
            if(profit>=tourprice) 
                {
                Console.WriteLine($"Yes! {profit-tourprice:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {tourprice-profit:f2} lv needed.");
            }
        }
    }
}
