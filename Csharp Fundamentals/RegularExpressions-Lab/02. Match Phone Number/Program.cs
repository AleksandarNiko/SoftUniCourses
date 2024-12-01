using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\+359([ -])2(\2)(\d{3})(\2)(\d{4}))\b";
            var phoneNumbers = Console.ReadLine();
            var phoneMatches = Regex.Matches(phoneNumbers, pattern);
            var correctNumbers = phoneMatches.Cast<Match>().Select(a => a.Value.Trim()).ToArray();
            Console.WriteLine(string.Join(", ",correctNumbers));
        }
    }
}
/*
+359 2 222 2222, 359-2-222-2222, +359/2/222/2222, +359-2 2222222 +359 2-222-2222, +359-2-222-222, +359-2-222-22222 +359-2-222-2222
*/