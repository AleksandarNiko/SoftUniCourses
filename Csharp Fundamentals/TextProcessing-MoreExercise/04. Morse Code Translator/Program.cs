namespace _04._Morse_Code_Translator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string morseCode = Console.ReadLine();
            string translatedText = Translate(morseCode);
            Console.WriteLine(translatedText);
        }
        public static string Translate(string morseCode)
        {
            string[] words = morseCode.Split("   ", StringSplitOptions.RemoveEmptyEntries);
            string translatedText = "";

            foreach (string word in words)
            {
                string[] letters = word.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (string letter in letters)
                {
                    translatedText += MorseCodeToLetter(letter);
                }

                translatedText += " ";
            }

            return translatedText.Trim();
        }

        private static char MorseCodeToLetter(string morseCode)
        {
            switch (morseCode)
            {
                case ".-":
                    return 'A';
                case "-...":
                    return 'B';
                case "-.-.":
                    return 'C';
                case "-..":
                    return 'D';
                case ".":
                    return 'E';
                case "..-.":
                    return 'F';
                case "--.":
                    return 'G';
                case "....":
                    return 'H';
                case "..":
                    return 'I';
                case ".---":
                    return 'J';
                case "-.-":
                    return 'K';
                case ".-..":
                    return 'L';
                case "--":
                    return 'M';
                case "-.":
                    return 'N';
                case "---":
                    return 'O';
                case ".--.":
                    return 'P';
                case "--.-":
                    return 'Q';
                case ".-.":
                    return 'R';
                case "...":
                    return 'S';
                case "-":
                    return 'T';
                case "..-":
                    return 'U';
                case "...-":
                    return 'V';
                case ".--":
                    return 'W';
                case "-..-":
                    return 'X';
                case "-.--":
                    return 'Y';
                case "--..":
                    return 'Z';
                default:
                    return ' ';
            }
        }
    }
    }
//.. | -- .- -.. . | -.-- --- ..- | .-- .-. .. - . | .- | .-.. --- -. --. | -.-. --- -.. .
//.. | .... --- .--. . | -.-- --- ..- | .- .-. . | -. --- - | -- .- -..