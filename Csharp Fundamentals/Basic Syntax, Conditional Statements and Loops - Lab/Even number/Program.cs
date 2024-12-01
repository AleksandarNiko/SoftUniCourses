using System;

namespace Even_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            while (input % 2 != 0)
            {
                Console.WriteLine("Please write an even number.");

                input = int.Parse(Console.ReadLine());

                if (input % 2 == 0)
                {
                    break;
                }
            }

            Console.WriteLine($"The number is: {Math.Abs(input)}");
        }
    }
}
