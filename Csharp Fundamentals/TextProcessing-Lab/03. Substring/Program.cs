using System.Text;
using System.Xml.XPath;

namespace _03._Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word1 = Console.ReadLine();
            string words = Console.ReadLine();
            
            while (words.Contains(word1))
            {
                int index = words.IndexOf(word1);
                words = words.Remove(index, word1.Length);
            }
            Console.WriteLine(words);
        }
    }
}
/*
ice
kicegiciceeb
*/