using System;

namespace MinNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input=Console.ReadLine();
            int min = int.MaxValue;
            while (input!="Stop")
            {
                int number=int.Parse(input);
                input = Console.ReadLine();
                if (number< min) { min = number; }
            }
            Console.WriteLine(min);
        }
    }
}
