using System;

namespace Everest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input=Console.ReadLine();
            int countDays = 1;
            int meters = 5364;
            while (input != "END")
            {
                int currentMeters=int.Parse(Console.ReadLine());
                meters+= currentMeters;
                if (input == "Yes")
                {
                    countDays++;
                }
                if (meters >= 8848)
                {
                    break;
                }
                if (countDays >= 5)
                {
                    break;
                }
                    input= Console.ReadLine();
           }
            if (meters >= 8848)
            {
                Console.WriteLine($"Goal reached for {countDays} days!");
            }
            else
            {
                Console.WriteLine("Failed!");
                Console.WriteLine(meters);
            }
        }
    }
}
