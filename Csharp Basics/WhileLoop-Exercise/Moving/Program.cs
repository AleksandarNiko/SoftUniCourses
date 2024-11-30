using System;

namespace Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int heigh = int.Parse(Console.ReadLine());
            string inputBoxes = Console.ReadLine();
            double totalSpace = width * length * heigh;
            double takenSpace = 0;
            while (inputBoxes != "Done")
            {
                int boxes = int.Parse(inputBoxes);
                takenSpace += boxes;
                if (takenSpace > totalSpace) { break; }
                inputBoxes = Console.ReadLine();
            }
            if (totalSpace>=takenSpace)
                {
                    Console.WriteLine($"{totalSpace-takenSpace} Cubic meters left.");
                }
                else
                {
                Console.WriteLine($"No more free space! You need {Math.Abs(totalSpace-takenSpace)} Cubic meters more.");
            }

            }
        }
        }
    

