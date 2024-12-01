using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word=Console.ReadLine();
            Dictionary<char, int> dic = new Dictionary<char, int>();
           
           for (int i = 0; i < word.Length; i++)
           {             
                char character = word[i];

                if(character==' ')
                {
                    continue;
                }

                if (!dic.ContainsKey(character))
                {
                    dic.Add(character, 0);
                }

                dic[character]++;
           }
           foreach (var character in dic)
            {
                Console.WriteLine($"{character.Key} -> {character.Value}");
            }
        }
    }
}