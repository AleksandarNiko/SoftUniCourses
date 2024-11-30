using System;

namespace Gold_Mine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int locations = int.Parse(Console.ReadLine());
            for (int l = 0; l < locations; l++)
            {
                double expectedAverageYield = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                double yield = 0;
                for (int d = 0; d < days; d++)
                {
                    double currentYield = double.Parse(Console.ReadLine());
                    yield += currentYield;
                }
                double averagePerLocation = (yield / days);
                double diff = Math.Abs(averagePerLocation - expectedAverageYield);
                if (averagePerLocation < expectedAverageYield)
                {
                    Console.WriteLine($"You need {diff:F2} gold.");
                }
                else
                {
                    Console.WriteLine($"Good job! Average gold per day: {averagePerLocation:F2}.");
                }
            }
        }
    }
}
