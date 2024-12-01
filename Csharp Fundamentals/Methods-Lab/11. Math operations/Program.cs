using System.Reflection;

namespace _11._Math_operations
{
    internal class Program
    {
        //*
        // /,
        // *,
        // +
        // and -.
        //*
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            char op = char.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            NewMethod(num, op, num2);
        }

        private static void NewMethod(int num, char op, int num2)
        {
            if (op == '-')
            {
                Console.WriteLine(Math.Abs(num - num2));
            }
            else if (op == '+')
            {
                Console.WriteLine(num + num2);
            }
            else if (op == '*')
            {
                Console.WriteLine(num * num2);
            }
            else if (op == '/')
            {
                Console.WriteLine(num / num2);
            }
        }
    }
}