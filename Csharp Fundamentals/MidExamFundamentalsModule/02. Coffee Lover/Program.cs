using System;
using System.Reflection.Metadata.Ecma335;

namespace _02._Coffee_Lover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> coffeNames = Console.ReadLine().Split(' ').ToList();
            int numOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfCommands; i++)
            {
                string[] lineToken = Console.ReadLine().Split();
                string command = lineToken[0];
                if (command == "Include")
                {
                    string coffee = lineToken[1];
                    coffeNames.Add(coffee);
                }
                if (command == "Remove")
                {
                    string position = lineToken[1];
                    int count = int.Parse(lineToken[2]);

                    if (position == "first")
                    {
                        coffeNames = coffeNames.Skip(count).ToList();
                    }
                    else if (position == "last")
                    {
                        coffeNames = coffeNames.Take(coffeNames.Count - count).ToList();
                    }

                    if (command == "Prefer")
                    {
                        int index1 = int.Parse(lineToken[1]);
                        int index2 = int.Parse(lineToken[2]);

                        if (index1 >= 0 && index1 < coffeNames.Count &&
                            index2 >= 0 && index2 < coffeNames.Count)
                        {
                            if (index1 > index2)
                            {
                                string temp = coffeNames[index1];
                                coffeNames[index1] = coffeNames[index2];
                                coffeNames[index2] = temp;
                            }
                            else
                            {
                                string temp = coffeNames[index2];
                                coffeNames[index2] = coffeNames[index1];
                                coffeNames[index1] = temp;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                        if (command == "Reverse")
                        {
                            coffeNames.Reverse();
                        }
                    }
                Console.WriteLine("Coffees:");
                Console.WriteLine(string.Join(" ", coffeNames));
            }
        }
    }

    

    

/*
Arabica Liberica Magnistipula Robusta BulkCoffee StrongCoffee
5
Include TurkishCoffee
Remove first 2
Remove last 1
Prefer 3 1
Reverse
*/