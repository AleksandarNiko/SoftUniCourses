using System;

namespace HalfSumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int max = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                sum += currentNumber;
                if (max < currentNumber)
                {
                    max = currentNumber;
                }
            }
                int sumWithoutMax = sum - max;

                if (max == sumWithoutMax)
                {
                    Console.WriteLine($"Yes");
                    Console.WriteLine($"Sum = {max}");
                }
                else
                {
                    Console.WriteLine($"No");
                    Console.WriteLine($"Diff = {Math.Abs(sumWithoutMax - max)}");
                }
            }
        }
    }

        
