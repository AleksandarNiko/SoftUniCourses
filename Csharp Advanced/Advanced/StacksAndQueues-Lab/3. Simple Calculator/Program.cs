using System.Linq.Expressions;

namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>(new Stack<string>(text));
            while (stack.Count > 1)
            {
                int leftNumber = int.Parse(stack.Pop());
                string sign = stack.Pop();
                int rightNumber = int.Parse(stack.Pop());

                if (sign == "+")
                {
                    stack.Push((leftNumber + rightNumber).ToString());
                }
                else if (sign == "-")
                {
                    stack.Push((leftNumber - rightNumber).ToString());
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
