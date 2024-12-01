using System;

namespace _01.RecursiveArraySum
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[]nums=Console.ReadLine().Split().Select(int.Parse).ToArray();
            int index = 0;
            Console.WriteLine(Sum(nums,index));
        }

        static int Sum(int[] nums,int index)
        {
            if (index >= nums.Length)
            {
                return 0;
            }
            return nums[index] + Sum(nums, index + 1);
        }
    }
}
