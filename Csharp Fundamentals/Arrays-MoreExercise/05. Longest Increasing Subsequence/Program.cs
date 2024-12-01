using System.Collections.Generic;

namespace _05._Longest_Increasing_Subsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] lis;
            int[] len = new int[nums.Length];
            int[] prev = new int[nums.Length];
            int maxLength = 0;
            int lastIndex = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                len[i] = 1;
                prev[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    
                    if (nums[j] < nums[i] && len[j] >= len[i])
                    {
                        len[i] = 1 + len[j];
                        prev[i] = j; 
                    }
                }
                if (len[i] > maxLength)
                {
                    maxLength = len[i];
                    lastIndex = i;
                }
            }
            lis = new int[maxLength];
            for (int i = 0; i < maxLength; i++)
            {
                lis[i] = nums[lastIndex];
                lastIndex = prev[lastIndex];
            }           
            Console.WriteLine(string.Join(" ", lis.Reverse()));
        }
    }
}