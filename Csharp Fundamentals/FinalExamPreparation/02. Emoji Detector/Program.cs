using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text=Console.ReadLine ();
            string numsPattern = @"\d";
            string emojiPattern = @"(\*{2}|:{2})(?<Emoji>[A-Z][a-z]{2,})\1";
            ulong coolThreshold = 1;
            List<string> coolEmojis = new List<string>();

            foreach (Match  match in Regex.Matches(text,numsPattern))
            {
                coolThreshold*=ulong.Parse(match.Value);
            }
            Console.WriteLine($"Cool threshold: {coolThreshold}");

            int count = 0;
            foreach (Match match in Regex.Matches(text, emojiPattern))
            {
                count++;
                string emojiStr = match.Groups["Emoji"].Value;
                ulong totalEmojiSum = 0;
                foreach (char character in emojiStr)
                {
                    totalEmojiSum += character;
                }

                if (totalEmojiSum >= coolThreshold)
                {
                    
                    coolEmojis.Add(match.Value);
                }
            }
            Console.WriteLine($"{count} emojis found in the text. The cool ones are:");
            foreach (var item in coolEmojis)
            {
                
                Console.WriteLine(item);
            }
        }
    }
}
//In the Sofia Zoo there are 311 animals in total! ::Smiley:: This includes 3 **Tigers**, 1 ::Elephant:, 12 **Monk3ys**, a **Gorilla::, 5 ::fox:es: and 21 different types of :Snak::Es::. ::Mooning:: **Shy**