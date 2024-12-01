namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x => x * 0.2 + x)
                .ToArray();
            foreach (double x in nums)
            {
                Console.WriteLine($"{x:f2}");
            }
        }
    }
}
//1,38, 2,56, 4,4