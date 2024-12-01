using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main(string[] args)
    {
        int key = int.Parse(Console.ReadLine());
        var goodChildren = new List<string>();
        string input;
        while ((input = Console.ReadLine()) != "end")
        {
            string message = GetDecodedInput(input, key);
            string pattern = @"[@](?<name>[A-Za-z]+)[^@!:>-]+[!](?<behaviour>[G|N])[!]";
            var matches = Regex.Matches(message, pattern);

            if (matches.Count == 0)
            {
                continue;
            }

            string childName = matches[0].Groups["name"].Value;
            string childBehaviour = matches[0].Groups["behaviour"].Value;

            if (childBehaviour == "G")
                goodChildren.Add(childName);
        }
        Console.WriteLine(String.Join("\n", goodChildren));
    }

    static string GetDecodedInput(string input, int key)
    {
        char[] decodedChars = input
            .ToCharArray()
            .Select(x => (char)(x - key))
            .ToArray();
        return String.Join("", decodedChars);
    }
}

/*
3
CNdwhamigyenumje$J$
CEreelh-nmguuejn$J$
CVwdq&gnmjkvng$Q$
end
*/
