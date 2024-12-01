namespace _04._Word_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();
            for (int i = 0; i < words.Count; i++)
            {
                string word = words[i];
                if (word.Length % 2 == 0)
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}