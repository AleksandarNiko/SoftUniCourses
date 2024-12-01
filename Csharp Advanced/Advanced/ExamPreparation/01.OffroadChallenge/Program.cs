using System;
using System.Collections;

namespace _01.OffroadChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> initialFuels=new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> consumptionIndexes = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            Queue<int> fuels=new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToList());

            int altitude = 1;

            bool isReached=false;

            while (initialFuels.Count > 0)
            {
                int currentFuel=initialFuels.Pop();
                int currentConsumption = consumptionIndexes.Dequeue();
                int neededFuel=fuels.Dequeue();
                int result = currentFuel - currentConsumption;

                if (result >= neededFuel)
                {
                    Console.WriteLine($"John has reached: Altitude {altitude++}");
                }

                else
                {
                    Console.WriteLine($"John did not reach: Altitude {altitude--}");
                    isReached = true;
                    break;
                }

            }

            if (isReached)
            {
                Console.WriteLine("John failed to reach the top.");

                if (altitude == 0)
                {
                    Console.WriteLine("John didn't reach any altitude.");
                }
                else
                {
                    Console.Write("Reached altitudes: ");

                    for (int i = 0; i < altitude; i++)
                    {
                        Console.Write($"Altitude {i+1}");

                        if (i < altitude - 1)
                        {
                            Console.Write(", ");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
            }
        }
    }
}
/*
200 90 40 100
20 40 30 50
50 60 80 90
 */
