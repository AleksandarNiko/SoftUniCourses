using System;

namespace LunchBreak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string moviename=Console.ReadLine();
            double eptime = double.Parse(Console.ReadLine());
            double breaktime=double.Parse(Console.ReadLine());
            double lunch = 1.00 / 8.00 * breaktime;
            double relax = 1.00 / 4.00 * breaktime;
            breaktime = breaktime - lunch - relax;
            if(breaktime>=eptime)
            {
                Console.WriteLine($"You have enough time to watch {moviename} and left with {Math.Ceiling(breaktime - eptime)} minutes free time. ");
            }
            else { Console.WriteLine($"You don't have enough time to watch {moviename}, you need {Math.Ceiling(eptime-breaktime)} more minutes. ");
            }
        }
    }
}
