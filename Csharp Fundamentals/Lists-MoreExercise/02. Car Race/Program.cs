using System.Threading.Channels;

namespace _02._Car_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<int> nums=Console.ReadLine().Split().Select(int.Parse).ToList();
           double sumLeft = 0;
           double sumRight = 0;
            for (int i = 0; i < nums.Count/2; i++)
            {
                sumLeft += nums[i];
                if (nums[i] == 0)
                {
                    sumLeft *= 0.8;
                }
            }
            for (int j = nums.Count - 1; j > nums.Count/2; j--)
            {
                sumRight += nums[j];
                if (nums[j] == 0)
                {
                    sumRight *= 0.8;
                }
            }

            if (sumLeft > sumRight)
            {
                Console.WriteLine($"The winner is right with total time: {sumRight}");
            }
            else
            {
                Console.WriteLine($"The winner is left with total time: {sumLeft}");

            }
        }
    }
}