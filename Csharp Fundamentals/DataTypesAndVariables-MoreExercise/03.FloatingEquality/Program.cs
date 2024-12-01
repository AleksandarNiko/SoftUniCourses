namespace _03.FloatingEquality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = 0.0;
            double num2 = 0;
            double eps = 0.000001;
                num1 = double.Parse(Console.ReadLine());
                num2 = double.Parse(Console.ReadLine());
                bool isEqual = Math.Abs(num1 - num2) < eps;


                if (isEqual)
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");
                }
        }
    }
}