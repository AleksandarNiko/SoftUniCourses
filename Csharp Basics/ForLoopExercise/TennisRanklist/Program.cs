using System;

namespace TennisRanklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tournirsCount=int.Parse(Console.ReadLine());
            int pointsInTheBiginning=int.Parse(Console.ReadLine());
            double points = 0;
            int wonTournaments = 0;
            for (int i = 0; i < tournirsCount; i++)
            {
                string position=Console.ReadLine();
                if(position == "W") { points += 2000;wonTournaments++; }
                else if(position == "F") { points += 1200; }
                else if(position == "SF") { points += 720; }
            }
            Console.WriteLine($"Final points: {pointsInTheBiginning+points}");
            Console.WriteLine($"Average points: {Math.Floor(points/tournirsCount)}");
            Console.WriteLine($"{ 100.0 * wonTournaments/tournirsCount:F2}%");
        }
    }
}
