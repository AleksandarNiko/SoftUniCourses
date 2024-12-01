using System.Text.RegularExpressions;
using System.Text;

namespace _03._Treasure_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> keyNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            string regex = @"&(?<type>.+)&[^<]*<(?<coord>.+)>";
            int currentPosition = 0;
            string input;
            while ((input = Console.ReadLine()) != "find")
            {
                int keyLength = keyNumbers.Count;
                int sequenceLength = input.Length;
                var sb = new StringBuilder();

                for (int i = keyLength; i < sequenceLength; i++)
                {
                    keyNumbers.Add(keyNumbers[currentPosition]);
                    currentPosition++;
                }

                for (int i = 0; i < sequenceLength; i++)
                {
                    sb.Append((char)(input[i] - keyNumbers[i]));
                }

                Match m = Regex.Match(sb.ToString(), regex);

                if (m.Success)
                {
                    string type = m.Groups["type"].Value;
                    string coord = m.Groups["coord"].Value;
                    Console.WriteLine($"Found {type} at {coord}");
                }

            }
        }
    }
}