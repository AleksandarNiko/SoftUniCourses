namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                int[]lineToken= Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (lineToken[0] == 1)
                {
                    stack.Push(lineToken[1]);
                }
                else if (lineToken[0] == 2)
                {
                    stack.Pop();
                }
                else if (lineToken[0] == 3&& stack.Any())
                {
                    Console.WriteLine(stack.Max());
                }
                else if (lineToken[0] == 4&& stack.Any())
                {
                    Console.WriteLine(stack.Min());
                }
            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
/*
9
1 97
2
1 20
2
1 26
1 20
3
1 91
4
 */
