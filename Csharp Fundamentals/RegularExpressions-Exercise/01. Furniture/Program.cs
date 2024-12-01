using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace _01._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<item>[A-Z]+[a-z]*)<<(?<price>[\d]+[.[\d]+]*)!(?<quantity>[\d]+)";
            Console.WriteLine("Bought furniture:");
            double sum = 0.0;
            string input;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    sum += double.Parse(match.Groups["price"].Value) * int.Parse(match.Groups["quantity"].Value);

                    Console.WriteLine(match.Groups["item"]);
                }
                
            }

            Console.WriteLine($"Total money spend: {sum:f2}");


        }
    }
}
/*
>>Sofa<<312,23!3
>>TV<<300!5
>Invalid<<!5
Purchase
*/