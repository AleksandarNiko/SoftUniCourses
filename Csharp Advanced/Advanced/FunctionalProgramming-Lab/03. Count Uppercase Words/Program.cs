namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join("\n",Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Where(x => char.IsUpper(x[0]))));
        }
    }
}
