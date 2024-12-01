using System.Text;
using System.Threading.Channels;

namespace _04._Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                sb.Append((char)(c+3));
            }
            Console.WriteLine(sb);
        }
    }
}