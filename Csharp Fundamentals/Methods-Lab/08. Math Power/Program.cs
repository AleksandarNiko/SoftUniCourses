namespace _08._Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            PrintPoweredNumber(number, power);
        }

        private static void PrintPoweredNumber(double number, int power)
        {
            double result = Math.Pow(number, power);
            Console.WriteLine(result);
        }
    }
}