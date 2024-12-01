using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;

namespace _05._Digits__Letters_and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word=Console.ReadLine();
            var nums = new StringBuilder();
            var letters = new StringBuilder();
            var others = new StringBuilder();
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];

                if (char.IsDigit(c))
                {
                    nums.Append(c);
                }
                else if (char.IsLetter(c))
                {
                    letters.Append(c);
                }
                else
                {
                    others.Append(c);
                }
            }
            Console.WriteLine($"{nums}\n{letters}\n{others}");

               //Another way:
           // Console.WriteLine(string.Join("",word.Where(char.IsDigit)));
           // Console.WriteLine(string.Join("", word.Where(char.IsLetter)));
           // Console.WriteLine(string.Join("", word.Where(x=>!char.IsLetter(x)&&!char.IsDigit(x))));


        }
    }
}