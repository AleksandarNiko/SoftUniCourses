using System;

namespace _10._Rage_Expenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount=int.Parse(Console.ReadLine());
            double headsetPrice=double.Parse(Console.ReadLine());
            double mousePrice=double.Parse(Console.ReadLine());
            double kayboardPrice=double.Parse(Console.ReadLine());
             double displayPrice=double.Parse(Console.ReadLine());
            double sumExpenses = 0;
             for (int i = 1; i <= lostGamesCount; i++)
            {
                if(i%2 == 0)
                {
                    sumExpenses += headsetPrice;
                }
                if(i%3 == 0)
                {
                    sumExpenses += mousePrice;
                }
                if(i %2==0&&i%3==0) 
                { 
                    sumExpenses  += kayboardPrice;
                }
                if (i % 12 == 0)
                {
                    sumExpenses += displayPrice;
                }
            }
             Console.WriteLine($"Rage expenses: {sumExpenses:f2} lv.");
        }
    }
}
