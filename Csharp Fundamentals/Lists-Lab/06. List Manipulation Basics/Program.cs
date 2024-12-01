using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string line=default;
            while ((line = Console.ReadLine())!="end")
            {
                string[]lineToken = line.Split().ToArray();
                string command = lineToken[0];
                int number = int.Parse(lineToken[1]);
                if (command == "Add")
                {
                    numbers.Add(number);
                }
                else if(command == "Remove")
                {
                    numbers.Remove(number);
                }
                else if(command == "RemoveAt")
                {
                    numbers.RemoveAt(number);
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(lineToken[2]);
                    numbers.Insert(index,number);
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
