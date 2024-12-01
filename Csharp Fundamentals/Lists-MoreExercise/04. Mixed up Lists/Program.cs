using System.Data;
using System.Diagnostics;
using System.Threading.Channels;

namespace _04._Mixed_up_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
             List<int>nums=Console.ReadLine().Split().Select(int.Parse).ToList();
             List<int> nums2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result=new List<int>();
            List<int>maxList=new List<int>();
            List<int>rule=new List<int>();
            if (nums.Count > nums2.Count)
            {
                maxList = nums;
            }
            else
            {
                maxList = nums2;
                maxList.Reverse();
            }
            for (int i = maxList.Count - 2; i < maxList.Count; i++)
            {
                rule.Add(maxList[i]);
            }
            rule.Sort();
            if (nums.Count > nums2.Count)
            {
                nums.RemoveRange(nums.Count - 2, 2);
                nums2.Reverse();
            }
            else
            {
                nums2.RemoveRange(nums2.Count - 2, 2);
                nums.Reverse();
            }
            for (int i = 0; i < nums.Count; i++)
            {
                result.Add(nums[i]);
                result.Add(nums2[i]);
            }
            List<int> output = result.FindAll(x => x > rule[0] && x < rule[1]);
            output.Sort();
            Console.WriteLine(string.Join(" ", output));

        }
    }
}
/*
1 5 23 64 2 3 34 54 12
43 23 12 31 54 51 92
*/