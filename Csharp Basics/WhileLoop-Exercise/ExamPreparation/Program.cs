using System;

namespace ExamPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int badGrades=int.Parse(Console.ReadLine());
            string inputProblems=Console.ReadLine();
            int sum = 0;
            int count = 0;
            string lastProblem = "";
            int badGradesCount = 0;
            bool hasFailed = false;
            while (inputProblems != "Enough")
            {
                int currentGrade = int.Parse(Console.ReadLine());

                if (currentGrade <= 4)
                {
                    badGradesCount++;
                    if (badGradesCount ==badGrades) { hasFailed = true; break; }
                }

                sum += currentGrade;
                count++;
                lastProblem = inputProblems;
                inputProblems = Console.ReadLine();
            }
            if (hasFailed)
            {
                Console.WriteLine($"You need a break, {badGradesCount} poor grades.");
            }
            else
            {
                Console.WriteLine($"Average score: {1.0 * sum / count:f2}");
                Console.WriteLine($"Number of problems: {count}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }
    }
}
