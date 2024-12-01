namespace _02.Grades
{
    internal class Program
    {
  // 2.00 – 2.99 - "Fail"
//• 3.00 – 3.49 - "Poor"
//• 3.50 – 4.49 - "Good"
//• 4.50 – 5.49 - "Very good"
//• 5.50 – 6.00 - "Excellent"

        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            PrintGrade(grade);
        }

        private static void PrintGrade(double grade)
        {
            switch (grade)
            {
                case >= 2.00 and <= 3.00:
                    Console.WriteLine("Fail");
                    break;
                case >= 3.00 and <= 3.49:
                    Console.WriteLine("Poor");
                    break;
                case >= 3.50 and <= 4.49:
                    Console.WriteLine("Good");
                    break;
                case >= 4.50 and <= 5.49:
                    Console.WriteLine("Very good");
                    break;
                case >= 5.50 and <= 6.00:
                    Console.WriteLine("Excellent");
                    break;
            }
        }
    }
}