namespace _01._Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ",Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x=>x%2==0)
                .OrderBy(x=>x)
                .ToList())
            );
        }
    }
}
//4, 2, 1, 3, 5, 7, 1, 4, 2, 12
