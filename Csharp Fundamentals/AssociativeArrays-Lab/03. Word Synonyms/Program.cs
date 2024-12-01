using System.Collections.Generic;

namespace _03._Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfWords=int.Parse(Console.ReadLine());
            var words = new Dictionary<string,List<string>> ();
            for (int i = 1; i <= countOfWords; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();
                if (words.ContainsKey(word))
                {
                    words[word].Add(synonym);
                }
                else
                {
                    List<string> synonyms = new List<string>() { synonym };
                    words.Add(word, synonyms);
                }
            }
            foreach (var word in words)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ",word.Value)}");
            }

        }
    }
}
/*
3
cute
adorable
cute
charming
smart
clever
*/