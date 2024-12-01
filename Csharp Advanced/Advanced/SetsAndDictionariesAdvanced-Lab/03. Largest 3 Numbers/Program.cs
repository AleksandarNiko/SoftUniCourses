namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.None).Select(int.Parse).ToList();
            Console.WriteLine(string.Join(" ",numbers.OrderByDescending(x=>x).Take(3)));
        }
    }
}
