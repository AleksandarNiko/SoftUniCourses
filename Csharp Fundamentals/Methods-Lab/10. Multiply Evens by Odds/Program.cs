using System;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;

namespace _10._Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));
            //Console.WriteLine($"{GetSumOfEvenDigits(num)}");
            //Console.WriteLine($"{GetMultipleOfEvenAndOdds(num)}");
            Console.WriteLine(PrintMultiplied(number));

        }
        private static int GetSumOfEvenDigits(int number)
        {
            int sumEven = 0;
            int digit = 0;
            while (number > 0)
            {
                digit = number % 10;
                if (digit % 2 == 0)
                
                    sumEven += digit;
                number /= 10;   
            }
            return sumEven;
        }
        private static int GetSumOfOddDigits(int number)
        {
            int sumOdd = 0;
            int digit = 0;
            while (number > 0)
            {
                digit = number % 10;
                if (digit % 2 == 1) 
                 sumOdd += digit; 
                number /= 10;
            }        
            return sumOdd;
        }
       private  static int PrintMultiplied(int number)
        {
            return GetSumOfEvenDigits(number) * GetSumOfOddDigits(number);
        }
    }
}