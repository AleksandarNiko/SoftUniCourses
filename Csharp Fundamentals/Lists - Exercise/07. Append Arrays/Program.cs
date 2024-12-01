using System;
using System.Collections.Generic;

namespace _07._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[]stringArrays=Console.ReadLine().Split('|',StringSplitOptions.RemoveEmptyEntries);
            List<string> symbols =ExtractSymbols(stringArrays);

            Console.WriteLine(string.Join(" ",symbols));


            static List<string> ExtractSymbols(string[] stringArrays)
            {
                List <string>result = new List<string>();
                for (int i = stringArrays.Length - 1;i>=0;i--)
                { string sequense = stringArrays[i];
                    string[] arr = sequense.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    result.AddRange(arr);
                }
                return result;
            }

        }
    }
}
