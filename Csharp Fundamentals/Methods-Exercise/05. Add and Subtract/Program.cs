namespace _05._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            PrintSubtractedNumber(num1, num2, num3);
        }

        private static void PrintSubtractedNumber(int num1, int num2, int num3)
        {
            int sum = num1 + num2;
            int total = sum - num3;
            Console.WriteLine(total);
        }

    }
}