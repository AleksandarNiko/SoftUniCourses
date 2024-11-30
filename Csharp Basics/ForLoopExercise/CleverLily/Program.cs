using System;

namespace CleverLily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age=int.Parse(Console.ReadLine());
            double washer=double.Parse(Console.ReadLine());
            int toyprice=int.Parse(Console.ReadLine());
            double budget = 0;
            int giftMoney = 10;
            for (int i = 1; i <= age; i++)
            {
                if(i%2!=0)
                {
                    budget += toyprice;
                }
                else
                {
                    budget += giftMoney - 1;
                    giftMoney+=10;
                }
            }
            if(budget>=washer)
            {
                Console.WriteLine($"Yes! {budget-washer:f2}");
            }
            else
            {
                Console.WriteLine($"No! {washer - budget:f2}");
            }
        }
    }
}
