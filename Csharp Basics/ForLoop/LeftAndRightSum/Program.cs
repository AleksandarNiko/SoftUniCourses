using System;

namespace LeftAndRightSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int firstSum = 0;
            int secondSum = 0;
            for  (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                firstSum += currentNumber;
            }
            for (int i = 0;i < n; i++)
            {
                int currentNumber=int.Parse(Console.ReadLine());
                secondSum += currentNumber;
            }
            if (firstSum == secondSum)
                Console.WriteLine($"Yes, sum = {firstSum}");
            else Console.WriteLine($"No, diff = {Math.Abs(firstSum - secondSum)}");
        }
    }
}
