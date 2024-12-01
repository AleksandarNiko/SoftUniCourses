using System.Text.RegularExpressions;

namespace _04._Text_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();
            
            foreach (string ban in bannedWords)
            {
                text = text.Replace(ban, new string('*',ban.Length));
            }
            Console.WriteLine(text);
        }
    }
}
/*
Linux, Windows
It is not Linux, it is GNU/Linux. Linux is merely the kernel, while GNU adds the functionality. Therefore we owe it to them by calling the OS GNU/Linux! Sincerely, a Windows client
*/