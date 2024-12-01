namespace _06._Calculate_Rectangle_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            PrintArea(a, b);

        }

        private static void PrintArea(int a, int b)
        {
            int area = (a * b);
            Console.WriteLine(area);
        }
    }
}