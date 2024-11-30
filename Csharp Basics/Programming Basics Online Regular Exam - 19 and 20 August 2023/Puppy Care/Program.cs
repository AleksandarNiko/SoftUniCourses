using System;
using System.Globalization;

namespace Puppy_Care
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int purchasedFood = int.Parse(Console.ReadLine());
            int totalFoodEaten = 0;
            string input = Console.ReadLine();
            while (input != "Adopted")
            {
                int foodEaten = int.Parse(input);
                totalFoodEaten += foodEaten;

                input = Console.ReadLine();
            }
            int remainingFood = purchasedFood * 1000 - totalFoodEaten;
            if (remainingFood >= 0)
            {
                Console.WriteLine($"Food is enough! Leftovers: {remainingFood} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {Math.Abs(remainingFood)} grams more.");
            }
        }
        }
    }

