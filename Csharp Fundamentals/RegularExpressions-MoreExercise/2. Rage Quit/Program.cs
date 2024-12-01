using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace _2._Rage_Quit
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            string pattern = @"(?<text>[\D]+)(?<number>[\d]+)";

            var matches = Regex.Matches(input, pattern);
            var chars = new HashSet<char>();
            var result = new StringBuilder();
            
            foreach (Match item in matches)
            {
                string text = item.Groups["text"].Value.ToUpper();
                int number = int.Parse(item.Groups["number"].Value);

                if (number > 0)
                {
                  foreach (var charLetter in text)
                    {
                       chars.Add(charLetter);
                    }
                }
              
                for (int i = 0; i < number; i++)
                {
                    result.Append(text);
                }
            }

            Console.WriteLine($"Unique symbols used: {chars.Count }");
            Console.WriteLine(result.ToString());
        }
    }
}