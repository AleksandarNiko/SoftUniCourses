using System;

namespace TrainTheTrainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int jury = int.Parse(Console.ReadLine());
            string presentation=Console.ReadLine();
            double totalSum = 0;
            int presentationCount = 0;
            while (presentation != "Finish")
            {
                double currentSum = 0;
                for (int i = 0; i < jury; i++)
                {
                    double grades = double.Parse(Console.ReadLine());
                    currentSum += grades;
                }

                double averageGrade = currentSum / jury;
                Console.WriteLine($"{presentation} - {averageGrade:F2}. ");
                totalSum += currentSum;
                presentationCount++;

                presentation = Console.ReadLine();
            }
            double final=totalSum / (jury*presentationCount);
                Console.WriteLine($"Student's final assessment is {final:f2}.");
            }
        }
    }

