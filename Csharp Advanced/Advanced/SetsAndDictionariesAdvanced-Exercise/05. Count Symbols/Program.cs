namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, int> times = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!times.ContainsKey(text[i]))
                {
                    times.Add(text[i], 0);
                }
                times[text[i]]++;
            }
            SortedDictionary<char,int> sortedTimes= new SortedDictionary<char, int>(times);
            foreach (var time in sortedTimes)
            {
                Console.WriteLine($"{time.Key}: {time.Value} time/s");
            }
        }
    }
}
