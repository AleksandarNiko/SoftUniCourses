using System;

namespace Journey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string destination = "";
            string typeSpace = "";
            double razhodi = 0;
            if (season == "summer")
            {
                typeSpace = "Camp";
            }
            else if (season == "winter")
            {
                typeSpace = "Hotel";
            }       
            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    razhodi = 0.3 * budget;
                }
                else if (season == "winter")
                {
                    razhodi = 0.7 * budget;
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    razhodi = 0.4 * budget;
                }
                else if (season == "winter")
                {
                    razhodi = 0.8 * budget;
                }
            }
            if (budget>1000)
            {
                typeSpace = "Hotel";
                destination = "Europe";
                razhodi = 0.9 * budget;
            }
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{typeSpace} - {razhodi:f2}");
        }
    }
}
