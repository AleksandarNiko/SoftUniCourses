namespace _07._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int repeat = int.Parse(Console.ReadLine());
            PrintWord(word, repeat);
        }

        private static void PrintWord(string word, int repeat)
        {
            for (int i = 0; i < repeat; i++)
            {
                Console.Write(word);
            }
        }
    }
}