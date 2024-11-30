using System;

namespace GodzillaVsKong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget=double.Parse(Console.ReadLine());
            int statists=int.Parse(Console.ReadLine());
            double clothsprice=double.Parse(Console.ReadLine());
            double dekor = 0.1 * budget;
            double totalforclothes=statists*clothsprice;
            if(statists>150)
            {
                totalforclothes = totalforclothes - 0.1 * totalforclothes;
            }
            if(dekor+totalforclothes>budget)
            {
                Console.WriteLine($"Not enough money!");
                Console.WriteLine($"Wingard needs {(dekor+totalforclothes)-budget:f2} leva more.");
            }
            else if (dekor+totalforclothes <= budget)
            {
                Console.WriteLine($"Action!");
                Console.WriteLine($"Wingard starts filming with {budget-(dekor+totalforclothes):f2} leva left.");
            }

        }
    }
}
