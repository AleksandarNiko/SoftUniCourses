using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _02._Character_Multiplier
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ");
            int sum = 0;
            string firstWord = words[0];
            string secondWord = words[1];
            int maxLength = Math.Max(firstWord.Length, secondWord.Length);

            for (int i = 0; i < maxLength; i++)
            {
                if (i < firstWord.Length && i < secondWord.Length)
                {
                    sum += firstWord[i] * secondWord[i];
                }
                else if (i < firstWord.Length)
                {
                    sum += firstWord[i];
                }
                else if (i < secondWord.Length)
                {
                    sum += secondWord[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}