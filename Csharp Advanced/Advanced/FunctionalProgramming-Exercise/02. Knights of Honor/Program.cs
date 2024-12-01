namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split();

            Action<string[]> print = strings
                =>
            {
                foreach (string s in strings)
                {
                    Console.WriteLine($"Sir {s}");
                }
            };
            print(strings);
        }
    }
}
