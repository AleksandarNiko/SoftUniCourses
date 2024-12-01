using System.Text.RegularExpressions;

namespace _02._Message_Translator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();
                string pattern = @"!([A-Z][a-z]{2,})!:\[([A-Za-z]{8,})\]";
                Match match = Regex.Match(message,pattern );

                if (!match.Success)
                {
                    Console.WriteLine("The message is invalid");
                    continue;
                }
                else
                {
                    string messageInfo = match.Groups[2].Value;
                    int[] ASCIIvalues = new int[messageInfo.Length];

                    for (int j = 0; j < ASCIIvalues.Length; j++)
                    {
                        ASCIIvalues[j] = messageInfo[j];
                    }
                    Console.WriteLine($"{match.Groups[1].Value}: {string.Join(' ', ASCIIvalues)}");
                }

            }
        }
    }
}
/*
2
!Send!:[IvanisHere]
*Time@:[Itis5amAlready]
 */