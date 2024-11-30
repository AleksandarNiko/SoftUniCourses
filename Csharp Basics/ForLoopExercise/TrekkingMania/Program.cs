using System;

namespace TrekkingMania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int c1 = 0; int c2 = 0; int c3 = 0; int c4 = 0; int c5 = 0;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if (currentNumber <= 5)
                {
                    c1+=currentNumber;
                }
                else if (currentNumber<=12 ) { c2+=currentNumber; }
                else if ( currentNumber<=25) { c3+=currentNumber; }
                else if (currentNumber <= 40) { c4+=currentNumber; }
                else if(currentNumber>40) { c5+=currentNumber; }
                sum+=currentNumber;
            }
            Console.WriteLine($"{100.0 * c1 / sum:f2}%");
            Console.WriteLine($"{100.0 * c2 / sum:f2}%");
            Console.WriteLine($"{100.0 * c3 / sum:f2}%");
            Console.WriteLine($"{100.0 * c4 / sum:f2}%");
            Console.WriteLine($"{100.0 * c5 / sum:f2}%");
        }
    }
}
