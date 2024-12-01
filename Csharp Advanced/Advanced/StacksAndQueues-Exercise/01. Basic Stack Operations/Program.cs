namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lineToken=Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = lineToken[0];
            int s = lineToken[1];
            int x = lineToken[2];

            string[] secondLine = Console.ReadLine().Split();
            Stack<int> stack = new Stack<int>(n);

            foreach (var item in secondLine)
            {
                int temp=int.Parse(item);
                stack.Push(temp);
            }  
            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count== 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
/*
5 2 13
1 13 45 32 4
 */
