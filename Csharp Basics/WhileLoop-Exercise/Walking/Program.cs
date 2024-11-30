using System;

namespace Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int goal = 10000;
            string steps=Console.ReadLine();
            int sumSteps = 0;
            while(steps!="Going home")
            {
                int currentSteps=int.Parse(steps);
                sumSteps += currentSteps;
                if(sumSteps >= goal) { break; }
                steps=Console.ReadLine();
            }
            if (sumSteps < goal) 
            {
                int lastSteps=int.Parse(Console.ReadLine());
                sumSteps += lastSteps;
            }
            if(sumSteps >= goal)
            {
                Console.WriteLine($"Goal reached! Good job!");
                Console.WriteLine($"{sumSteps-goal} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{goal -sumSteps} more steps to reach goal.");
            }
        }
    }
}
