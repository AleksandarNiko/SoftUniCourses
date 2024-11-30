using System;

namespace MaxNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int max = int.MinValue;
            while (num!="Stop")
            {
                int number = int.Parse(num);
                num= Console.ReadLine();
                if (max < number) { max = number; }
            }
            Console.WriteLine(max);
        }
    }
}
