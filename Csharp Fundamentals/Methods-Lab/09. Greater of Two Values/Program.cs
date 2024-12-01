using System.Collections.Generic;
using System.Xml.Linq;

namespace _09._Greater_of_Two_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            PrintGreaterInt(type);
            PrintGreaterChar(type);
            PrintGreaterString(type);
        }
        static void PrintGreaterInt(string type)
        {
            if (type == "int")
            {
                int num = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());
                if (num > num2)
                {
                    Console.WriteLine(num);
                }
                else
                {
                    Console.WriteLine(num2);
                }
            }
        }
        static void PrintGreaterChar(string type)
        {
            if (type == "char")
            {
                char a = char.Parse(Console.ReadLine());
                char b = char.Parse(Console.ReadLine());
                if (a > b)
                {
                    Console.WriteLine(a);
                }
                else
                {
                    Console.WriteLine(b);
                }
            }
        }

        static void PrintGreaterString(string type)
        {
            if (type == "string")
            {
                string name1 = Console.ReadLine();
                string name2 = Console.ReadLine();
                int shortLength = Math.Min(name1.Length, name2.Length);

                for (int i = 0; i < shortLength; i++)
                {
                    if (name1[i] > name2[i])
                    {
                        Console.WriteLine(name1);
                        return;
                    }
                    else if (name2[i] > name1[i])
                    {
                        Console.WriteLine(name2);
                        return;
                    }
                }
            }
        }
    }
}