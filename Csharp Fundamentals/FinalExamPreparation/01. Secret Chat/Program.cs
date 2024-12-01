using System.Threading.Channels;

namespace _01._Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string secretMessage = Console.ReadLine();
            string input;
            while ((input = Console.ReadLine()) != "Reveal")
            {
                string[] lineToken = input.Split(":|:");
                string command = lineToken[0];

                if (command == "InsertSpace")
                {
                    int index = int.Parse(lineToken[1]);
                    secretMessage= secretMessage.Insert(index," " );
                }
                else if (command == "Reverse")
                {
                    string substring = lineToken[1];
                    
                    if (secretMessage.Contains(substring))
                    {
                        int index = secretMessage.IndexOf(substring);
                        secretMessage = secretMessage.Remove(index, substring.Length);
                        secretMessage = secretMessage + string.Join("", substring.Reverse());
                    }
                    else
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                }
                else if (command == "ChangeAll")
                {
                    string substring = lineToken[1];
                    string replacement = lineToken[2];

                    secretMessage = secretMessage.Replace(substring, replacement);
                }

                Console.WriteLine(secretMessage);
            }
            Console.WriteLine($"You have a new text message: {secretMessage}");
        }
    }
}
/*
heVVodar!gniV
ChangeAll:|:V:|:l
Reverse:|:!gnil
InsertSpace:|:5
Reveal
*/