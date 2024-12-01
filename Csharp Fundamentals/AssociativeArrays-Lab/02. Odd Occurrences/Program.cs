namespace _02._Odd_Occurrences
{
    using System.Globalization;
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().ToLower().Split().ToList();
            Dictionary<string, int> sameWords = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (sameWords.ContainsKey(word))
                {
                    sameWords[word]++;
                }
                else
                {
                    sameWords.Add(word, 1);
                }
            }
            
                foreach (var word in sameWords)
                {
                if (word.Value % 2 == 1)
                {
                    Console.Write($"{word.Key+" "}");
                }
                }
            
        }
    }
}