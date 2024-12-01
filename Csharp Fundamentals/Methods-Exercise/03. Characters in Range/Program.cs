namespace _03._Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            PrintChars(firstChar, secondChar);
        }

        private static void PrintChars(char firstChar, char secondChar)
        {
            int startCharacter = Math.Min(firstChar, secondChar);
            int endCharacter = Math.Max(firstChar, secondChar);
            for (int i = startCharacter + 1; i < endCharacter; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}