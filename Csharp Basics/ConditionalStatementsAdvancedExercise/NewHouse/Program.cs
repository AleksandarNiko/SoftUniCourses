using System;

namespace NewHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string flower = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double price = 0;
            if (flower == "Roses")
            {
                price = 5;
            }
            else if (flower == "Dahlias")
            {
                price = 3.80;  
            }
            else if (flower == "Tulips")
            {
                price = 2.80;
            }
            else if (flower == "Narcissus")
            {
                price = 3;
            }
            else if(flower == "Gladiolus")
            {
                price = 2.5;
            }
            double totalcost = price * quantity;
            if (flower == "Roses" && quantity > 80)
            {
                totalcost = totalcost - 0.10 * totalcost;
            }
            else if ((flower == "Dahlias" && quantity > 90) || (flower == "Tulips" && quantity > 80))
            {
                totalcost = totalcost - 0.15 * totalcost;
            }
            else if (flower=="Narcissus"&& quantity < 120)
            {
                totalcost = totalcost + 0.15 * totalcost;
            }
            else if(flower=="Gladiolus"&& quantity < 80)
            {
                totalcost = totalcost + 0.20 * totalcost;
            }
            if(budget>=totalcost)
            {
                Console.WriteLine($"Hey, you have a great garden with {quantity} {flower} and {budget-totalcost:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {totalcost-budget:F2} leva more.");
            }
        }
    }
}
