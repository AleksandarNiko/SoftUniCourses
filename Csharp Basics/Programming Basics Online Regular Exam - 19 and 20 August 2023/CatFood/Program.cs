using System;
using System.Text.RegularExpressions;

namespace CatFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int catNumber=int.Parse(Console.ReadLine());
            int catCount = 1;
            double totalFoodWeight = 0;
            int group1=0;
            int group2=0;
            int group3=0;
            while (catCount <=catNumber) 
            {
                double gramsFood = double.Parse(Console.ReadLine());
                totalFoodWeight += gramsFood;
                if (gramsFood>= 100 && gramsFood< 200)
                {
                    group1++;
                }
                else if (gramsFood >= 200 && gramsFood < 300)
                {
                    group2++;
                }
                else if (gramsFood >= 300 && gramsFood <= 400)
                {
                    group3++;
                }
                catCount++;
            }
            double priceForFood = (totalFoodWeight / 1000) * 12.45;
            Console.WriteLine($"Group 1: {group1} cats.");
            Console.WriteLine($"Group 2: {group2} cats.");
            Console.WriteLine($"Group 3: {group3} cats.");
            Console.WriteLine($"Price for food per day: {priceForFood:F2} lv.");
        }
        }
    }

