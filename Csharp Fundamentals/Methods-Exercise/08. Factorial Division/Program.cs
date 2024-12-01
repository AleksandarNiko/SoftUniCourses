namespace _08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            double sumA = 1;
            double sumB = 1;
            PrintDividedFactoriels(a, b,sumA,sumB);
        }

        private static void PrintDividedFactoriels(int a, int b,double sumA,double sumB)
        {
            
            for (int i = 1; i <= a; i++)
            {
                sumA *= i;
            }
            for (int i = 1; i <= b; i++)
            {
                sumB *= i;
            }
            Console.WriteLine($"{(sumA / sumB):f2}");
        }
    }
}