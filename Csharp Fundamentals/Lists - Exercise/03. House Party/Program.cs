using System;
using System.Collections.Generic;
using System.Linq;
namespace _03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int guestsCount = int.Parse(Console.ReadLine());
            List<string> guestList = new List<string>();

            for (int i = 0; i < guestsCount; i++)
            {
                string[] arguments = Console.ReadLine().Split();
                string name = arguments[0];
                if (arguments[2] == "going!")
                {
                    if (guestList.FindIndex(x => x == name) == -1)
                    {
                        guestList.Add(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                }
                if (arguments[2] == "not")
                {
                    if (guestList.FindIndex(x => x == name) == -1)
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                    else
                    {
                        guestList.Remove(name);
                    }
                }
            }
                Console.WriteLine(string.Join(" \n", guestList));          
        }
    }
}
