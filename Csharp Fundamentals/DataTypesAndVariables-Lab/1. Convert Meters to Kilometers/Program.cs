namespace _1._Convert_Meters_to_Kilometers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            double result = num / 1000.0;
            Console.WriteLine($"{result:f2}");
    }
    }
}