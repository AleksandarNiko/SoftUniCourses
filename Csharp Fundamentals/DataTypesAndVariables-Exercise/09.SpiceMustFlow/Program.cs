namespace _09.SpiceMustFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingYeld = int.Parse(Console.ReadLine());
                int collected = 0;
            int days = 0;
            if (startingYeld >= 100)
            {
                while (startingYeld >= 100)
                {
                    days++;
                    collected += startingYeld;
                    startingYeld -= 10;
                }
                collected -= (days + 1) * 26;
                Console.WriteLine(days);
                Console.WriteLine(collected);
            }
            else
            {
                Console.WriteLine(days); Console.WriteLine(collected);
            }
        }
    }
}