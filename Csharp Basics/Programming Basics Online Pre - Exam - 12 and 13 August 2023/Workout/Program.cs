using System;

namespace Workout
{
    internal class Program
    {
        static void Main(string[] args)
        {
  int trainingdays = int.Parse(Console.ReadLine());
            double runKm=double.Parse(Console.ReadLine());
            double runedKmPerDay = runKm;
            for (int i = 0; i <trainingdays; i++)
            {
                int currentDays=int.Parse(Console.ReadLine());
                 runKm=runKm+runKm*(currentDays/100.0);
                runedKmPerDay += runKm;
            }
            if (runedKmPerDay <= 1000.00)
            {
                Console.WriteLine($"Sorry Mrs. Ivanova, you need to run {Math.Ceiling(1000.00-runedKmPerDay)} more kilometers");
            }
            else
            {
                Console.WriteLine($"You've done a great job running {Math.Ceiling(runedKmPerDay - 1000.00)} more kilometers! ");
            }
        }
    }
}

