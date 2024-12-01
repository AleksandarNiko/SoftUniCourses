using System;
using System.Collections.Generic;
using System.Linq;


namespace _04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] lineToken = input.Split();
                string command = lineToken[0];
                if (command == "Add")
                {
                    list.Add(int.Parse(lineToken[1]));
                }
                if (command == "Insert")
                {
                    int number = int.Parse(lineToken[1]);
                    int index = int.Parse(lineToken[2]);
                    if (IsNotValidIndex(index, list.Count))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    list.Insert(index, number);
                }
                if (command == "Remove")
                {
                    int index = int.Parse(lineToken[1]);
                    if (IsNotValidIndex(index, list.Count))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    list.RemoveAt(index);
                }
                if (command == "Shift")
                {
                    string direction = lineToken[1];
                    int count = int.Parse(lineToken[2]);
                    Shift(list, direction, count);
                }
            }
                Console.WriteLine(string.Join(" ", list));
            
                static bool IsNotValidIndex(int index, int count)
                {
                    return index < 0 || index >= count;
                }
             static void Shift(List<int> list, string direction, int count)
            {
                count %= list.Count;

                if (direction == "left")
                {
                    List<int> shiftedPart = list.GetRange(0, count);
                    list.RemoveRange(0, count);
                    list.InsertRange(list.Count, shiftedPart);
                }
                else if (direction == "right")
                {
                    List<int> shiftedPart = list.GetRange(list.Count - count, count);
                    list.RemoveRange(list.Count - count, count);
                    list.InsertRange(0, shiftedPart);
                }
            }
        }
    }
}
