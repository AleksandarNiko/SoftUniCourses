using System.Security.Cryptography.X509Certificates;

namespace _01._Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(", ");

            foreach (string word in words)
            {
                if (word.Length < 3 || word.Length > 16)
                {
                    continue;
                }
                if (IsValidWord(word))
                {
                    Console.WriteLine(word);
                }
            }

            
            
        }

        public static bool IsValidWord(string word)
        {
            return word.All(x => char.IsLetterOrDigit(x) || x == '_'|| x=='-');
        }
    }
}