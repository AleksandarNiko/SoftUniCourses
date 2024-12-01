using System;

namespace Sum_of_Odd_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n=int.Parse(Console.ReadLine());
            int sum = 0;
            for (var i = 1; i <= n; i++)
            {
                int currentNumber = i * 2 - 1;
                Console.WriteLine(currentNumber);
                sum += currentNumber;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
