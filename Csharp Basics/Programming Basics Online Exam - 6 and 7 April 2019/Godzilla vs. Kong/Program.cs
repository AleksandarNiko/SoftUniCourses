using System;

namespace Godzilla_vs._Kong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMeters=double.Parse(Console.ReadLine());
            double meterInSeconds=double.Parse(Console.ReadLine());
            double timeForAllMeters=distanceInMeters*meterInSeconds;
            double delay = Math.Floor(distanceInMeters/50)*30;
            double totalTime=timeForAllMeters+delay;
            double missingTime=Math.Abs(recordInSeconds-totalTime);
            if(recordInSeconds<=totalTime)
            {
                Console.WriteLine($"No! He was {missingTime:f2} seconds slower.");
            }
            else if(recordInSeconds>=totalTime)
            {
                Console.WriteLine($" Yes! The new record is {totalTime:f2} seconds.");
            }
        }
    }
}
