using System;

namespace WorldSwimmingRecord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds=double.Parse(Console.ReadLine());
            double recordInMeters=double.Parse(Console.ReadLine());
            double secondsformeter = double.Parse(Console.ReadLine());
            double totalTime=recordInMeters*secondsformeter+Math.Floor(recordInMeters/15)*12.5;
            if(totalTime<recordInSeconds)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }
            else if(totalTime>=recordInSeconds)
            {
                Console.WriteLine($"No, he failed! He was {totalTime-recordInSeconds:f2} seconds slower.");
            }
        }
    }
}
