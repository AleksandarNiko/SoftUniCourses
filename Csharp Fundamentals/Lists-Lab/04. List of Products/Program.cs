using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._List_of_Products
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            List <string> list = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string products = Console.ReadLine();
                list.Add(products);
            }
           list.Sort();
            for (int i = 0; i<list.Count ; i++)
            {
                Console.WriteLine($"{i + 1}.{list[i]}");
            }
        }
    }
}
