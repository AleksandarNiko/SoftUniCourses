﻿using System.Security.Cryptography.X509Certificates;

namespace _09._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string input;
            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] lineToken = input.Split();
                string command = lineToken[0];
                string filter = lineToken[1];
                string value = lineToken[2];

                if (command == "Remove")
                {
                    people.RemoveAll(GetPredicate(filter, value));
                }
                else
                {
                    List<string> peopleToDouble = people.FindAll(GetPredicate(filter, value));

                    foreach (string person in peopleToDouble)
                    {
                        int index = people.FindIndex(p => p == person);
                        people.Insert(index,person);
                    }
                }
            }

            if (people.Count > 0)
            {
                Console.Write($"{string.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

            static Predicate<string> GetPredicate(string filter,string value)
                {
                    switch (filter)
                    {
                        case "StartsWith":
                            return x => x.StartsWith(value);
                        case "EndsWith":
                            return x => x.EndsWith(value);
                        case "Length":
                            return x => x.Length ==int.Parse(value);
                        default:
                            return default;
                    }
                }
            }

        }
    }

