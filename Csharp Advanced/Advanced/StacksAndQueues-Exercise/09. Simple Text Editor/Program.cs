using System.Text;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int operationsCount = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();
            Stack<string> stack = new Stack<string>();
            stack.Push(text.ToString());

            for (int i = 0; i < operationsCount; i++)
            {
                string[] lineToken = Console.ReadLine().Split();
                if (lineToken[0] == "1")
                {
                    text.Append(lineToken[1]);
                    stack.Push(text.ToString());
                }
                else if (lineToken[0] == "2")
                {
                    int number = int.Parse(lineToken[1]);
                    text.Remove(text.Length - number, number);
                    stack.Push(text.ToString());
                }
                else if (lineToken[0] == "3")
                {
                    int index = int.Parse(lineToken[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (lineToken[0] == "4")
                {
                    stack.Pop();
                    text = new StringBuilder();
                    text.Append(stack.Peek());
                }
            }
        }
    }
}
/*
8
1 abc
3 3
2 3
1 xy
3 2
4
4
3 1
 */
