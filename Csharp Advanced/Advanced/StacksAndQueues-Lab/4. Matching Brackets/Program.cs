namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Stack<int> brackets = new Stack<int>();
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '(')
                {
                    brackets.Push(i);
                }
                else if (text[i] == ')')
                {
                    int start = brackets.Pop();
                    int end = i + 1;
                    string substring = text.Substring(start, end - start);
                    Console.WriteLine(substring);
                }
            }
        }
    }
}
