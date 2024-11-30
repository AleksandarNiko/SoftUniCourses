using System;

namespace Building
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int stages=int.Parse(Console.ReadLine());
            int rooms=int.Parse(Console.ReadLine());

            for (int stage = stages; stage >= 1; stage--)
            {
                for (int room = 0; room < rooms; room++)
                {
                    if (stage == stages)
                    {
                        Console.Write($"L{stage}{room} ");
                    }
                    else if (stage % 2 == 0)
                    {
                        Console.Write($"O{stage}{room} ");
                    }
                    else if (stage % 2 == 1)
                    {
                        Console.Write($"A{stage}{room} ");
                    }
                }

                Console.WriteLine();
            }

        }
    }
}
