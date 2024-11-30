using System;

namespace OscarsCeremony
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rent=int.Parse(Console.ReadLine());
            double statues = rent - 0.3 * rent;
            double keturing = statues - 0.15 * statues;
            double sound = keturing - 0.5 * keturing;
            double sum = rent + statues + keturing + sound;
            Console.WriteLine($"{sum:f2}");
        }
    }
}
