namespace _04.SumOfChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n=(char)int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                char currentLetter = char.Parse(Console.ReadLine());
                sum += currentLetter;
            }
                Console.WriteLine($"The sum equals: {sum}");
            
        }
    }
}