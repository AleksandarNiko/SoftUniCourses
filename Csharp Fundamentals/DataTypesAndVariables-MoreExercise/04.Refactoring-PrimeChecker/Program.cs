﻿namespace _04.Refactoring_PrimeChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ___Do___ = int.Parse(Console.ReadLine());
            for (int takoa = 2; takoa <= ___Do___; takoa++)
            {
                string takovalie = "true";
                for (int cepitel = 2; cepitel < takoa; cepitel++)
                {
                    if (takoa % cepitel == 0)
                    {
                        takovalie = "false";
                        break;
                    }
                }
                Console.WriteLine($"{takoa} -> {takovalie}");
            }
        }
    }
}