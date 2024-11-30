using System;

namespace SumOfTwoNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstLine = int.Parse(Console.ReadLine());
            int finalLine = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int counter = 0;
            bool yes = true;
            for (int i = firstLine; i <= finalLine; i++)
            {
                for (int x = firstLine; x <= finalLine; x++)
                {
                    counter++;
                    if (i + x == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{counter} ({i} + {x} = {magicNumber})");
                        yes = false;
                        i = finalLine;
                    }
                }
            }
            if (yes)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicNumber}");
            }
        }
            }
        }
