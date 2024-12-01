namespace _01._SoftUni_Reception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEfficiency = int.Parse(Console.ReadLine());
            int secondEmployeeEfficiency = int.Parse(Console.ReadLine());
            int thirdEmployeeEfficiency = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            int allStudentsPerHour = 0;
            int timeCount = 0;
            while (studentsCount>0)
            {               
               allStudentsPerHour = firstEmployeeEfficiency + secondEmployeeEfficiency + thirdEmployeeEfficiency;
                studentsCount -= allStudentsPerHour;
                timeCount++;
                if (timeCount % 4 == 0)
                {
                    timeCount++;
                }
            }
            Console.WriteLine($"Time needed: {timeCount}h.");
        }
    }
}