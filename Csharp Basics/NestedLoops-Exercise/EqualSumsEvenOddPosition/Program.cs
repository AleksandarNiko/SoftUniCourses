using System;

namespace EqualSumsEvenOddPosition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            for(int i = start; i <= end; i++)
            {
                int n = i;
                int evenSum = 0;
                int oddSum = 0;
                bool isEven = true;
                while (n != 0)
                {
                    int lastDigit = n % 10;
                    if (isEven)
                    {
                        evenSum += lastDigit;
                    }
                    else
                    {
                        oddSum += lastDigit;
                    }
                    isEven = !isEven;
                    n /= 10;
                }
                if (oddSum == evenSum)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
