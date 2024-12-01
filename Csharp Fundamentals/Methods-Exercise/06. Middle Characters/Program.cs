namespace _06._Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string result = "";
           PrintCharacterAtMiddle(word, result);
        }
        private static string PrintCharacterAtMiddle(string word, string result)
        {
            for (int i = 1; i < word.Length - 1; i++)
            {
                if (word.Length % 2 == 1)
                {
                    result = word[word.Length / 2].ToString();
                }
                else
                {
                    result = word[word.Length / 2 - 1].ToString() + word[word.Length / 2].ToString();
                }
            }
            Console.WriteLine(result);
            return result;
        }
    }
}