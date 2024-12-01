using System;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace _01._The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();
            string input;
            while ((input = Console.ReadLine()) != "Decode")
            {
                string[] lineToken = input.Split('|');
                string command = lineToken[0];
                if (command == "Move")
                {
                    int numOfLetters = int.Parse(lineToken[1]);
                    string firstPart = encryptedMessage.Substring(0, numOfLetters);
                    string secondPart = encryptedMessage.Substring(numOfLetters);

                    encryptedMessage = secondPart + firstPart;
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(lineToken[1]);
                    string value = lineToken[2];
                    string  firstPart = encryptedMessage.Substring(0, index);
                    string secondPart = encryptedMessage.Substring(index);
                    encryptedMessage = firstPart + value + secondPart;
                }
                else if (command == "ChangeAll")
                {
                    string substring = lineToken[1];
                    string replacement = lineToken[2];
                    encryptedMessage = encryptedMessage.Replace(substring,replacement);
                }
            }

            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
        }
    }
}
/*
zzHe
ChangeAll|z|l
Insert|2|o
Move|3
Decode   
 */