using System.Diagnostics;
using System.Reflection;

namespace _01._Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string activationKey=Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "Generate")
            {
                string[] lineToken = input.Split(">>>");
                string command = lineToken[0];
                if (command == "Contains")
                {
                    string substring = lineToken[1];
                    if (activationKey.Contains(substring))
                    {
                        Console.WriteLine($"{activationKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (command == "Flip")
                {
                    string type = lineToken[1];
                    if (type == "Upper")
                    {
                        activationKey = TypeUpper(lineToken, activationKey);
                    }
                    else if (type == "Lower")
                    {
                        activationKey = TypeLower(lineToken, activationKey);
                    }
                }
                else if (command == "Slice")
                {
                    int startIndex = int.Parse(lineToken[1]);
                    int endIndex = int.Parse(lineToken[2]);

                    string prefix = activationKey.Substring(0, startIndex);
                    string suffix = activationKey.Substring(endIndex);

                    activationKey = $"{prefix}{suffix}";
                    Console.WriteLine(activationKey);
                }
            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }

        private static string TypeLower(string[] lineToken, string? activationKey)
        {
            int startIndex = int.Parse(lineToken[2]);
            int endIndex = int.Parse(lineToken[3]);
            string prefix = activationKey.Substring(0, startIndex);
            string middlefix = activationKey.Substring(startIndex, endIndex - startIndex).ToLower();
            string suffix = activationKey.Substring(endIndex);
            activationKey = $"{prefix}{middlefix}{suffix}";
            Console.WriteLine(activationKey);
            return activationKey;
        }

        private static string TypeUpper(string[] lineToken, string? activationKey)
        {
            int startIndex = int.Parse(lineToken[2]);
            int endIndex = int.Parse(lineToken[3]);
            string prefix = activationKey.Substring(0, startIndex);
            string middlefix = activationKey.Substring(startIndex, endIndex - startIndex).ToUpper();
            string suffix = activationKey.Substring(endIndex);
            activationKey = $"{prefix}{middlefix}{suffix}";
            Console.WriteLine(activationKey);
            return activationKey;
        }
    }
}
/*
abcdefghijklmnopqrstuvwxyz
Slice>>>2>>>6
Flip>>>Upper>>>3>>>14
Flip>>>Lower>>>5>>>7
Contains>>>def
Contains>>>deF
Generate
*/