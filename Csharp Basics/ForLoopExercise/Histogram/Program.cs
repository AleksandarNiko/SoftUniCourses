using System;

namespace Histogram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int c1 = 0; int c2 = 0; int c3 = 0; int c4 = 0; int c5 = 0;
            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if (currentNumber < 200)
                {
                    c1++;
                }
                else if (currentNumber < 400) { c2++; }
                else if (currentNumber < 600) { c3++; }
                else if (currentNumber < 800) { c4++; }
                else { c5++; }
            }
            Console.WriteLine($"{100.0 * c1 / n:f2}%");
            Console.WriteLine($"{100.0 * c2 / n:f2}%");
            Console.WriteLine($"{100.0 * c3 / n:f2}%");
            Console.WriteLine($"{100.0 * c4 / n:f2}%");
            Console.WriteLine($"{100.0 * c5 / n:f2}%");
        }
    } 
}

