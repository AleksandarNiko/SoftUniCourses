using System;

namespace AccountBalance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string money="";
            double sum = 0;
            while ((money = Console.ReadLine()) != "NoMoreMoney")
            {
                double currentNumber=double.Parse(money);
                if (currentNumber < 0) { Console.WriteLine("Invalid operation!"); break; }

                sum += currentNumber;
                Console.WriteLine($"Increase: {currentNumber:f2}");
            }
            Console.WriteLine($"Total: {sum:f2}");
        }
    }
}
