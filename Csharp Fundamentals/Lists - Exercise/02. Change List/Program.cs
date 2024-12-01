using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace _02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string line;
            
            while ((line = Console.ReadLine()) != "end")
            {
                string[] lineToken = line.Split().ToArray();
                string command = lineToken[0];
                int number = int.Parse(lineToken[1]);
                int index;
                if (command == "Delete")
                {
                    list.RemoveAll(x=>x==number);
                    
                }
                else if(command == "Insert")
                {
                    int item = int.Parse(lineToken[1]);
                    index = int.Parse(lineToken[2]);
                    list.Insert(index, item);
                }
            }
            Console.WriteLine(string.Join(" ",list));

        }
    }
}
