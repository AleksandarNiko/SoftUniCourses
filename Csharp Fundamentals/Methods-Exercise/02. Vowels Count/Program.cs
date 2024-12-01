namespace _02._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();
            int countDigits = 0;
            PrintCountVowels(word, countDigits);
        }

        private static int PrintCountVowels(string word, int countDigits)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == 'a' || word[i] == 'e' || word[i] == 'i' || word[i] == 'o' || word[i] == 'u')
                {
                    countDigits++;
                }
            }
            Console.WriteLine(countDigits);
            return countDigits;
        }
    }
}