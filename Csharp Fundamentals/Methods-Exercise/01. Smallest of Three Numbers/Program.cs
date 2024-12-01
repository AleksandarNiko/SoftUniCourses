namespace _01._Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            PrintMinNumber(a, b, c);
        }
        private static void PrintMinNumber(int a, int b, int c)
        {
            if (a <= b && a <= c)
            {
                Console.WriteLine(a);
            }
            else if (b <= c && b <= a)
            {
                Console.WriteLine(b);
            }
            else if (c <= a && c <= b)
            {
                Console.WriteLine(c);
            }
        }
    }
}