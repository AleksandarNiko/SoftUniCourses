using System;
using System.Security.Cryptography;

namespace OperationsbetweenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double N1 = double.Parse(Console.ReadLine());
            double N2 = double.Parse(Console.ReadLine());
            char op = char.Parse(Console.ReadLine());
            double result = 0.00;
            string oddOrEven = "";
            switch (op)
            {
                case '+':
                    result = N1 + N2;
                    if (result % 2 == 0)
                    {
                        oddOrEven = "even";
                    }
                    else
                    { oddOrEven = "odd"; }
                    Console.WriteLine($"{N1} + {N2} = {result} - {oddOrEven}");
                    break;
                case '-':
                    result = N1 - N2;
                    if (result % 2 == 0)
                    {
                        oddOrEven = "even";
                    }
                    else
                    { oddOrEven = "odd"; }
                    Console.WriteLine($"{N1} - {N2} = {result} - {oddOrEven}");
                    break;
                case '%':
                    result = N1 % N2;
                    if (N2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {N1} by zero");
                    }
                    else
                    {
                        Console.WriteLine($"{N1} % {N2} = {result}");
                    }
                    break;
                case '/':
                    result= N1 / N2;
                    if (N2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {N1} by zero");
                    }
                    else
                    {
                        Console.WriteLine($"{N1} / {N2} = {result:f2}");
                    }
                    break;
                case '*':
                    result = N1 * N2;
                    if (result % 2 == 0) { oddOrEven = "even"; }
                    else
                    {
                        oddOrEven = "odd";
                    }
                    Console.WriteLine($"{N1} * {N2} = {result} - {oddOrEven}");
                    break;
            }
            
        }
    }
}
