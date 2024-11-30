using System;

namespace Spaceship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double width=double.Parse(Console.ReadLine());
            double length=double.Parse(Console.ReadLine());
            double heigh=double.Parse(Console.ReadLine());
            double averageHeigh=double.Parse(Console.ReadLine());
            double obemNaRaketa = width * length * heigh;
            double obemNaStaq = (0.40 + averageHeigh) * 2 * 2;
            double astronautsCount=Math.Floor(obemNaRaketa / obemNaStaq);
            if (astronautsCount < 3)
            {
                Console.WriteLine("The spacecraft is too small.");
            }
            else if (astronautsCount > 10)
            {
                Console.WriteLine("The spacecraft is too big.");
            }
            else
            {
                Console.WriteLine($"The spacecraft holds {astronautsCount} astronauts.");
            }
        }
    }
}

